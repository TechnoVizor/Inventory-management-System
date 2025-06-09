using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_management
{
    public partial class ProductForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thelo\Documents\dbLMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public ProductForm()
        {
            InitializeComponent();

            panel.MouseDown += Form_MouseDown;
            panel.MouseMove += Form_MouseMove;
            panel.MouseUp += Form_MouseUp;

            LoadProduct();
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
        private void btnAddCust_Click(object sender, EventArgs e)
        {
            ProductModuleForm moduleForm = new ProductModuleForm();
            moduleForm.btnSave.Enabled = true;
            moduleForm.btnUpdate.Enabled = false;
            LoadProduct();
            moduleForm.ShowDialog();
        }
        public void LoadProduct()
        {

            int i = 0;

            dgvProduct.Rows.Clear();

            cm = new SqlCommand("SELECT * FROM  tbProduct WHERE CONCAT(pid , pname , pqty , pprice , pdescription , pcategory) LIKE '%"+txtSearch.Text+"%' ", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i,                      
                    dr["pname"].ToString(),     
                    dr["pqty"].ToString(),      
                    dr["pprice"].ToString(),   
                    dr["pdescription"].ToString(), 
                    dr["pcategory"].ToString(), 
                    null);
            }
            dr.Close();
            con.Close();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModuleForm productModule = new ProductModuleForm();
                productModule.ProdId.Text = dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                productModule.txtPname.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.txtPqty.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtPprice.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.txtDescription.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.comboBox1.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();

    

                productModule.btnSave.Enabled = false;
                productModule.btnUpdate.Enabled = true;
                productModule.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want delete this Product ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                   

                    int quantityToReturn = Convert.ToInt32(dgvProduct.Rows[e.RowIndex].Cells["pid"].Value);

                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbProduct WHERE pid LIKE '" + dgvProduct.Rows[e.RowIndex].Cells["pid"].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record has been successfuly deleted!");

                    LoadProduct();
                }
            }
            LoadProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
