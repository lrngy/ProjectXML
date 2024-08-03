namespace QPharma.GUI.Dialog
{
    public partial class DeletedStaffsDialog : Form
    {
        string currentUsername;
        QuanLyNhanVienGUI quanLyNhanVienGUI;

        public DeletedStaffsDialog(QuanLyNhanVienGUI quanLyNhanVienGUI)
        {
            InitializeComponent();
            this.Show();
            this.restoreBtn.Enabled = false;
            this.deleteForeverBtn.Enabled = false;
            this.quanLyNhanVienGUI = quanLyNhanVienGUI;
        }

        private void DeletedStaffsDialog_Load(object sender, EventArgs e)
        {
            QuanLyNhanVienGUI.dataGridViewStaffFill(this.dataGridView1, QuanLyNhanVienGUI.deleted_list);
        }

        private void restoreBtn_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.ShowQuestion("Chắc chắn muốn khôi phục nhân viên đã chọn?") == DialogResult.Yes)
            {
                if (StaffDAL.Restore(currentUsername) == Predefined.SUCCESS)
                    MessageBox.Show("Khôi phục nhân viên thành công");
                else
                    MessageBox.Show("Khôi phục nhân viên thất bại");
                //MessageBox.Show(currentUsername);

                quanLyNhanVienGUI.HienThi();
                QuanLyNhanVienGUI.dataGridViewStaffFill(this.dataGridView1, QuanLyNhanVienGUI.deleted_list);
                back(false);
            }
            else back(false);
        }

        private void restoreAllBtn_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.ShowQuestion("Chắc chắn muốn khôi phục tất cả nhân viên?") == DialogResult.Yes)
            {
                StaffDAL.RestoreAll();
                quanLyNhanVienGUI.HienThi();
                dataGridView1.Rows.Clear();
                back(false);
            }
            else back(false);
        }

        private void deleteForeverBtn_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.ShowQuestion("Chắc chắn muốn xóa vĩnh viễn nhân viên đã chọn?") == DialogResult.Yes)
            {
                if (StaffDAL.ForceDelete(currentUsername) == Predefined.ERROR) 
                    MessageBox.Show("Xóa Staff thất bại");
                else
                    MessageBox.Show("Xóa Staff thành công");

                quanLyNhanVienGUI.HienThi();
                QuanLyNhanVienGUI.dataGridViewStaffFill(this.dataGridView1, QuanLyNhanVienGUI.deleted_list);
                back(false);
            }
            else back(false);
        }

        private void deleteForeverAllBtn_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.ShowQuestion("Chắc chắn muốn xóa vĩnh viễn tất cả nhân viên?") == DialogResult.Yes)
            {

                quanLyNhanVienGUI.HienThi();
                foreach (StaffDTO staffDTO in QuanLyNhanVienGUI.deleted_list)
                {
                    StaffDAL.ForceDelete(staffDTO.username);
                }
                StaffDAL.ForceAllDelete();
                dataGridView1.Rows.Clear();
                MessageBox.Show("Xóa danh sách Staff thành công");
                back(false);
            }
            else back(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentUsername = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString().Trim();
            back(true);
        }

        private void back(bool d)
        {
            this.restoreBtn.Enabled = d;
            this.deleteForeverBtn.Enabled = d;
        }
    }
}
