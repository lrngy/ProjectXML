namespace QPharma.GUI.Dialog
{
    partial class DeletedBillDialog
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvDeletedBill = new DataGridView();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            Column34 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnDeleteAll = new Button();
            btnDelete = new Button();
            btnRestore = new Button();
            btnRestoreAllBill = new Button();
            lbSoDong = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)dgvDeletedBill).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dgvDeletedBill, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Location = new Point(12, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.10526F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.894737F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(957, 477);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvDeletedBill
            // 
            dgvDeletedBill.AllowUserToAddRows = false;
            dgvDeletedBill.AllowUserToDeleteRows = false;
            dgvDeletedBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeletedBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeletedBill.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn12, Column34, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn10, Column1 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvDeletedBill.DefaultCellStyle = dataGridViewCellStyle1;
            dgvDeletedBill.Dock = DockStyle.Fill;
            dgvDeletedBill.Location = new Point(3, 3);
            dgvDeletedBill.MultiSelect = false;
            dgvDeletedBill.Name = "dgvDeletedBill";
            dgvDeletedBill.ReadOnly = true;
            dgvDeletedBill.RowHeadersVisible = false;
            dgvDeletedBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeletedBill.Size = new Size(951, 433);
            dgvDeletedBill.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.FillWeight = 70F;
            dataGridViewTextBoxColumn12.HeaderText = "Mã hoá đơn";
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // Column34
            // 
            Column34.HeaderText = "Trạng thái";
            Column34.Name = "Column34";
            Column34.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "Thời gian";
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Khách hàng";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Tổng tiền";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.HeaderText = "Nhân viên";
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Ngày xoá";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Controls.Add(btnDeleteAll, 4, 0);
            tableLayoutPanel2.Controls.Add(btnDelete, 3, 0);
            tableLayoutPanel2.Controls.Add(btnRestore, 2, 0);
            tableLayoutPanel2.Controls.Add(btnRestoreAllBill, 1, 0);
            tableLayoutPanel2.Controls.Add(lbSoDong, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 442);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(951, 32);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Anchor = AnchorStyles.None;
            btnDeleteAll.Location = new Point(815, 3);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(80, 26);
            btnDeleteAll.TabIndex = 0;
            btnDeleteAll.Text = "Xoá tất cả";
            btnDeleteAll.UseVisualStyleBackColor = true;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.Location = new Point(625, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(79, 26);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRestore
            // 
            btnRestore.Anchor = AnchorStyles.None;
            btnRestore.Location = new Point(435, 3);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(79, 26);
            btnRestore.TabIndex = 0;
            btnRestore.Text = "Khôi phục";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // btnRestoreAllBill
            // 
            btnRestoreAllBill.Anchor = AnchorStyles.None;
            btnRestoreAllBill.Location = new Point(224, 3);
            btnRestoreAllBill.Name = "btnRestoreAllBill";
            btnRestoreAllBill.Size = new Size(122, 26);
            btnRestoreAllBill.TabIndex = 0;
            btnRestoreAllBill.Text = "Khôi phục tất cả";
            btnRestoreAllBill.UseVisualStyleBackColor = true;
            btnRestoreAllBill.Click += btnRestoreAllBill_Click;
            // 
            // lbSoDong
            // 
            lbSoDong.Anchor = AnchorStyles.None;
            lbSoDong.AutoSize = true;
            lbSoDong.Location = new Point(43, 8);
            lbSoDong.Name = "lbSoDong";
            lbSoDong.Size = new Size(104, 15);
            lbSoDong.TabIndex = 1;
            lbSoDong.Text = "Tổng cộng 0 dòng";
            // 
            // DeletedBillDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 509);
            Controls.Add(tableLayoutPanel1);
            Name = "DeletedBillDialog";
            Text = "DeletedBillDialog";
            Load += DeletedBillDialog_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((ISupportInitialize)dgvDeletedBill).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnRestoreAllBill;
        private Button btnRestore;
        private Button btnDelete;
        private Button btnDeleteAll;
        private DataGridView dgvDeletedBill;
        private Label lbSoDong;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn Column34;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn Column1;
    }
}