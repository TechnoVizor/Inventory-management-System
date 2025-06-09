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
    public partial class main : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thelo\Documents\dbLMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public main()
        {
            InitializeComponent();

            panelmain.MouseDown += Form_MouseDown;
            panelmain.MouseMove += Form_MouseMove;
            panelmain.MouseUp += Form_MouseUp;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkpass.Checked == false)
                txtpass.UseSystemPasswordChar = true;
            else txtpass.UseSystemPasswordChar = false;

        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtpass.Clear();
            txtname.Clear();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
           this.WindowState= FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM tbUser WHERE username = @username AND password = @password", con);
                cm.Parameters.AddWithValue("@username", txtname.Text);
                cm.Parameters.AddWithValue("@password", txtpass.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    MessageBox.Show("Welcome " + dr["username"].ToString() + "  ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    main2 main = new main2();
                    this.Hide();
                    main.ShowDialog();
                    con.Close();
                    
                }
                else

                {

                    MessageBox.Show("Invalid username or password!", "ACCESS DENITED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}