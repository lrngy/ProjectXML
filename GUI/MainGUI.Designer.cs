using QPharma.Properties;

namespace QPharma.GUI
{
    partial class MainGUI
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainGUI));
            lbLogin = new Label();
            groupBox1 = new GroupBox();
            btnThongTin = new Button();
            btnNhanVien = new Button();
            btnNcc = new Button();
            btnDanhMuc = new Button();
            btnQlyThuoc = new Button();
            menuStrip1 = new MenuStrip();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            thuốcToolStripMenuItem = new ToolStripMenuItem();
            danhMụcThuốcToolStripMenuItem = new ToolStripMenuItem();
            nhàCungCấpToolStripMenuItem = new ToolStripMenuItem();
            nhânViênToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            tàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            cậpNhậtThôngTinToolStripMenuItem = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            trợGiúpToolStripMenuItem = new ToolStripMenuItem();
            thôngTinỨngDụngToolStripMenuItem = new ToolStripMenuItem();
            lbWelcome = new Label();
            groupBox2 = new GroupBox();
            btnLogout = new Button();
            btnChangePassword = new Button();
            lbDate = new Label();
            lbTime = new Label();
            toolStripMenuItem1 = new ToolStripMenuItem();
            btnHoaDon = new Button();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lbLogin
            // 
            lbLogin.AutoSize = true;
            lbLogin.BackColor = Color.White;
            lbLogin.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbLogin.Location = new Point(342, 56);
            lbLogin.Name = "lbLogin";
            lbLogin.Size = new Size(211, 32);
            lbLogin.TabIndex = 1;
            lbLogin.Text = "Quản lý hiệu thuốc";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnThongTin);
            groupBox1.Controls.Add(btnNhanVien);
            groupBox1.Controls.Add(btnNcc);
            groupBox1.Controls.Add(btnDanhMuc);
            groupBox1.Controls.Add(btnHoaDon);
            groupBox1.Controls.Add(btnQlyThuoc);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(47, 184);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(800, 296);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lựa chọn chức năng quản lý";
            // 
            // btnThongTin
            // 
            btnThongTin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThongTin.Image = (Image)resources.GetObject("btnThongTin.Image");
            btnThongTin.Location = new Point(552, 179);
            btnThongTin.Margin = new Padding(3, 4, 3, 4);
            btnThongTin.Name = "btnThongTin";
            btnThongTin.Size = new Size(230, 88);
            btnThongTin.TabIndex = 3;
            btnThongTin.Text = "Thông tin cá nhân";
            btnThongTin.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThongTin.UseVisualStyleBackColor = true;
            btnThongTin.Click += btnThongTin_Click;
            // 
            // btnNhanVien
            // 
            btnNhanVien.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhanVien.Image = (Image)resources.GetObject("btnNhanVien.Image");
            btnNhanVien.Location = new Point(288, 184);
            btnNhanVien.Margin = new Padding(3, 4, 3, 4);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(226, 83);
            btnNhanVien.TabIndex = 1;
            btnNhanVien.Text = Resources.Staff;
            btnNhanVien.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Click += btnNhanVien_Click;
            // 
            // btnNcc
            // 
            btnNcc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNcc.Image = (Image)resources.GetObject("btnNcc.Image");
            btnNcc.Location = new Point(552, 56);
            btnNcc.Margin = new Padding(3, 4, 3, 4);
            btnNcc.Name = "btnNcc";
            btnNcc.Size = new Size(230, 83);
            btnNcc.TabIndex = 0;
            btnNcc.Text = "Nhà cung cấp";
            btnNcc.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNcc.UseVisualStyleBackColor = true;
            btnNcc.Click += btnNcc_Click;
            // 
            // btnDanhMuc
            // 
            btnDanhMuc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDanhMuc.Image = (Image)resources.GetObject("btnDanhMuc.Image");
            btnDanhMuc.Location = new Point(288, 56);
            btnDanhMuc.Margin = new Padding(3, 4, 3, 4);
            btnDanhMuc.Name = "btnDanhMuc";
            btnDanhMuc.Size = new Size(229, 83);
            btnDanhMuc.TabIndex = 0;
            btnDanhMuc.Text = "Danh mục thuốc";
            btnDanhMuc.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDanhMuc.UseVisualStyleBackColor = true;
            btnDanhMuc.Click += btnDanhMuc_Click;
            // 
            // btnQlyThuoc
            // 
            btnQlyThuoc.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQlyThuoc.Image = (Image)resources.GetObject("btnQlyThuoc.Image");
            btnQlyThuoc.Location = new Point(26, 56);
            btnQlyThuoc.Margin = new Padding(3, 4, 3, 4);
            btnQlyThuoc.Name = "btnQlyThuoc";
            btnQlyThuoc.Size = new Size(226, 83);
            btnQlyThuoc.TabIndex = 0;
            btnQlyThuoc.Text = "Thuốc";
            btnQlyThuoc.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnQlyThuoc.UseVisualStyleBackColor = true;
            btnQlyThuoc.Click += btnQlyThuoc_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { quảnLýToolStripMenuItem, tàiKhoảnToolStripMenuItem, trợGiúpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1202, 25);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thuốcToolStripMenuItem, danhMụcThuốcToolStripMenuItem, nhàCungCấpToolStripMenuItem, nhânViênToolStripMenuItem, toolStripSeparator1, thoátToolStripMenuItem });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(67, 21);
            quảnLýToolStripMenuItem.Text = Resources.Manager;
            // 
            // thuốcToolStripMenuItem
            // 
            thuốcToolStripMenuItem.Name = "thuốcToolStripMenuItem";
            thuốcToolStripMenuItem.Size = new Size(177, 22);
            thuốcToolStripMenuItem.Text = "Thuốc";
            thuốcToolStripMenuItem.Click += thuốcToolStripMenuItem_Click;
            // 
            // danhMụcThuốcToolStripMenuItem
            // 
            danhMụcThuốcToolStripMenuItem.Name = "danhMụcThuốcToolStripMenuItem";
            danhMụcThuốcToolStripMenuItem.Size = new Size(177, 22);
            danhMụcThuốcToolStripMenuItem.Text = "Danh mục thuốc";
            danhMụcThuốcToolStripMenuItem.Click += danhMụcThuốcToolStripMenuItem_Click;
            // 
            // nhàCungCấpToolStripMenuItem
            // 
            nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            nhàCungCấpToolStripMenuItem.Size = new Size(177, 22);
            nhàCungCấpToolStripMenuItem.Text = "Nhà cung cấp";
            nhàCungCấpToolStripMenuItem.Click += nhàCungCấpToolStripMenuItem_Click;
            // 
            // nhânViênToolStripMenuItem
            // 
            nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            nhânViênToolStripMenuItem.Size = new Size(177, 22);
            nhânViênToolStripMenuItem.Text = Resources.Staff;
            nhânViênToolStripMenuItem.Click += nhânViênToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(174, 6);
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(177, 22);
            thoátToolStripMenuItem.Text = "Thoát";
            thoátToolStripMenuItem.Click += thoátToolStripMenuItem_Click;
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cậpNhậtThôngTinToolStripMenuItem, đổiMậtKhẩuToolStripMenuItem, đăngXuấtToolStripMenuItem });
            tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            tàiKhoảnToolStripMenuItem.Size = new Size(78, 21);
            tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // cậpNhậtThôngTinToolStripMenuItem
            // 
            cậpNhậtThôngTinToolStripMenuItem.Name = "cậpNhậtThôngTinToolStripMenuItem";
            cậpNhậtThôngTinToolStripMenuItem.Size = new Size(192, 22);
            cậpNhậtThôngTinToolStripMenuItem.Text = "Cập nhật thông tin";
            cậpNhậtThôngTinToolStripMenuItem.Click += cậpNhậtThôngTinToolStripMenuItem_Click;
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(192, 22);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            đổiMậtKhẩuToolStripMenuItem.Click += đổiMậtKhẩuToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(192, 22);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // trợGiúpToolStripMenuItem
            // 
            trợGiúpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinỨngDụngToolStripMenuItem });
            trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            trợGiúpToolStripMenuItem.Size = new Size(70, 21);
            trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // thôngTinỨngDụngToolStripMenuItem
            // 
            thôngTinỨngDụngToolStripMenuItem.Name = "thôngTinỨngDụngToolStripMenuItem";
            thôngTinỨngDụngToolStripMenuItem.Size = new Size(135, 22);
            thôngTinỨngDụngToolStripMenuItem.Text = "Thông tin";
            thôngTinỨngDụngToolStripMenuItem.Click += thôngTinỨngDụngToolStripMenuItem_Click;
            // 
            // lbWelcome
            // 
            lbWelcome.AutoEllipsis = true;
            lbWelcome.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbWelcome.Location = new Point(961, 56);
            lbWelcome.Name = "lbWelcome";
            lbWelcome.Size = new Size(227, 26);
            lbWelcome.TabIndex = 4;
            lbWelcome.Text = "Xin chào";
            lbWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(btnLogout);
            groupBox2.Controls.Add(btnChangePassword);
            groupBox2.ForeColor = SystemColors.ActiveCaptionText;
            groupBox2.Location = new Point(1013, 98);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(124, 107);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thao tác nhanh";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(7, 67);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(107, 26);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(7, 22);
            btnChangePassword.Margin = new Padding(3, 4, 3, 4);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(107, 26);
            btnChangePassword.TabIndex = 6;
            btnChangePassword.Text = "Đổi mật khẩu";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // lbDate
            // 
            lbDate.AutoEllipsis = true;
            lbDate.BackColor = Color.Transparent;
            lbDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDate.Location = new Point(44, 120);
            lbDate.Name = "lbDate";
            lbDate.Size = new Size(314, 26);
            lbDate.TabIndex = 4;
            lbDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbTime
            // 
            lbTime.AutoEllipsis = true;
            lbTime.BackColor = Color.Transparent;
            lbTime.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTime.Location = new Point(65, 143);
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(227, 26);
            lbTime.TabIndex = 4;
            lbTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(122, 20);
            // 
            // btnHoaDon
            // 
            btnHoaDon.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHoaDon.Image = Resources.bill__1_;
            btnHoaDon.Location = new Point(26, 184);
            btnHoaDon.Margin = new Padding(3, 4, 3, 4);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(226, 83);
            btnHoaDon.TabIndex = 0;
            btnHoaDon.Text = "Hoá đơn";
            btnHoaDon.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHoaDon.UseVisualStyleBackColor = true;
            btnHoaDon.Click += btnHoaDon_Click;
            // 
            // MainGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resources.MainBackgroundImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1202, 680);
            Controls.Add(groupBox2);
            Controls.Add(lbTime);
            Controls.Add(lbDate);
            Controls.Add(lbWelcome);
            Controls.Add(groupBox1);
            Controls.Add(lbLogin);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainGUI";
            Text = "Q-Pharma - TỔNG QUAN";
            FormClosing += MainGUI_FormClosing;
            FormClosed += MainGUI_FormClosed;
            Load += MainView_Load;
            groupBox1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQlyThuoc;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnNcc;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnThongTin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thuốcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcThuốcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtThôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinỨngDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Button btnHoaDon;
    }
}