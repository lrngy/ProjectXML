namespace ProjectXML.View
{
    partial class QuanLyNhanVienForm
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
            this.t_staff_sex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_staff_year_of_birth = new System.Windows.Forms.TextBox();
            this.c_staff_is_manager = new System.Windows.Forms.CheckBox();
            this.c_staff_is_seller = new System.Windows.Forms.CheckBox();
            this.them = new System.Windows.Forms.Button();
            this.sua = new System.Windows.Forms.Button();
            this.xoa = new System.Windows.Forms.Button();
            this.save_update = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.staff_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_year_of_birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_is_manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_is_seller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_timKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "id";
            // 
            // t_id
            // 
            this.t_id.Location = new System.Drawing.Point(231, 82);
            this.t_id.Name = "t_id";
            this.t_id.Size = new System.Drawing.Size(184, 22);
            this.t_id.TabIndex = 2;
            // 
            // t_staff_name
            // 
            this.t_staff_name.Location = new System.Drawing.Point(651, 82);
            this.t_staff_name.Name = "t_staff_name";
            this.t_staff_name.Size = new System.Drawing.Size(183, 22);
            this.t_staff_name.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giới tính";
            // 
            // t_staff_sex
            // 
            this.t_staff_sex.Location = new System.Drawing.Point(231, 137);
            this.t_staff_sex.Name = "t_staff_sex";
            this.t_staff_sex.Size = new System.Drawing.Size(184, 22);
            this.t_staff_sex.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Năm sinh";
            // 
            // t_staff_year_of_birth
            // 
            this.t_staff_year_of_birth.Location = new System.Drawing.Point(651, 137);
            this.t_staff_year_of_birth.Name = "t_staff_year_of_birth";
            this.t_staff_year_of_birth.Size = new System.Drawing.Size(183, 22);
            this.t_staff_year_of_birth.TabIndex = 9;
            // 
            // c_staff_is_manager
            // 
            this.c_staff_is_manager.AutoSize = true;
            this.c_staff_is_manager.Location = new System.Drawing.Point(186, 187);
            this.c_staff_is_manager.Name = "c_staff_is_manager";
            this.c_staff_is_manager.Size = new System.Drawing.Size(135, 20);
            this.c_staff_is_manager.TabIndex = 10;
            this.c_staff_is_manager.Text = "Nhân viên quản lý";
            this.c_staff_is_manager.UseVisualStyleBackColor = true;
            // 
            // c_staff_is_seller
            // 
            this.c_staff_is_seller.AutoSize = true;
            this.c_staff_is_seller.Location = new System.Drawing.Point(571, 187);
            this.c_staff_is_seller.Name = "c_staff_is_seller";
            this.c_staff_is_seller.Size = new System.Drawing.Size(148, 20);
            this.c_staff_is_seller.TabIndex = 11;
            this.c_staff_is_seller.Text = "Nhân viên bán hàng";
            this.c_staff_is_seller.UseVisualStyleBackColor = true;
            // 
            // them
            // 
            this.them.Location = new System.Drawing.Point(141, 496);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(81, 39);
            this.them.TabIndex = 12;
            this.them.Text = "Thêm";
            this.them.UseVisualStyleBackColor = true;
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // sua
            // 
            this.sua.Location = new System.Drawing.Point(407, 496);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(81, 39);
            this.sua.TabIndex = 13;
            this.sua.Text = "Sửa";
            this.sua.UseVisualStyleBackColor = true;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // xoa
            // 
            this.xoa.Location = new System.Drawing.Point(664, 496);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(81, 39);
            this.xoa.TabIndex = 13;
            this.xoa.Text = "Xóa";
            this.xoa.UseVisualStyleBackColor = true;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // save_update
            // 
            this.save_update.Location = new System.Drawing.Point(870, 462);
            this.save_update.Name = "save_update";
            this.save_update.Size = new System.Drawing.Size(94, 49);
            this.save_update.TabIndex = 13;
            this.save_update.Text = "Save update";
            this.save_update.UseVisualStyleBackColor = true;
            this.save_update.Click += new System.EventHandler(this.save_update_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(870, 526);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(94, 49);
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
            this.staff_sex,
            this.staff_year_of_birth,
            this.staff_is_manager,
            this.staff_is_seller});
            this.dataGridView1.Location = new System.Drawing.Point(62, 241);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(914, 198);
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
            this.t_timKiem.Location = new System.Drawing.Point(472, 25);
            this.t_timKiem.Name = "t_timKiem";
            this.t_timKiem.Size = new System.Drawing.Size(184, 22);
            this.t_timKiem.TabIndex = 16;
            this.t_timKiem.TextChanged += new System.EventHandler(this.t_timKiem_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tìm kiếm";
            // 
            // QuanLyNhanVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 588);
            this.Controls.Add(this.t_timKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.save_update);
            this.Controls.Add(this.xoa);
            this.Controls.Add(this.sua);
            this.Controls.Add(this.them);
            this.Controls.Add(this.c_staff_is_seller);
            this.Controls.Add(this.c_staff_is_manager);
            this.Controls.Add(this.t_staff_year_of_birth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.t_staff_sex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.t_staff_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_id);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyNhanVienForm";
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
        private System.Windows.Forms.TextBox t_staff_sex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox t_staff_year_of_birth;
        private System.Windows.Forms.CheckBox c_staff_is_manager;
        private System.Windows.Forms.CheckBox c_staff_is_seller;
        private System.Windows.Forms.Button them;
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Button save_update;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_year_of_birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_is_manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_is_seller;
        private System.Windows.Forms.TextBox t_timKiem;
        private System.Windows.Forms.Label label5;
    }
}