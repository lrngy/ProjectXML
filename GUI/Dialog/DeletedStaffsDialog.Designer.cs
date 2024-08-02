namespace QPharma.GUI.Dialog
{
    partial class DeletedStaffsDialog
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.deleteForeverBtn = new System.Windows.Forms.Button();
            this.restoreBtn = new System.Windows.Forms.Button();
            this.deleteForeverAllBtn = new System.Windows.Forms.Button();
            this.restoreAllBtn = new System.Windows.Forms.Button();
            this.staff_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_year_of_birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_is_manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staff_is_seller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(73, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(655, 188);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // deleteForeverBtn
            // 
            this.deleteForeverBtn.Location = new System.Drawing.Point(411, 294);
            this.deleteForeverBtn.Name = "deleteForeverBtn";
            this.deleteForeverBtn.Size = new System.Drawing.Size(117, 37);
            this.deleteForeverBtn.TabIndex = 1;
            this.deleteForeverBtn.Text = "Delete Forever";
            this.deleteForeverBtn.UseVisualStyleBackColor = true;
            this.deleteForeverBtn.Click += new System.EventHandler(this.deleteForeverBtn_Click);
            // 
            // restoreBtn
            // 
            this.restoreBtn.Location = new System.Drawing.Point(115, 294);
            this.restoreBtn.Name = "restoreBtn";
            this.restoreBtn.Size = new System.Drawing.Size(86, 37);
            this.restoreBtn.TabIndex = 1;
            this.restoreBtn.Text = "Restore";
            this.restoreBtn.UseVisualStyleBackColor = true;
            this.restoreBtn.Click += new System.EventHandler(this.restoreBtn_Click);
            // 
            // deleteForeverAllBtn
            // 
            this.deleteForeverAllBtn.Location = new System.Drawing.Point(589, 294);
            this.deleteForeverAllBtn.Name = "deleteForeverAllBtn";
            this.deleteForeverAllBtn.Size = new System.Drawing.Size(115, 37);
            this.deleteForeverAllBtn.TabIndex = 1;
            this.deleteForeverAllBtn.Text = "Delete Forever All";
            this.deleteForeverAllBtn.UseVisualStyleBackColor = true;
            this.deleteForeverAllBtn.Click += new System.EventHandler(this.deleteForeverAllBtn_Click);
            // 
            // restoreAllBtn
            // 
            this.restoreAllBtn.Location = new System.Drawing.Point(255, 294);
            this.restoreAllBtn.Name = "restoreAllBtn";
            this.restoreAllBtn.Size = new System.Drawing.Size(86, 37);
            this.restoreAllBtn.TabIndex = 1;
            this.restoreAllBtn.Text = "Restore All";
            this.restoreAllBtn.UseVisualStyleBackColor = true;
            this.restoreAllBtn.Click += new System.EventHandler(this.restoreAllBtn_Click);
            // 
            // staff_id
            // 
            this.staff_id.HeaderText = "id";
            this.staff_id.Name = "staff_id";
            // 
            // staff_name
            // 
            this.staff_name.HeaderText = "Tên nhân viên";
            this.staff_name.Name = "staff_name";
            // 
            // staff_username
            // 
            this.staff_username.HeaderText = "Tài Khoản";
            this.staff_username.Name = "staff_username";
            // 
            // staff_sex
            // 
            this.staff_sex.HeaderText = "Giới tính";
            this.staff_sex.Name = "staff_sex";
            // 
            // staff_year_of_birth
            // 
            this.staff_year_of_birth.HeaderText = "Năm sinh";
            this.staff_year_of_birth.Name = "staff_year_of_birth";
            // 
            // staff_is_manager
            // 
            this.staff_is_manager.HeaderText = "Quản Lý?";
            this.staff_is_manager.Name = "staff_is_manager";
            // 
            // staff_is_seller
            // 
            this.staff_is_seller.HeaderText = "Bán hàng?";
            this.staff_is_seller.Name = "staff_is_seller";
            // 
            // DeletedStaffsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.restoreAllBtn);
            this.Controls.Add(this.deleteForeverAllBtn);
            this.Controls.Add(this.restoreBtn);
            this.Controls.Add(this.deleteForeverBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DeletedStaffsDialog";
            this.Text = "Nhân viên đã xóa";
            this.Load += new System.EventHandler(this.DeletedStaffsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteForeverBtn;
        private System.Windows.Forms.Button restoreBtn;
        private System.Windows.Forms.Button deleteForeverAllBtn;
        private System.Windows.Forms.Button restoreAllBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_year_of_birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_is_manager;
        private System.Windows.Forms.DataGridViewTextBoxColumn staff_is_seller;
    }
}