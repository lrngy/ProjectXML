
namespace QPharma.GUI
{
    public partial class QuanLyNhanVienGUI : BaseForm
    {
        private String id;
        private String name;
        private Boolean gender;
        private String birthday;
        private String account;
        private Boolean isManager;
        private Boolean isSeller;
        private String username;

        private StaffBUS staffBus;
        public static List<StaffDTO> deleted_list;
        public static List<StaffDTO> staff_list;


        public QuanLyNhanVienGUI()
        {
            InitializeComponent();
            staffBus = new StaffBUS();
            deleted_list = new List<StaffDTO>();
            staff_list = new List<StaffDTO>();
        }
        private void QuanLyNhanVienForm_Load(object sender, EventArgs e)
        {
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);

            save_add.Enabled = false;
            sua.Enabled = false;
            xoa.Enabled = false;
            bResetPass.Enabled = false;
            dateTimePicker1.Text = "01/01/1999";
            //dateTimePicker1.Text = "00/00/0000";

            cboGender.Items.Add("--Chọn giới tính--");
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.SelectedIndex = 0;  // Chọn mặc định là Nam

            t_id.ReadOnly = true;
            Back_Click(sender, e);
            HienThi();
        }
        private StaffDTO currentStaff()
        {
            this.id = t_id.Text.Trim();
            this.name = t_staff_name.Text.Trim();
            this.gender = (cboGender.Text.Trim() == "Nam") ? true : false;
            this.birthday = dateTimePicker1.Text;
            this.account = tTaiKhoan.Text.Trim();
            this.isManager = c_staff_is_manager.Checked;
            this.isSeller = c_staff_is_seller.Checked;
            this.username = tTaiKhoan.Text.Trim();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) ||
                cboGender.Text.Trim() == "--Chọn giới tính--" ||
                string.IsNullOrEmpty(birthday) || string.IsNullOrEmpty(account) ||
                !(isManager || isSeller))
                return null;

            return new StaffDTO(id, name, gender, birthday, isManager, isSeller, username);
        }
        public void HienThi()
        {
            try
            {
                staff_list.Clear();
                deleted_list.Clear();

                var staffs = StaffBUS.GetAll();
                foreach (StaffDTO staff in staffs)
                    if (string.IsNullOrEmpty(staff.staff_deleted))
                        staff_list.Add(staff);
                    else
                        deleted_list.Add(staff);

                dataGridViewStaffFill(this.dataGridView1, staff_list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đọc dữ liệu Staff: " + ex.Message);
            }
        }
        public static void dataGridViewStaffFill(DataGridView dataGridView1, List<StaffDTO> staffs)
        {
            if (staffs is null) return;

            var sd = 0;
            dataGridView1.Rows.Clear();
            foreach (StaffDTO staff in staffs)
                if (StaffBUS.CheckExistUsername(staff.username))
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[sd].Cells[0].Value = staff.id;
                    dataGridView1.Rows[sd].Cells[1].Value = staff.name;
                    dataGridView1.Rows[sd].Cells[2].Value = staff.username;
                    dataGridView1.Rows[sd].Cells[3].Value = staff.gender? "Nam": "Nữ";
                    dataGridView1.Rows[sd].Cells[4].Value = staff.birthday;
                    dataGridView1.Rows[sd].Cells[5].Value = staff.isManager;
                    dataGridView1.Rows[sd].Cells[6].Value = staff.isSeller;
                    sd++;
                }
        }
        private string cell(int rowSelected, int cellNumber)
        {
            return dataGridView1.Rows[rowSelected].Cells[cellNumber].Value.ToString().Trim();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tTaiKhoan.Enabled = false;
            them.Enabled = false;
            sua.Enabled = true;
            xoa.Enabled = true;
            bResetPass.Enabled = true;

            var row = dataGridView1.CurrentCell.RowIndex;

            t_id.Text = this.cell(row, 0);
            t_staff_name.Text = this.cell(row, 1);
            tTaiKhoan.Text = this.cell(row, 2);
            cboGender.Text = this.cell(row, 3);
            dateTimePicker1.Text = this.cell(row, 4);
            c_staff_is_manager.Checked = (this.cell(row, 5) == "True")
                ? true : false;
            c_staff_is_seller.Checked = (this.cell(row, 6) == "True")
                ? true : false;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            t_id.ReadOnly = true;

            t_id.Text = "";
            t_staff_name.Text = "";
            cboGender.Text = "--Chọn giới tính--";
            dateTimePicker1.Text = "";
            c_staff_is_manager.Checked = false;
            c_staff_is_seller.Checked = false;
            tTaiKhoan.Text = "";

            bResetPass.Enabled = false;
            tTaiKhoan.Enabled = true;
            them.Enabled = true;
            sua.Enabled = false;
            xoa.Enabled = false;
            save_add.Enabled = false;
            bResetPass.Enabled = false;
        }
        private void them_Click(object sender, EventArgs e)
        {
            Back_Click(sender, e);
            them.Enabled = false;
            sua.Enabled = false;
            xoa.Enabled = false;
            save_add.Enabled = true;

            t_id.ReadOnly = false;
        }
        private void save_add_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.ShowQuestion("Chắc chắn muốn thêm nhân viên?") == DialogResult.Yes)
            {
                staffBus.addSave(this.currentStaff());
                Back_Click(sender, e);
                HienThi();
            }
        }
        private void sua_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.ShowQuestion("Chắc chắn muốn sửa nhân viên đã chọn?") == DialogResult.Yes)
            {
                staffBus.updateStaff(this.currentStaff());
                Back_Click(sender, e);
                HienThi();
            }
        }
        private void xoa_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.ShowQuestion("Chắc chắn muốn xóa nhân viên đã chọn?") == DialogResult.Yes)
            {
                this.currentStaff();
                staffBus.delete(id);
                Back_Click(sender, e);
                HienThi();
            }
        }
        private void deleted_staffs_Click(object sender, EventArgs e)
        {
            new DeletedStaffsDialog(this);
        }
        private void t_timKiem_TextChanged(object sender, EventArgs e)
        {
            var searchText = t_timKiem.Text.Trim().ToLower();

            if (searchText == "")
                HienThi();
            else
                dataGridViewStaffFill(this.dataGridView1, StaffDAL.Search(searchText));
        }
        private void bResetPass_Click(object sender, EventArgs e)
        {
            if (t_id.Text.Trim() == "" || tTaiKhoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đủ id và thông tin tài khoản!");
                return;
            }
            if (CustomMessageBox.ShowQuestion("Chắc chắn muốn đặt lại mật khẩu nhân viên đã chọn?") == DialogResult.Yes)
            {
                staffBus.resetUserPassword(username);
                Back_Click(sender, e);
            }
        }
    }
}