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
    public partial class CustomerForms : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thelo\Documents\dbLMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public CustomerForms()
        {
            InitializeComponent();
            LoadCustomer();
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

        public void LoadCustomer()
        {

            int i = 0;
            dgvCustomers.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM  tbCustomer", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomers.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAddCust_Click(object sender, EventArgs e)
        {
            CostumerModuleForm moduleForm = new CostumerModuleForm();
            moduleForm.btnSave.Enabled = true;
            moduleForm.btnUpdate.Enabled = false;
            LoadCustomer();
            moduleForm.ShowDialog();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomers.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CostumerModuleForm moduleForm = new CostumerModuleForm();
                moduleForm.CustomerId.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                moduleForm.txtName.Text = dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                moduleForm.txtAddress.Text = dgvCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
                moduleForm.txtPhone.Text = dgvCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
            

                moduleForm.btnSave.Enabled = false;
                moduleForm.btnUpdate.Enabled = true;
                moduleForm.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want delete this Customer ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbCustomer WHERE cid LIKE '" + dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfuly deleted!");
                }
            }
            LoadCustomer();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
