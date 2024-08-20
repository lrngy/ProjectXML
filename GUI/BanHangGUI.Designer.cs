namespace QPharma.GUI
{
    partial class BanHangGUI
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
            components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel9 = new TableLayoutPanel();
            label2 = new Label();
            dgvMedicine = new DataGridView();
            Column7 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            tableLayoutPanel2 = new TableLayoutPanel();
            dgvMedicineBill = new DataGridView();
            Column11 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewButtonColumn();
            tableLayoutPanel3 = new TableLayoutPanel();
            lbTrangThai = new Label();
            lbHeading = new Label();
            lbDate = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnSave = new Button();
            btnThanhToan = new Button();
            tableLayoutPanel14 = new TableLayoutPanel();
            label9 = new Label();
            lbTienTraLai = new Label();
            tableLayoutPanel13 = new TableLayoutPanel();
            label8 = new Label();
            numKhachDua = new NumericUpDown();
            tableLayoutPanel12 = new TableLayoutPanel();
            label7 = new Label();
            lbSoTien = new Label();
            tableLayoutPanel8 = new TableLayoutPanel();
            label4 = new Label();
            tbGhiChu = new TextBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            label3 = new Label();
            tbBacSi = new TextBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            label5 = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            cbbKhachHang = new ComboBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCancel = new Button();
            tableLayoutPanel11 = new TableLayoutPanel();
            tableLayoutPanel15 = new TableLayoutPanel();
            tableLayoutPanel10 = new TableLayoutPanel();
            btnAddToSellBill = new Button();
            toolTip1 = new ToolTip(components);
            errorProvider1 = new ErrorProvider(components);
            tableLayoutPanel9.SuspendLayout();
            ((ISupportInitialize)dgvMedicine).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((ISupportInitialize)dgvMedicineBill).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tableLayoutPanel14.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            ((ISupportInitialize)numKhachDua).BeginInit();
            tableLayoutPanel12.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            tableLayoutPanel15.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            ((ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 1;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Controls.Add(label2, 0, 0);
            tableLayoutPanel9.Controls.Add(dgvMedicine, 0, 1);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(3, 3);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 9.67742F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 90.32258F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel9.Size = new Size(570, 287);
            tableLayoutPanel9.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(564, 27);
            label2.TabIndex = 1;
            label2.Text = "Thuốc đang có sẵn";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvMedicine
            // 
            dgvMedicine.AllowUserToAddRows = false;
            dgvMedicine.AllowUserToDeleteRows = false;
            dgvMedicine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicine.Columns.AddRange(new DataGridViewColumn[] { Column7, Column14, Column8, Column12, Column9, Column10, Column13 });
            dgvMedicine.Dock = DockStyle.Fill;
            dgvMedicine.Location = new Point(3, 30);
            dgvMedicine.MultiSelect = false;
            dgvMedicine.Name = "dgvMedicine";
            dgvMedicine.ReadOnly = true;
            dgvMedicine.RowHeadersVisible = false;
            dgvMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicine.Size = new Size(564, 254);
            dgvMedicine.TabIndex = 0;
            // 
            // Column7
            // 
            Column7.FillWeight = 50F;
            Column7.HeaderText = "STT";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column14
            // 
            Column14.HeaderText = "Mã thuốc";
            Column14.Name = "Column14";
            Column14.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.HeaderText = "Tên thuốc";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column12
            // 
            Column12.HeaderText = "Thể loại";
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.HeaderText = "SL còn";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // Column10
            // 
            Column10.HeaderText = "ĐVT";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // Column13
            // 
            Column13.HeaderText = "Đơn giá";
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(dgvMedicineBill, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(643, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 90.90909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(635, 287);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvMedicineBill
            // 
            dgvMedicineBill.AllowUserToAddRows = false;
            dgvMedicineBill.AllowUserToDeleteRows = false;
            dgvMedicineBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicineBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicineBill.Columns.AddRange(new DataGridViewColumn[] { Column11, Column15, Column1, Column2, Column3, Column4, Column5, Column6 });
            dgvMedicineBill.Dock = DockStyle.Fill;
            dgvMedicineBill.Location = new Point(3, 29);
            dgvMedicineBill.MultiSelect = false;
            dgvMedicineBill.Name = "dgvMedicineBill";
            dgvMedicineBill.RowHeadersVisible = false;
            dgvMedicineBill.Size = new Size(629, 255);
            dgvMedicineBill.TabIndex = 0;
            dgvMedicineBill.CellContentClick += DgvMedicineBillCellContentClick;
            dgvMedicineBill.CellValueChanged += dgvMedicineBill_CellValueChanged;
            // 
            // Column11
            // 
            Column11.FillWeight = 50F;
            Column11.HeaderText = "STT";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            // 
            // Column15
            // 
            Column15.HeaderText = "Mã thuốc";
            Column15.Name = "Column15";
            Column15.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Tên thuốc";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Column2.DefaultCellStyle = dataGridViewCellStyle1;
            Column2.FillWeight = 80F;
            Column2.HeaderText = "SL bán";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.FillWeight = 80F;
            Column3.HeaderText = "ĐVT";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Đơn giá";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Thành tiền";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.FillWeight = 50F;
            Column6.HeaderText = "Xoá";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.4472275F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.5527725F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 231F));
            tableLayoutPanel3.Controls.Add(lbTrangThai, 1, 0);
            tableLayoutPanel3.Controls.Add(lbHeading, 0, 0);
            tableLayoutPanel3.Controls.Add(lbDate, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(629, 20);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // lbTrangThai
            // 
            lbTrangThai.AutoSize = true;
            lbTrangThai.Dock = DockStyle.Fill;
            lbTrangThai.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTrangThai.Location = new Point(203, 0);
            lbTrangThai.Name = "lbTrangThai";
            lbTrangThai.Size = new Size(191, 20);
            lbTrangThai.TabIndex = 2;
            lbTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbHeading
            // 
            lbHeading.AutoSize = true;
            lbHeading.Dock = DockStyle.Fill;
            lbHeading.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbHeading.Location = new Point(3, 0);
            lbHeading.Name = "lbHeading";
            lbHeading.Size = new Size(194, 20);
            lbHeading.TabIndex = 0;
            lbHeading.Text = "Hoá đơn bán thuốc";
            lbHeading.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbDate
            // 
            lbDate.AutoSize = true;
            lbDate.Dock = DockStyle.Fill;
            lbDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDate.Location = new Point(400, 0);
            lbDate.Name = "lbDate";
            lbDate.Size = new Size(226, 20);
            lbDate.TabIndex = 1;
            lbDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnSave);
            flowLayoutPanel2.Controls.Add(btnThanhToan);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(643, 205);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(635, 86);
            flowLayoutPanel2.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Image = Resources.floppy_disk;
            btnSave.ImageAlign = ContentAlignment.TopCenter;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 66);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu lại";
            btnSave.TextAlign = ContentAlignment.BottomCenter;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Enabled = false;
            btnThanhToan.Image = Resources.wallet;
            btnThanhToan.ImageAlign = ContentAlignment.TopCenter;
            btnThanhToan.Location = new Point(140, 3);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(131, 66);
            btnThanhToan.TabIndex = 0;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.TextAlign = ContentAlignment.BottomCenter;
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // tableLayoutPanel14
            // 
            tableLayoutPanel14.ColumnCount = 2;
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.3139153F));
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.68608F));
            tableLayoutPanel14.Controls.Add(label9, 0, 0);
            tableLayoutPanel14.Controls.Add(lbTienTraLai, 1, 0);
            tableLayoutPanel14.Dock = DockStyle.Fill;
            tableLayoutPanel14.Location = new Point(643, 139);
            tableLayoutPanel14.Name = "tableLayoutPanel14";
            tableLayoutPanel14.RowCount = 1;
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel14.Size = new Size(635, 60);
            tableLayoutPanel14.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label9.Location = new Point(3, 0);
            label9.Name = "label9";
            label9.Size = new Size(103, 60);
            label9.TabIndex = 0;
            label9.Text = "Tiền trả lại:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbTienTraLai
            // 
            lbTienTraLai.Anchor = AnchorStyles.Left;
            lbTienTraLai.AutoSize = true;
            lbTienTraLai.Font = new Font("Segoe UI", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbTienTraLai.Location = new Point(112, 15);
            lbTienTraLai.Name = "lbTienTraLai";
            lbTienTraLai.Size = new Size(0, 30);
            lbTienTraLai.TabIndex = 1;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.ColumnCount = 2;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.3139153F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.68608F));
            tableLayoutPanel13.Controls.Add(label8, 0, 0);
            tableLayoutPanel13.Controls.Add(numKhachDua, 1, 0);
            tableLayoutPanel13.Dock = DockStyle.Fill;
            tableLayoutPanel13.Location = new Point(643, 71);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 1;
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.Size = new Size(635, 62);
            tableLayoutPanel13.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(103, 62);
            label8.TabIndex = 0;
            label8.Text = "Khách đưa (*):";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numKhachDua
            // 
            numKhachDua.Anchor = AnchorStyles.Left;
            numKhachDua.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numKhachDua.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numKhachDua.Location = new Point(112, 16);
            numKhachDua.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numKhachDua.Name = "numKhachDua";
            numKhachDua.Size = new Size(120, 29);
            numKhachDua.TabIndex = 1;
            numKhachDua.ThousandsSeparator = true;
            numKhachDua.ValueChanged += numKhachDua_ValueChanged;
            numKhachDua.KeyPress += numKhachDua_KeyPress;
            numKhachDua.MouseClick += numKhachDua_MouseClick;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.ColumnCount = 2;
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.1521034F));
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.84789F));
            tableLayoutPanel12.Controls.Add(label7, 0, 0);
            tableLayoutPanel12.Controls.Add(lbSoTien, 1, 0);
            tableLayoutPanel12.Dock = DockStyle.Fill;
            tableLayoutPanel12.Location = new Point(643, 3);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 1;
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel12.Size = new Size(635, 62);
            tableLayoutPanel12.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(102, 62);
            label7.TabIndex = 0;
            label7.Text = "Khách cần trả:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbSoTien
            // 
            lbSoTien.Anchor = AnchorStyles.Left;
            lbSoTien.AutoSize = true;
            lbSoTien.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbSoTien.Location = new Point(111, 12);
            lbSoTien.Name = "lbSoTien";
            lbSoTien.Size = new Size(0, 37);
            lbSoTien.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.515152F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.484848F));
            tableLayoutPanel8.Controls.Add(label4, 0, 0);
            tableLayoutPanel8.Controls.Add(tbGhiChu, 1, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 139);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new Size(634, 60);
            tableLayoutPanel8.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(384, 60);
            label4.TabIndex = 2;
            label4.Text = "Ghi chú:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbGhiChu
            // 
            tbGhiChu.Anchor = AnchorStyles.Left;
            tbGhiChu.Location = new Point(393, 18);
            tbGhiChu.Name = "tbGhiChu";
            tbGhiChu.Size = new Size(162, 23);
            tbGhiChu.TabIndex = 3;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.515152F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.484848F));
            tableLayoutPanel7.Controls.Add(label3, 0, 0);
            tableLayoutPanel7.Controls.Add(tbBacSi, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 71);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(634, 62);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(384, 62);
            label3.TabIndex = 2;
            label3.Text = "Bác sĩ kê đơn:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbBacSi
            // 
            tbBacSi.Anchor = AnchorStyles.Left;
            tbBacSi.Location = new Point(393, 19);
            tbBacSi.Name = "tbBacSi";
            tbBacSi.Size = new Size(162, 23);
            tbBacSi.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.515152F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.484848F));
            tableLayoutPanel6.Controls.Add(label5, 0, 0);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel5, 1, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(634, 62);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(384, 62);
            label5.TabIndex = 3;
            label5.Text = "Khách hàng (*):";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.72028F));
            tableLayoutPanel5.Controls.Add(cbbKhachHang, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(393, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(238, 56);
            tableLayoutPanel5.TabIndex = 4;
            // 
            // cbbKhachHang
            // 
            cbbKhachHang.Anchor = AnchorStyles.Left;
            cbbKhachHang.FormattingEnabled = true;
            cbbKhachHang.Location = new Point(3, 16);
            cbbKhachHang.Name = "cbbKhachHang";
            cbbKhachHang.Size = new Size(159, 23);
            cbbKhachHang.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel7, 0, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel8, 0, 2);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel12, 1, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel13, 1, 1);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel14, 1, 2);
            tableLayoutPanel4.Controls.Add(flowLayoutPanel2, 1, 3);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 3);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 302);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 23.33233F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 23.3323345F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 22.7450981F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 30.9803925F));
            tableLayoutPanel4.Size = new Size(1281, 294);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 205);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(634, 86);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(320, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(311, 80);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Image = Resources.close;
            btnCancel.ImageAlign = ContentAlignment.TopCenter;
            btnCancel.Location = new Point(3, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(116, 63);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hoàn tác hoá đơn";
            btnCancel.TextAlign = ContentAlignment.BottomCenter;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel11.ColumnCount = 1;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel11.Controls.Add(tableLayoutPanel15, 0, 0);
            tableLayoutPanel11.Location = new Point(23, 12);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 2;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.Size = new Size(1287, 599);
            tableLayoutPanel11.TabIndex = 1;
            // 
            // tableLayoutPanel15
            // 
            tableLayoutPanel15.ColumnCount = 3;
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel15.Controls.Add(tableLayoutPanel2, 2, 0);
            tableLayoutPanel15.Controls.Add(tableLayoutPanel9, 0, 0);
            tableLayoutPanel15.Controls.Add(tableLayoutPanel10, 1, 0);
            tableLayoutPanel15.Dock = DockStyle.Fill;
            tableLayoutPanel15.Location = new Point(3, 3);
            tableLayoutPanel15.Name = "tableLayoutPanel15";
            tableLayoutPanel15.RowCount = 1;
            tableLayoutPanel15.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel15.Size = new Size(1281, 293);
            tableLayoutPanel15.TabIndex = 4;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 1;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.Controls.Add(btnAddToSellBill, 0, 0);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(579, 3);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 1;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.Size = new Size(58, 287);
            tableLayoutPanel10.TabIndex = 2;
            // 
            // btnAddToSellBill
            // 
            btnAddToSellBill.Anchor = AnchorStyles.None;
            btnAddToSellBill.Image = Resources.right_arrow;
            btnAddToSellBill.ImageAlign = ContentAlignment.TopCenter;
            btnAddToSellBill.Location = new Point(6, 113);
            btnAddToSellBill.Name = "btnAddToSellBill";
            btnAddToSellBill.Size = new Size(46, 61);
            btnAddToSellBill.TabIndex = 4;
            btnAddToSellBill.Text = "Thêm";
            btnAddToSellBill.TextAlign = ContentAlignment.BottomCenter;
            btnAddToSellBill.UseVisualStyleBackColor = true;
            btnAddToSellBill.Click += btnAddToSellBill_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // BanHangGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1334, 611);
            Controls.Add(tableLayoutPanel11);
            Name = "BanHangGUI";
            Text = "Bán Hàng";
            Activated += BanHangGUI_Activated;
            Load += BanHangGUI_Load;
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            ((ISupportInitialize)dgvMedicine).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ((ISupportInitialize)dgvMedicineBill).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel14.ResumeLayout(false);
            tableLayoutPanel14.PerformLayout();
            tableLayoutPanel13.ResumeLayout(false);
            tableLayoutPanel13.PerformLayout();
            ((ISupportInitialize)numKhachDua).EndInit();
            tableLayoutPanel12.ResumeLayout(false);
            tableLayoutPanel12.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel11.ResumeLayout(false);
            tableLayoutPanel15.ResumeLayout(false);
            tableLayoutPanel10.ResumeLayout(false);
            ((ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel9;
        private DataGridView dgvMedicine;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dgvMedicineBill;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lbHeading;
        private Label lbDate;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label3;
        private TextBox tbBacSi;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label4;
        private TextBox tbGhiChu;
        private TableLayoutPanel tableLayoutPanel12;
        private Label label7;
        private Label lbSoTien;
        private TableLayoutPanel tableLayoutPanel13;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel14;
        private Label label9;
        private Label lbTienTraLai;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnSave;
        private Button btnThanhToan;
        private TableLayoutPanel tableLayoutPanel11;
        private TableLayoutPanel tableLayoutPanel15;
        private Label label2;
        private Label lbTrangThai;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCancel;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewButtonColumn Column6;
        private ComboBox cbbKhachHang;
        private NumericUpDown numKhachDua;
        private ToolTip toolTip1;
        private ErrorProvider errorProvider1;
        private TableLayoutPanel tableLayoutPanel10;
        private Button btnAddToSellBill;
    }
}