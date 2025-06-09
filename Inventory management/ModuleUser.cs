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

namespace Inventory_management
{
    public partial class ModuleUser : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thelo\Documents\dbLMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public ModuleUser()
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

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            
                Close();
            
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to save user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbUser(username,fullname,password,address,phone)VALUES(@username,@fullname,@password,@address,@phone)", con);
                    cm.Parameters.AddWithValue("@username",UserName.Text);
                    cm.Parameters.AddWithValue("@fullname", FullName.Text);
                    cm.Parameters.AddWithValue("@password", Password.Text);
                    cm.Parameters.AddWithValue("@address", Address.Text);
                    cm.Parameters.AddWithValue("@phone", Phone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                   
                    con.Close();
                    MessageBox.Show("User has been successfully saved");
                    clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void clear()
        {
            UserName.Clear();
            FullName.Clear();
            Password.Clear();
            Address.Clear();
            Phone.Clear();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure you want to update this user?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbUser SET fullname=@fullname,password=@password,address=@address,phone=@phone WHERE username LIKE '" +UserName.Text + "' ",con);
                    
                    cm.Parameters.AddWithValue("@fullname", FullName.Text);
                    cm.Parameters.AddWithValue("@password", Password.Text);
                    cm.Parameters.AddWithValue("@address", Address.Text);
                    cm.Parameters.AddWithValue("@phone", Phone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("User has been successfully updated!");
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
