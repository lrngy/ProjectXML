namespace QPharma.GUI.Dialog
{
    partial class DeletedSupplierDialog
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvDeletedSupplier = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            Column21 = new DataGridViewTextBoxColumn();
            Column22 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            btnForceDel = new Button();
            btnRestore = new Button();
            btnRestoreAll = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)dgvDeletedSupplier).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dgvDeletedSupplier, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Location = new Point(20, 23);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88.47059F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.52941F));
            tableLayoutPanel1.Size = new Size(2045, 1058);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvDeletedSupplier
            // 
            dgvDeletedSupplier.AllowUserToAddRows = false;
            dgvDeletedSupplier.AllowUserToDeleteRows = false;
            dgvDeletedSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeletedSupplier.BackgroundColor = SystemColors.Control;
            dgvDeletedSupplier.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDeletedSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDeletedSupplier.ColumnHeadersHeight = 50;
            dgvDeletedSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDeletedSupplier.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, Column9, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, Column21, Column22, Column1 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDeletedSupplier.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDeletedSupplier.Dock = DockStyle.Fill;
            dgvDeletedSupplier.EnableHeadersVisualStyles = false;
            dgvDeletedSupplier.Location = new Point(5, 6);
            dgvDeletedSupplier.Margin = new Padding(5, 6, 5, 6);
            dgvDeletedSupplier.MultiSelect = false;
            dgvDeletedSupplier.Name = "dgvDeletedSupplier";
            dgvDeletedSupplier.ReadOnly = true;
            dgvDeletedSupplier.RowHeadersVisible = false;
            dgvDeletedSupplier.RowHeadersWidth = 62;
            dgvDeletedSupplier.RowTemplate.Height = 50;
            dgvDeletedSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeletedSupplier.Size = new Size(2035, 924);
            dgvDeletedSupplier.TabIndex = 5;
            dgvDeletedSupplier.CellFormatting += dgvDeletedSupplier_CellFormatting;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewTextBoxColumn1.HeaderText = "STT";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 50;
            // 
            // Column9
            // 
            Column9.HeaderText = "Mã nhà cung cấp";
            Column9.MinimumWidth = 8;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Tên nhà cung cấp";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Điện thoại";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Email";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Ghi chú";
            dataGridViewTextBoxColumn5.MinimumWidth = 8;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Trạng thái";
            dataGridViewTextBoxColumn6.MinimumWidth = 8;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Column21
            // 
            Column21.HeaderText = "Ngày tạo";
            Column21.MinimumWidth = 8;
            Column21.Name = "Column21";
            Column21.ReadOnly = true;
            // 
            // Column22
            // 
            Column22.HeaderText = "Ngày cập nhật";
            Column22.MinimumWidth = 8;
            Column22.Name = "Column22";
            Column22.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Ngày xoá";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnForceDel);
            panel1.Controls.Add(btnRestore);
            panel1.Controls.Add(btnRestoreAll);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(5, 942);
            panel1.Margin = new Padding(5, 6, 5, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(2035, 110);
            panel1.TabIndex = 6;
            // 
            // btnForceDel
            // 
            btnForceDel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnForceDel.Location = new Point(1253, 23);
            btnForceDel.Margin = new Padding(5, 6, 5, 6);
            btnForceDel.Name = "btnForceDel";
            btnForceDel.Size = new Size(205, 63);
            btnForceDel.TabIndex = 0;
            btnForceDel.Text = "Xoá vĩnh viễn";
            btnForceDel.UseVisualStyleBackColor = true;
            btnForceDel.Click += btnForceDel_Click;
            // 
            // btnRestore
            // 
            btnRestore.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRestore.Location = new Point(870, 23);
            btnRestore.Margin = new Padding(5, 6, 5, 6);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(145, 63);
            btnRestore.TabIndex = 0;
            btnRestore.Text = "Khôi phục";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // btnRestoreAll
            // 
            btnRestoreAll.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRestoreAll.Location = new Point(452, 23);
            btnRestoreAll.Margin = new Padding(5, 6, 5, 6);
            btnRestoreAll.Name = "btnRestoreAll";
            btnRestoreAll.Size = new Size(195, 63);
            btnRestoreAll.TabIndex = 0;
            btnRestoreAll.Text = "Khôi phục tất cả";
            btnRestoreAll.UseVisualStyleBackColor = true;
            btnRestoreAll.Click += btnRestoreAll_Click;
            // 
            // DeletedSupplierDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2085, 1104);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5, 6, 5, 6);
            MinimumSize = new Size(2097, 1023);
            Name = "DeletedSupplierDialog";
            Text = "Nhà cung cấp đã xoá";
            Load += DeletedSupplierDialog_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((ISupportInitialize)dgvDeletedSupplier).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvDeletedSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnForceDel;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnRestoreAll;
    }
}