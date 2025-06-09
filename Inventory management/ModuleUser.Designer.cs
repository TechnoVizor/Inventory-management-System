namespace Inventory_management
{
    partial class ModuleUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.slidepanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.UserName1 = new System.Windows.Forms.Label();
            this.FullName1 = new System.Windows.Forms.Label();
            this.Password1 = new System.Windows.Forms.Label();
            this.Address1 = new System.Windows.Forms.Label();
            this.Phone1 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.FullName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.slidepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // slidepanel
            // 
            this.slidepanel.BackColor = System.Drawing.Color.SteelBlue;
            this.slidepanel.Controls.Add(this.label1);
            this.slidepanel.Controls.Add(this.pictureBoxMinimize);
            this.slidepanel.Controls.Add(this.pictureBox5);
            this.slidepanel.Controls.Add(this.pictureBoxClose);
            this.slidepanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.slidepanel.Location = new System.Drawing.Point(0, 0);
            this.slidepanel.Name = "slidepanel";
            this.slidepanel.Size = new System.Drawing.Size(740, 70);
            this.slidepanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 34);
            this.label1.TabIndex = 16;
            this.label1.Text = "User module";
            // 
            // pictureBoxMinimize
            // 
            this.pictureBoxMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMinimize.Image = global::Inventory_management.Properties.Resources.minus_square_outlined_button;
            this.pictureBoxMinimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxMinimize.Location = new System.Drawing.Point(600, 3);
            this.pictureBoxMinimize.Name = "pictureBoxMinimize";
            this.pictureBoxMinimize.Size = new System.Drawing.Size(43, 39);
            this.pictureBoxMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMinimize.TabIndex = 15;
            this.pictureBoxMinimize.TabStop = false;
            this.pictureBoxMinimize.Click += new System.EventHandler(this.pictureBoxMinimize_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = global::Inventory_management.Properties.Resources.square_targeting_interface_symbol;
            this.pictureBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox5.Location = new System.Drawing.Point(649, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(43, 39);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = global::Inventory_management.Properties.Resources.cross_square_button;
            this.pictureBoxClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxClose.Location = new System.Drawing.Point(694, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(43, 39);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxClose.TabIndex = 13;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // UserName1
            // 
            this.UserName1.AutoSize = true;
            this.UserName1.Location = new System.Drawing.Point(41, 113);
            this.UserName1.Name = "UserName1";
            this.UserName1.Size = new System.Drawing.Size(157, 30);
            this.UserName1.TabIndex = 2;
            this.UserName1.Text = "User Name :";
            // 
            // FullName1
            // 
            this.FullName1.AutoSize = true;
            this.FullName1.Location = new System.Drawing.Point(41, 176);
            this.FullName1.Name = "FullName1";
            this.FullName1.Size = new System.Drawing.Size(147, 30);
            this.FullName1.TabIndex = 3;
            this.FullName1.Text = "Full Name :";
            // 
            // Password1
            // 
            this.Password1.AutoSize = true;
            this.Password1.Location = new System.Drawing.Point(52, 252);
            this.Password1.Name = "Password1";
            this.Password1.Size = new System.Drawing.Size(136, 30);
            this.Password1.TabIndex = 4;
            this.Password1.Text = "Password :";
            // 
            // Address1
            // 
            this.Address1.AutoSize = true;
            this.Address1.Location = new System.Drawing.Point(69, 316);
            this.Address1.Name = "Address1";
            this.Address1.Size = new System.Drawing.Size(119, 30);
            this.Address1.TabIndex = 5;
            this.Address1.Text = "Address :";
            // 
            // Phone1
            // 
            this.Phone1.AutoSize = true;
            this.Phone1.Location = new System.Drawing.Point(85, 384);
            this.Phone1.Name = "Phone1";
            this.Phone1.Size = new System.Drawing.Size(103, 30);
            this.Phone1.TabIndex = 6;
            this.Phone1.Text = "Phone :";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(204, 110);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(419, 37);
            this.UserName.TabIndex = 7;
            // 
            // FullName
            // 
            this.FullName.Location = new System.Drawing.Point(204, 176);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(419, 37);
            this.FullName.TabIndex = 8;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(204, 245);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(419, 37);
            this.Password.TabIndex = 9;
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(204, 309);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(419, 37);
            this.Address.TabIndex = 10;
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(204, 377);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(419, 37);
            this.Phone.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSalmon;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClear.Location = new System.Drawing.Point(600, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(118, 45);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SlateBlue;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdate.Location = new System.Drawing.Point(465, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 45);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(328, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 45);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 70);
            this.panel2.TabIndex = 1;
            // 
            // ModuleUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 522);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.FullName);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Phone1);
            this.Controls.Add(this.Address1);
            this.Controls.Add(this.Password1);
            this.Controls.Add(this.FullName1);
            this.Controls.Add(this.UserName1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.slidepanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "ModuleUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.slidepanel.ResumeLayout(false);
            this.slidepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel slidepanel;
        private System.Windows.Forms.PictureBox pictureBoxMinimize;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserName1;
        private System.Windows.Forms.Label FullName1;
        private System.Windows.Forms.Label Password1;
        private System.Windows.Forms.Label Address1;
        private System.Windows.Forms.Label Phone1;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox UserName;
        public System.Windows.Forms.TextBox FullName;
        public System.Windows.Forms.TextBox Password;
        public System.Windows.Forms.TextBox Address;
        public System.Windows.Forms.TextBox Phone;
    }
}