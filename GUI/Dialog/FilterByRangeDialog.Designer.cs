namespace QPharma.GUI.Dialog
{
    partial class FilterByRangeDialog
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
            groupBox1 = new GroupBox();
            ckbNgayHetHan = new CheckBox();
            ckbNgayNhap = new CheckBox();
            ckbSL = new CheckBox();
            ckbGia = new CheckBox();
            dtpHanKT = new DateTimePicker();
            dtpNhapKT = new DateTimePicker();
            dtpHanBD = new DateTimePicker();
            dtpNhapBD = new DateTimePicker();
            tbSLKT = new TextBox();
            tbGiaKT = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label8 = new Label();
            label2 = new Label();
            tbSLBD = new TextBox();
            tbGiaBD = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label7 = new Label();
            label1 = new Label();
            btnFilter = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ckbNgayHetHan);
            groupBox1.Controls.Add(ckbNgayNhap);
            groupBox1.Controls.Add(ckbSL);
            groupBox1.Controls.Add(ckbGia);
            groupBox1.Controls.Add(dtpHanKT);
            groupBox1.Controls.Add(dtpNhapKT);
            groupBox1.Controls.Add(dtpHanBD);
            groupBox1.Controls.Add(dtpNhapBD);
            groupBox1.Controls.Add(tbSLKT);
            groupBox1.Controls.Add(tbGiaKT);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbSLBD);
            groupBox1.Controls.Add(tbGiaBD);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(55, 46);
            groupBox1.Margin = new Padding(5, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 6, 5, 6);
            groupBox1.Size = new Size(925, 558);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lọc theo khoảng";
            // 
            // ckbNgayHetHan
            // 
            ckbNgayHetHan.AutoSize = true;
            ckbNgayHetHan.Location = new Point(60, 452);
            ckbNgayHetHan.Margin = new Padding(5, 6, 5, 6);
            ckbNgayHetHan.Name = "ckbNgayHetHan";
            ckbNgayHetHan.Size = new Size(210, 32);
            ckbNgayHetHan.TabIndex = 0;
            ckbNgayHetHan.Text = "Theo ngày hết hạn";
            ckbNgayHetHan.UseVisualStyleBackColor = true;
            ckbNgayHetHan.CheckedChanged += ckbNgayHetHan_CheckedChanged;
            // 
            // ckbNgayNhap
            // 
            ckbNgayNhap.AutoSize = true;
            ckbNgayNhap.Location = new Point(60, 324);
            ckbNgayNhap.Margin = new Padding(5, 6, 5, 6);
            ckbNgayNhap.Name = "ckbNgayNhap";
            ckbNgayNhap.Size = new Size(186, 32);
            ckbNgayNhap.TabIndex = 0;
            ckbNgayNhap.Text = "Theo ngày nhập";
            ckbNgayNhap.UseVisualStyleBackColor = true;
            ckbNgayNhap.CheckedChanged += ckbNgayNhap_CheckedChanged;
            // 
            // ckbSL
            // 
            ckbSL.AutoSize = true;
            ckbSL.Location = new Point(60, 200);
            ckbSL.Margin = new Padding(5, 6, 5, 6);
            ckbSL.Name = "ckbSL";
            ckbSL.Size = new Size(170, 32);
            ckbSL.TabIndex = 0;
            ckbSL.Text = "Theo số lượng";
            ckbSL.UseVisualStyleBackColor = true;
            ckbSL.CheckedChanged += ckbSL_CheckedChanged;
            // 
            // ckbGia
            // 
            ckbGia.AutoSize = true;
            ckbGia.Location = new Point(60, 90);
            ckbGia.Margin = new Padding(5, 6, 5, 6);
            ckbGia.Name = "ckbGia";
            ckbGia.Size = new Size(157, 32);
            ckbGia.TabIndex = 0;
            ckbGia.Text = "Theo giá bán";
            ckbGia.UseVisualStyleBackColor = true;
            ckbGia.CheckedChanged += ckbGia_CheckedChanged_1;
            // 
            // dtpHanKT
            // 
            dtpHanKT.CustomFormat = "dd/MM/yyyy";
            dtpHanKT.Enabled = false;
            dtpHanKT.Format = DateTimePickerFormat.Custom;
            dtpHanKT.Location = new Point(697, 444);
            dtpHanKT.Margin = new Padding(5, 6, 5, 6);
            dtpHanKT.Name = "dtpHanKT";
            dtpHanKT.Size = new Size(164, 33);
            dtpHanKT.TabIndex = 2;
            // 
            // dtpNhapKT
            // 
            dtpNhapKT.CustomFormat = "dd/MM/yyyy";
            dtpNhapKT.Enabled = false;
            dtpNhapKT.Format = DateTimePickerFormat.Custom;
            dtpNhapKT.Location = new Point(697, 321);
            dtpNhapKT.Margin = new Padding(5, 6, 5, 6);
            dtpNhapKT.Name = "dtpNhapKT";
            dtpNhapKT.Size = new Size(164, 33);
            dtpNhapKT.TabIndex = 2;
            // 
            // dtpHanBD
            // 
            dtpHanBD.CustomFormat = "dd/MM/yyyy";
            dtpHanBD.Enabled = false;
            dtpHanBD.Format = DateTimePickerFormat.Custom;
            dtpHanBD.Location = new Point(390, 444);
            dtpHanBD.Margin = new Padding(5, 6, 5, 6);
            dtpHanBD.Name = "dtpHanBD";
            dtpHanBD.Size = new Size(164, 33);
            dtpHanBD.TabIndex = 1;
            // 
            // dtpNhapBD
            // 
            dtpNhapBD.CustomFormat = "dd/MM/yyyy";
            dtpNhapBD.Enabled = false;
            dtpNhapBD.Format = DateTimePickerFormat.Custom;
            dtpNhapBD.Location = new Point(390, 321);
            dtpNhapBD.Margin = new Padding(5, 6, 5, 6);
            dtpNhapBD.Name = "dtpNhapBD";
            dtpNhapBD.Size = new Size(164, 33);
            dtpNhapBD.TabIndex = 1;
            // 
            // tbSLKT
            // 
            tbSLKT.Location = new Point(697, 194);
            tbSLKT.Margin = new Padding(5, 6, 5, 6);
            tbSLKT.Name = "tbSLKT";
            tbSLKT.Size = new Size(164, 33);
            tbSLKT.TabIndex = 2;
            // 
            // tbGiaKT
            // 
            tbGiaKT.Location = new Point(697, 83);
            tbGiaKT.Margin = new Padding(5, 6, 5, 6);
            tbGiaKT.Name = "tbGiaKT";
            tbGiaKT.Size = new Size(164, 33);
            tbGiaKT.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(635, 452);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(47, 28);
            label6.TabIndex = 1;
            label6.Text = "đến";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(635, 329);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(47, 28);
            label4.TabIndex = 1;
            label4.Text = "đến";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(635, 200);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(47, 28);
            label8.TabIndex = 1;
            label8.Text = "đến";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(635, 88);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 28);
            label2.TabIndex = 1;
            label2.Text = "đến";
            // 
            // tbSLBD
            // 
            tbSLBD.Location = new Point(390, 192);
            tbSLBD.Margin = new Padding(5, 6, 5, 6);
            tbSLBD.Name = "tbSLBD";
            tbSLBD.Size = new Size(164, 33);
            tbSLBD.TabIndex = 1;
            // 
            // tbGiaBD
            // 
            tbGiaBD.Location = new Point(390, 81);
            tbGiaBD.Margin = new Padding(5, 6, 5, 6);
            tbGiaBD.Name = "tbGiaBD";
            tbGiaBD.Size = new Size(164, 33);
            tbGiaBD.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(342, 452);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(35, 28);
            label5.TabIndex = 1;
            label5.Text = "Từ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 329);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(35, 28);
            label3.TabIndex = 1;
            label3.Text = "Từ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(342, 200);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(35, 28);
            label7.TabIndex = 1;
            label7.Text = "Từ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(342, 88);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(35, 28);
            label1.TabIndex = 1;
            label1.Text = "Từ";
            // 
            // btnFilter
            // 
            btnFilter.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilter.Location = new Point(273, 638);
            btnFilter.Margin = new Padding(5, 6, 5, 6);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(233, 58);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Lọc dữ liệu";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += button1_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(603, 638);
            btnCancel.Margin = new Padding(5, 6, 5, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 58);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Huỷ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += button2_Click;
            // 
            // FilterByRangeDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1050, 733);
            Controls.Add(btnCancel);
            Controls.Add(btnFilter);
            Controls.Add(groupBox1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FilterByRangeDialog";
            Text = "Lọc theo khoảng";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpNhapKT;
        private System.Windows.Forms.DateTimePicker dtpNhapBD;
        private System.Windows.Forms.TextBox tbGiaKT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGiaBD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnFilter;
        public System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpHanKT;
        private System.Windows.Forms.DateTimePicker dtpHanBD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSLKT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSLBD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ckbNgayHetHan;
        private System.Windows.Forms.CheckBox ckbNgayNhap;
        private System.Windows.Forms.CheckBox ckbSL;
        private System.Windows.Forms.CheckBox ckbGia;
    }
}