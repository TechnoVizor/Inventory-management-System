using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;


namespace Inventory_management
{
    public partial class CostumerModuleForm : Form
    {

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thelo\Documents\dbLMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public CostumerModuleForm()
        {
            InitializeComponent();

            slidepanel.MouseDown += Form_MouseDown;
            slidepanel.MouseMove += Form_MouseMove;
            slidepanel.MouseUp += Form_MouseUp;

           
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

      

     

        public void Clear()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
          try
            {

                if (MessageBox.Show("Are you sure you want to Save this customer?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbCustomer(cname,caddress,cphone)VALUES(@cname,@caddress,@cphone)", con);
                    cm.Parameters.AddWithValue("@cname", txtName.Text);
                    cm.Parameters.AddWithValue("@caddress", txtAddress.Text);
                    cm.Parameters.AddWithValue("@cphone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been successfully saved");
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

        private void pictureBoxClose_Click_1(object sender, EventArgs e)
        {
            Close();   
        }

        private void pictureBoxMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to Update this customer?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbCustomer SET cname = @cname,caddress=@caddress,cphone=@cphone WHERE cid LIKE '" + CustomerId.Text + "'", con);
                    cm.Parameters.AddWithValue("@cname", txtName.Text);
                    cm.Parameters.AddWithValue("@caddress", txtAddress.Text);
                    cm.Parameters.AddWithValue("@cphone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been successfully updated");
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


