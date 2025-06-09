using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Inventory_management
{
    public partial class OrderModule : Form
    {

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thelo\Documents\dbLMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;
        public OrderModule()
        {

            InitializeComponent();


            slidepanel.MouseDown += Form_MouseDown;
            slidepanel.MouseMove += Form_MouseMove;
            slidepanel.MouseUp += Form_MouseUp;
            LoadProduct();
            LoadCustomer();



        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {

                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));

                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void LoadCustomer()
        {

            int i = 0;
            dgvCustomers.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbCustomer WHERE CONCAT(cid , cname) LIKE '%" + txtSearchCust.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomers.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }
        public void LoadProduct()
        {

            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM  tbProduct WHERE CONCAT(pid , pname , pprice , pdescription , pcategory) LIKE '%" + txtSearchProd.Text + "%' ", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();

            if (int.TryParse(txtPrice.Text, out int price) && numericUpDown1.Value > 0)
            {
             
                int selectedQuantity = Convert.ToInt32(numericUpDown1.Value); 

                if (selectedQuantity > qty) 
                {
                    MessageBox.Show("Order quantity (" + selectedQuantity + ") out of stock!\nAvailable: " + qty, "Insufficient quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    
                    numericUpDown1.Value = qty;

                   
                    if (qty == 0)
                    {
                        txtTotal.Text = "0";
                        return; 
                    }
                 
                    selectedQuantity = qty;
                }

                
                int total = price * selectedQuantity;
                txtTotal.Text = total.ToString();
            }
            else
            {
               
                txtTotal.Text = "0";
            }
        }




        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCustid.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCustName.Text = dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProdId.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtProdName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                GetQty();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustid.Text == "")
                {
                    MessageBox.Show("Please select customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtProdId.Text == "")
                {
                    MessageBox.Show("Please select product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to Add order?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbOrder(odate,pid,cid,qty,price,total)VALUES(@odate , @pid, @cid,  @qty,  @price, @total)", con);
                    cm.Parameters.AddWithValue("@odate", dtOrder.Value);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt16(txtProdId.Text));
                    cm.Parameters.AddWithValue("@cid", Convert.ToInt16(txtCustid.Text));
                    cm.Parameters.AddWithValue("@qty", Convert.ToInt16(numericUpDown1.Value));
                    cm.Parameters.AddWithValue("@price", Convert.ToInt16(txtPrice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt16(txtTotal.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Order has been successfully saved");

                    cm = new SqlCommand("UPDATE tbProduct SET pqty = (pqty-@pqty) WHERE pid LIKE '" + txtProdId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(numericUpDown1.Value));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();


                    Clear();
                    LoadProduct();

                }

            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Clear()
        {
            txtCustid.Clear();
            txtCustName.Clear();

            txtProdId.Clear();
            txtProdName.Clear();

            txtPrice.Clear();
            numericUpDown1.Value = 0;
            txtTotal.Clear();

            dtOrder.Value = DateTime.Now;
        }

        private void btnOrderClear_Click(object sender, EventArgs e)
        {
            Clear();


        }
        public void GetQty()
        {
            qty = 0; 

            if (string.IsNullOrEmpty(txtProdId.Text))
            {
                
                return;
            }

            
            if (!int.TryParse(txtProdId.Text, out int productId))
            {
                
                MessageBox.Show("Wrong ID of product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                
               
                cm = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid = @pid", con);
                cm.Parameters.AddWithValue("@pid", productId);

                con.Open();
             
                dr = cm.ExecuteReader();

                if (dr.Read()) 
                {
                    qty = Convert.ToInt32(dr["pqty"]); 
                }
                else
                {
                   
                    qty = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting product quantity: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                qty = 0; 
            }
            finally
            {
               
                if (dr != null && !dr.IsClosed) 
                {
                    dr.Close();
                }
                if (con.State == ConnectionState.Open) 
                {
                    con.Close();
                }
            }
        }
    }
}