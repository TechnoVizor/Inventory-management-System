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
    public partial class UserForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thelo\Documents\dbLMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public UserForm()
        {
            InitializeComponent();
            LoadUser();

            panel.MouseDown += Form_MouseDown;
            panel.MouseMove += Form_MouseMove;
            panel.MouseUp += Form_MouseUp;
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


       
        public void LoadUser()
        {

            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM  tbUser", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModuleUser moduleUser = new ModuleUser();
            moduleUser.btnSave.Enabled = true;
            moduleUser.btnUpdate.Enabled = false;
            LoadUser();
            moduleUser.ShowDialog();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ModuleUser moduleUser = new ModuleUser();
                moduleUser.UserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                moduleUser.FullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                moduleUser.Password.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                moduleUser.Address.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                moduleUser.Phone.Text = dgvUser.Rows[e.RowIndex].Cells[5].Value.ToString();

                moduleUser.btnSave.Enabled = false;
                moduleUser.btnUpdate.Enabled = true;
                moduleUser.UserName.Enabled = false;
                moduleUser.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want delete this User ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfuly deleted!");
                }
            }
            LoadUser();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
