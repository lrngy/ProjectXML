namespace ProjectXML.View
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.lbLogin = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQlyTaiChinh = new System.Windows.Forms.Button();
            this.btnQlyHoaDon = new System.Windows.Forms.Button();
            this.btnQlyNhanVien = new System.Windows.Forms.Button();
            this.btnQlyThuoc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.BackColor = System.Drawing.Color.White;
            this.lbLogin.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogin.Location = new System.Drawing.Point(250, 43);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(187, 30);
            this.lbLogin.TabIndex = 1;
            this.lbLogin.Text = "Quản lý hiệu thuốc";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnQlyTaiChinh);
            this.groupBox1.Controls.Add(this.btnQlyHoaDon);
            this.groupBox1.Controls.Add(this.btnQlyNhanVien);
            this.groupBox1.Controls.Add(this.btnQlyThuoc);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(122, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(494, 378);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lựa chọn chức năng";
            // 
            // btnQlyTaiChinh
            // 
            this.btnQlyTaiChinh.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlyTaiChinh.Image = ((System.Drawing.Image)(resources.GetObject("btnQlyTaiChinh.Image")));
            this.btnQlyTaiChinh.Location = new System.Drawing.Point(248, 218);
            this.btnQlyTaiChinh.Name = "btnQlyTaiChinh";
            this.btnQlyTaiChinh.Size = new System.Drawing.Size(220, 148);
            this.btnQlyTaiChinh.TabIndex = 3;
            this.btnQlyTaiChinh.Text = "Quản lý tài chính";
            this.btnQlyTaiChinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQlyTaiChinh.UseVisualStyleBackColor = true;
            // 
            // btnQlyHoaDon
            // 
            this.btnQlyHoaDon.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlyHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnQlyHoaDon.Image")));
            this.btnQlyHoaDon.Location = new System.Drawing.Point(22, 218);
            this.btnQlyHoaDon.Name = "btnQlyHoaDon";
            this.btnQlyHoaDon.Size = new System.Drawing.Size(207, 148);
            this.btnQlyHoaDon.TabIndex = 2;
            this.btnQlyHoaDon.Text = "Quản lý hoá đơn";
            this.btnQlyHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQlyHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnQlyNhanVien
            // 
            this.btnQlyNhanVien.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlyNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnQlyNhanVien.Image")));
            this.btnQlyNhanVien.Location = new System.Drawing.Point(248, 48);
            this.btnQlyNhanVien.Name = "btnQlyNhanVien";
            this.btnQlyNhanVien.Size = new System.Drawing.Size(213, 148);
            this.btnQlyNhanVien.TabIndex = 1;
            this.btnQlyNhanVien.Text = "Quản lý nhân viên";
            this.btnQlyNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQlyNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnQlyThuoc
            // 
            this.btnQlyThuoc.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlyThuoc.Image = ((System.Drawing.Image)(resources.GetObject("btnQlyThuoc.Image")));
            this.btnQlyThuoc.Location = new System.Drawing.Point(22, 48);
            this.btnQlyThuoc.Name = "btnQlyThuoc";
            this.btnQlyThuoc.Size = new System.Drawing.Size(207, 148);
            this.btnQlyThuoc.TabIndex = 0;
            this.btnQlyThuoc.Text = "Quản lý thuốc";
            this.btnQlyThuoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQlyThuoc.UseVisualStyleBackColor = true;
            this.btnQlyThuoc.Click += new System.EventHandler(this.btnQlyThuoc_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1031, 589);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ HIỆU THUỐC - TỔNG QUAN";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQlyThuoc;
        private System.Windows.Forms.Button btnQlyHoaDon;
        private System.Windows.Forms.Button btnQlyTaiChinh;
        private System.Windows.Forms.Button btnQlyNhanVien;
    }
}