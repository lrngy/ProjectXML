namespace ProjectXML.View.Dialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNhapKT = new System.Windows.Forms.DateTimePicker();
            this.dtpNhapBD = new System.Windows.Forms.DateTimePicker();
            this.tbGiaKT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGiaBD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpHanBD = new System.Windows.Forms.DateTimePicker();
            this.dtpHanKT = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSLBD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSLKT = new System.Windows.Forms.TextBox();
            this.ckbGia = new System.Windows.Forms.CheckBox();
            this.ckbSL = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.ckbNgayNhap = new System.Windows.Forms.CheckBox();
            this.ckbNgayHetHan = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbNgayHetHan);
            this.groupBox1.Controls.Add(this.ckbNgayNhap);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.ckbSL);
            this.groupBox1.Controls.Add(this.ckbGia);
            this.groupBox1.Controls.Add(this.dtpHanKT);
            this.groupBox1.Controls.Add(this.dtpNhapKT);
            this.groupBox1.Controls.Add(this.dtpHanBD);
            this.groupBox1.Controls.Add(this.dtpNhapBD);
            this.groupBox1.Controls.Add(this.tbSLKT);
            this.groupBox1.Controls.Add(this.tbGiaKT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbSLBD);
            this.groupBox1.Controls.Add(this.tbGiaBD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(33, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc theo khoảng";
            // 
            // dtpNhapKT
            // 
            this.dtpNhapKT.CustomFormat = "dd-MM-yyyy";
            this.dtpNhapKT.Enabled = false;
            this.dtpNhapKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNhapKT.Location = new System.Drawing.Point(418, 167);
            this.dtpNhapKT.Name = "dtpNhapKT";
            this.dtpNhapKT.Size = new System.Drawing.Size(100, 25);
            this.dtpNhapKT.TabIndex = 2;
            // 
            // dtpNhapBD
            // 
            this.dtpNhapBD.CustomFormat = "dd-MM-yyyy";
            this.dtpNhapBD.Enabled = false;
            this.dtpNhapBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNhapBD.Location = new System.Drawing.Point(234, 167);
            this.dtpNhapBD.Name = "dtpNhapBD";
            this.dtpNhapBD.Size = new System.Drawing.Size(100, 25);
            this.dtpNhapBD.TabIndex = 1;
            // 
            // tbGiaKT
            // 
            this.tbGiaKT.Location = new System.Drawing.Point(418, 43);
            this.tbGiaKT.Name = "tbGiaKT";
            this.tbGiaKT.Size = new System.Drawing.Size(100, 25);
            this.tbGiaKT.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến";
            // 
            // tbGiaBD
            // 
            this.tbGiaBD.Location = new System.Drawing.Point(234, 42);
            this.tbGiaBD.Name = "tbGiaBD";
            this.tbGiaBD.Size = new System.Drawing.Size(100, 25);
            this.tbGiaBD.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ";
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(164, 332);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(140, 30);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "Lọc dữ liệu";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(362, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Từ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "đến";
            // 
            // dtpHanBD
            // 
            this.dtpHanBD.CustomFormat = "dd-MM-yyyy";
            this.dtpHanBD.Enabled = false;
            this.dtpHanBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanBD.Location = new System.Drawing.Point(234, 231);
            this.dtpHanBD.Name = "dtpHanBD";
            this.dtpHanBD.Size = new System.Drawing.Size(100, 25);
            this.dtpHanBD.TabIndex = 1;
            // 
            // dtpHanKT
            // 
            this.dtpHanKT.CustomFormat = "dd-MM-yyyy";
            this.dtpHanKT.Enabled = false;
            this.dtpHanKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanKT.Location = new System.Drawing.Point(418, 231);
            this.dtpHanKT.Name = "dtpHanKT";
            this.dtpHanKT.Size = new System.Drawing.Size(100, 25);
            this.dtpHanKT.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Từ";
            // 
            // tbSLBD
            // 
            this.tbSLBD.Location = new System.Drawing.Point(234, 100);
            this.tbSLBD.Name = "tbSLBD";
            this.tbSLBD.Size = new System.Drawing.Size(100, 25);
            this.tbSLBD.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "đến";
            // 
            // tbSLKT
            // 
            this.tbSLKT.Location = new System.Drawing.Point(418, 101);
            this.tbSLKT.Name = "tbSLKT";
            this.tbSLKT.Size = new System.Drawing.Size(100, 25);
            this.tbSLKT.TabIndex = 2;
            // 
            // ckbGia
            // 
            this.ckbGia.AutoSize = true;
            this.ckbGia.Location = new System.Drawing.Point(36, 47);
            this.ckbGia.Name = "ckbGia";
            this.ckbGia.Size = new System.Drawing.Size(79, 21);
            this.ckbGia.TabIndex = 0;
            this.ckbGia.Text = "Theo giá";
            this.ckbGia.UseVisualStyleBackColor = true;
            this.ckbGia.CheckedChanged += new System.EventHandler(this.ckbGia_CheckedChanged_1);
            // 
            // ckbSL
            // 
            this.ckbSL.AutoSize = true;
            this.ckbSL.Location = new System.Drawing.Point(36, 104);
            this.ckbSL.Name = "ckbSL";
            this.ckbSL.Size = new System.Drawing.Size(114, 21);
            this.ckbSL.TabIndex = 0;
            this.ckbSL.Text = "Theo số lượng";
            this.ckbSL.UseVisualStyleBackColor = true;
            this.ckbSL.CheckedChanged += new System.EventHandler(this.ckbSL_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(36, 170);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(114, 21);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "Theo số lượng";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // ckbNgayNhap
            // 
            this.ckbNgayNhap.AutoSize = true;
            this.ckbNgayNhap.Location = new System.Drawing.Point(36, 167);
            this.ckbNgayNhap.Name = "ckbNgayNhap";
            this.ckbNgayNhap.Size = new System.Drawing.Size(126, 21);
            this.ckbNgayNhap.TabIndex = 0;
            this.ckbNgayNhap.Text = "Theo ngày nhập";
            this.ckbNgayNhap.UseVisualStyleBackColor = true;
            this.ckbNgayNhap.CheckedChanged += new System.EventHandler(this.ckbNgayNhap_CheckedChanged);
            // 
            // ckbNgayHetHan
            // 
            this.ckbNgayHetHan.AutoSize = true;
            this.ckbNgayHetHan.Location = new System.Drawing.Point(36, 235);
            this.ckbNgayHetHan.Name = "ckbNgayHetHan";
            this.ckbNgayHetHan.Size = new System.Drawing.Size(142, 21);
            this.ckbNgayHetHan.TabIndex = 0;
            this.ckbNgayHetHan.Text = "Theo ngày hết hạn";
            this.ckbNgayHetHan.UseVisualStyleBackColor = true;
            this.ckbNgayHetHan.CheckedChanged += new System.EventHandler(this.ckbNgayHetHan_CheckedChanged);
            // 
            // FilterByRangeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 381);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.groupBox1);
            this.Name = "FilterByRangeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lọc theo khoảng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox ckbSL;
        private System.Windows.Forms.CheckBox ckbGia;
    }
}