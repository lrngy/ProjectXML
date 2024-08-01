namespace QPharma.GUI
{
    partial class QuanLyNhanVienGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.t_id = new System.Windows.Forms.TextBox();
            this.t_staff_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.them = new System.Windows.Forms.Button();
            this.sua = new System.Windows.Forms.Button();
            this.xoa = new System.Windows.Forms.Button();
            this.save_add = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.staff_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_year_of_birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_is_manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_is_seller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_timKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.c_staff_is_manager = new System.Windows.Forms.RadioButton();
            this.c_staff_is_seller = new System.Windows.Forms.RadioButton();
            this.bResetPass = new System.Windows.Forms.Button();
            this.tTaiKhoan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.deleted_staffs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "id";
            // 
            // t_id
            // 
            this.t_id.Location = new System.Drawing.Point(208, 67);
            this.t_id.Margin = new System.Windows.Forms.Padding(2);
            this.t_id.Name = "t_id";
            this.t_id.Size = new System.Drawing.Size(139, 20);
            this.t_id.TabIndex = 2;
            // 
            // t_staff_name
            // 
            this.t_staff_name.Location = new System.Drawing.Point(488, 67);
            this.t_staff_name.Margin = new System.Windows.Forms.Padding(2);
            this.t_staff_name.Name = "t_staff_name";
            this.t_staff_name.Size = new System.Drawing.Size(138, 20);
            this.t_staff_name.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giới tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày sinh";
            // 
            // them
            // 
            this.them.Location = new System.Drawing.Point(104, 441);
            this.them.Margin = new System.Windows.Forms.Padding(2);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(61, 32);
            this.them.TabIndex = 12;
            this.them.Text = "Add";
            this.them.UseVisualStyleBackColor = true;
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // sua
            // 
            this.sua.Location = new System.Drawing.Point(303, 441);
            this.sua.Margin = new System.Windows.Forms.Padding(2);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(61, 32);
            this.sua.TabIndex = 13;
            this.sua.Text = "Update";
            this.sua.UseVisualStyleBackColor = true;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // xoa
            // 
            this.xoa.Location = new System.Drawing.Point(496, 441);
            this.xoa.Margin = new System.Windows.Forms.Padding(2);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(61, 32);
            this.xoa.TabIndex = 13;
            this.xoa.Text = "Delete";
            this.xoa.UseVisualStyleBackColor = true;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // save_add
            // 
            this.save_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.save_add.Location = new System.Drawing.Point(650, 414);
            this.save_add.Margin = new System.Windows.Forms.Padding(2);
            this.save_add.Name = "save_add";
            this.save_add.Size = new System.Drawing.Size(70, 40);
            this.save_add.TabIndex = 13;
            this.save_add.Text = "Save add";
            this.save_add.UseVisualStyleBackColor = true;
            this.save_add.Click += new System.EventHandler(this.save_add_Click);
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Back.Location = new System.Drawing.Point(650, 466);
            this.Back.Margin = new System.Windows.Forms.Padding(2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(70, 40);
            this.Back.TabIndex = 13;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.staff_id,
            this.staff_name,
            this.staff_username,
            this.staff_sex,
            this.staff_year_of_birth,
            this.staff_is_manager,
            this.staff_is_seller});
            this.dataGridView1.Location = new System.Drawing.Point(52, 220);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(686, 161);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // staff_id
            // 
            this.staff_id.HeaderText = "id";
            this.staff_id.MinimumWidth = 6;
            this.staff_id.Name = "staff_id";
            this.staff_id.Width = 40;
            // 
            // staff_name
            // 
            this.staff_name.HeaderText = "Tên nhân viên";
            this.staff_name.MinimumWidth = 6;
            this.staff_name.Name = "staff_name";
            this.staff_name.Width = 125;
            // 
            // staff_username
            // 
            this.staff_username.HeaderText = "Tài Khoản";
            this.staff_username.MinimumWidth = 6;
            this.staff_username.Name = "staff_username";
            this.staff_username.Width = 125;
            // 
            // staff_sex
            // 
            this.staff_sex.HeaderText = "Giới tính";
            this.staff_sex.MinimumWidth = 6;
            this.staff_sex.Name = "staff_sex";
            this.staff_sex.Width = 80;
            // 
            // staff_year_of_birth
            // 
            this.staff_year_of_birth.HeaderText = "Năm sinh";
            this.staff_year_of_birth.MinimumWidth = 6;
            this.staff_year_of_birth.Name = "staff_year_of_birth";
            this.staff_year_of_birth.Width = 80;
            // 
            // staff_is_manager
            // 
            this.staff_is_manager.HeaderText = "Quản Lý?";
            this.staff_is_manager.MinimumWidth = 6;
            this.staff_is_manager.Name = "staff_is_manager";
            this.staff_is_manager.Width = 90;
            // 
            // staff_is_seller
            // 
            this.staff_is_seller.HeaderText = "Bán hàng?";
            this.staff_is_seller.MinimumWidth = 6;
            this.staff_is_seller.Name = "staff_is_seller";
            this.staff_is_seller.Width = 90;
            // 
            // t_timKiem
            // 
            this.t_timKiem.Location = new System.Drawing.Point(354, 20);
            this.t_timKiem.Margin = new System.Windows.Forms.Padding(2);
            this.t_timKiem.Name = "t_timKiem";
            this.t_timKiem.Size = new System.Drawing.Size(139, 20);
            this.t_timKiem.TabIndex = 16;
            this.t_timKiem.TextChanged += new System.EventHandler(this.t_timKiem_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tìm kiếm";
            // 
            // c_staff_is_manager
            // 
            this.c_staff_is_manager.AutoSize = true;
            this.c_staff_is_manager.Location = new System.Drawing.Point(178, 185);
            this.c_staff_is_manager.Margin = new System.Windows.Forms.Padding(2);
            this.c_staff_is_manager.Name = "c_staff_is_manager";
            this.c_staff_is_manager.Size = new System.Drawing.Size(111, 17);
            this.c_staff_is_manager.TabIndex = 18;
            this.c_staff_is_manager.TabStop = true;
            this.c_staff_is_manager.Text = "Nhân viên quản lý";
            this.c_staff_is_manager.UseVisualStyleBackColor = true;
            // 
            // c_staff_is_seller
            // 
            this.c_staff_is_seller.AutoSize = true;
            this.c_staff_is_seller.Location = new System.Drawing.Point(478, 185);
            this.c_staff_is_seller.Margin = new System.Windows.Forms.Padding(2);
            this.c_staff_is_seller.Name = "c_staff_is_seller";
            this.c_staff_is_seller.Size = new System.Drawing.Size(122, 17);
            this.c_staff_is_seller.TabIndex = 19;
            this.c_staff_is_seller.TabStop = true;
            this.c_staff_is_seller.Text = "Nhân viên bán hàng";
            this.c_staff_is_seller.UseVisualStyleBackColor = true;
            // 
            // bResetPass
            // 
            this.bResetPass.Location = new System.Drawing.Point(504, 148);
            this.bResetPass.Margin = new System.Windows.Forms.Padding(2);
            this.bResetPass.Name = "bResetPass";
            this.bResetPass.Size = new System.Drawing.Size(102, 25);
            this.bResetPass.TabIndex = 20;
            this.bResetPass.Text = "Reset Password";
            this.bResetPass.UseVisualStyleBackColor = true;
            this.bResetPass.Click += new System.EventHandler(this.bResetPass_Click);
            // 
            // tTaiKhoan
            // 
            this.tTaiKhoan.Location = new System.Drawing.Point(208, 151);
            this.tTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.tTaiKhoan.Name = "tTaiKhoan";
            this.tTaiKhoan.Size = new System.Drawing.Size(138, 20);
            this.tTaiKhoan.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 151);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Tài khoản";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(488, 110);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 23;
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(208, 111);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(121, 21);
            this.cboGender.TabIndex = 24;
            // 
            // deleted_staffs
            // 
            this.deleted_staffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.deleted_staffs.Location = new System.Drawing.Point(629, 177);
            this.deleted_staffs.Margin = new System.Windows.Forms.Padding(2);
            this.deleted_staffs.Name = "deleted_staffs";
            this.deleted_staffs.Size = new System.Drawing.Size(109, 30);
            this.deleted_staffs.TabIndex = 13;
            this.deleted_staffs.Text = "Deleted Staffs";
            this.deleted_staffs.UseVisualStyleBackColor = true;
            this.deleted_staffs.Click += new System.EventHandler(this.deleted_staffs_Click);
            // 
            // QuanLyNhanVienGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 526);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tTaiKhoan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bResetPass);
            this.Controls.Add(this.c_staff_is_seller);
            this.Controls.Add(this.c_staff_is_manager);
            this.Controls.Add(this.t_timKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.deleted_staffs);
            this.Controls.Add(this.save_add);
            this.Controls.Add(this.xoa);
            this.Controls.Add(this.sua);
            this.Controls.Add(this.them);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.t_staff_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_id);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuanLyNhanVienGUI";
            this.Text = "Form Quản Lý Nhân Viên";
            this.Load += new System.EventHandler(this.QuanLyNhanVienForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t_id;
        private System.Windows.Forms.TextBox t_staff_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button them;
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Button save_add;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox t_timKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton c_staff_is_manager;
        private System.Windows.Forms.RadioButton c_staff_is_seller;
        private System.Windows.Forms.Button bResetPass;
        private System.Windows.Forms.TextBox tTaiKhoan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_year_of_birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_is_manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_is_seller;
        private System.Windows.Forms.Button deleted_staffs;
    }
}