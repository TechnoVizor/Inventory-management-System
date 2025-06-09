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
using System.Xml.Linq;

namespace Inventory_management
{
    public partial class ProductModuleForm : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thelo\Documents\dbLMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductModuleForm()
        {
            InitializeComponent();

            slidepanel.MouseDown += Form_MouseDown;
            slidepanel.MouseMove += Form_MouseMove;
            slidepanel.MouseUp += Form_MouseUp;

            LoadCategory();
            
        }
        private void LoadCategory() 
        {
            comboBox1.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM tbCategory",con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to save product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbProduct(pname,pqty,pprice,pdescription,pcategory)VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory)", con);
                    cm.Parameters.AddWithValue("@pname", txtPname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPqty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPprice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtDescription.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboBox1.Text);
                    con.Open();
                    cm.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Product has been successfully saved");
                    Clear();
                    this.Dispose();
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

            txtPname.Clear();
            txtPqty.Clear();
            txtPprice.Clear();
            txtDescription.Clear();
            comboBox1.Text =  "";
            }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {

                if (MessageBox.Show("Are you sure you want to Update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbProduct SET pname = @pname, pqty = @pqty, pprice = @pprice , pdescription = @pdescription , pcategory = @pcategory WHERE pid LIKE '" + ProdId.Text + "'", con);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt32(ProdId.Text));
                    cm.Parameters.AddWithValue("@pname", txtPname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(txtPqty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt32(txtPprice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtDescription.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboBox1.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been successfully updated");

                    this.Dispose();
                    
                }

            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
    }

