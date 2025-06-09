using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_management
{
    public partial class main2 : Form
    {


        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


      

        private bool sidebarExpanded = false;
        private const int sidebarCollapsedWidth = 0;
        private const int sidebarExpandedWidth = 300;
        private const int sidebarAnimationSpeed = 16;
        


        public main2()
        {
            InitializeComponent();

            pnlSidebar.Width = sidebarCollapsedWidth;
            pnlSidebar.Visible = false;


            sidebarTimer = new System.Windows.Forms.Timer();
            sidebarTimer.Interval = 10; 
            sidebarTimer.Tick += sidebarTimer_Tick_1;


            pnlSidebar.Width = sidebarExpandedWidth; 
            pnlSidebar.Visible = true;               
            sidebarExpanded = true;

            panelTop1.MouseDown += Form_MouseDown;
            panelTop1.MouseMove += Form_MouseMove;
            panelTop1.MouseUp += Form_MouseUp;
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
        
            if (activeForm != null) 
            {
                activeForm.Close(); 
            }

           
            activeForm = childForm;

            
            childForm.TopLevel = false; 
            childForm.FormBorderStyle = FormBorderStyle.None; 
            childForm.Dock = DockStyle.Fill; 
            pnlmain.Controls.Add(childForm); 
            pnlmain.Tag = childForm; 
            childForm.BringToFront(); 
            childForm.Show();

        
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

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void sidebarTimer_Tick_1(object sender, EventArgs e)
        {

            if (sidebarExpanded)
            {
                pnlSidebar.Width -= sidebarAnimationSpeed; 
                if (pnlSidebar.Width <= sidebarCollapsedWidth)
                {
                    pnlSidebar.Width = sidebarCollapsedWidth;
                    sidebarExpanded = false; 
                    sidebarTimer.Stop(); 
                    
                }
            }
            else 
            {
                pnlSidebar.Visible = true; 
                pnlSidebar.Width += sidebarAnimationSpeed; 
                if (pnlSidebar.Width >= sidebarExpandedWidth) 
                {
                    pnlSidebar.Width = sidebarExpandedWidth; 
                    sidebarExpanded = true; 
                    sidebarTimer.Stop();
                }
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForms());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }
    }
}
