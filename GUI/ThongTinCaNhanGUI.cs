using System;
using System.Globalization;
using System.Windows.Forms;
using ProjectXML.BUS;
using ProjectXML.DAL;
using ProjectXML.DTO;
using ProjectXML.GUI.Dialog;
using ProjectXML.Util;

namespace ProjectXML.GUI
{
    public partial class ThongTinCaNhanGUI : Form
    {
        public delegate void OnUpdateHandler();
        public OnUpdateHandler OnUpdate;

        private ChangePasswordDialog changePasswordDialog;
        private UserDTO user;
        private readonly StaffDTO staff;
        private readonly UserBUS userController = new UserBUS();

        public ThongTinCaNhanGUI(UserDTO user)
        {
            InitializeComponent();
            this.user = user;
            staff = new StaffDAL().GetByUsername(user.username);
        }

        private void ThongTinCaNhanView_Load(object sender, EventArgs e)
        {
            ThongTinCaNhanShow();
        }

        public void ThongTinCaNhanShow()
        {
            user = userController.getUser(user.username);
            lbMaNV.Text = staff.id;
            lbVaiTro.Text = staff.isManager ? "Quản lý" : "Nhân viên";
            tbHoTen.Text = staff.name;
            try
            {
                dateTimePicker1.Text = staff.birthday;
            }
            catch (Exception)
            {
                dateTimePicker1.Text = "2000-01-01";
            }

            radioButton1.Checked = staff.gender;
            radioButton2.Checked = !radioButton1.Checked;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var name = tbHoTen.Text;
            var gender = radioButton1.Checked ? true : false;
            var birthday = dateTimePicker1.Text;

            if (name.Equals(""))
            {
                CustomMessageBox.ShowWarning("Vui lòng nhập tên của bạn");
                return;
            }

            if (name.Length > 30)
            {
                CustomMessageBox.ShowWarning("Tên không được quá 30 ký tự");
                return;
            }

            var birth = DateTime.ParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (DateTime.Now.Year - birth.Year < 18)
            {
                CustomMessageBox.ShowWarning("Tuổi của bạn phải lớn hơn hoặc bằng 18");
                return;
            }

            var newStaff = new StaffDTO(staff.id, name, gender, birth.ToString("yyyy-MM-dd"), staff.isManager,
                staff.isSeller, user.username);
            var newUser = new UserDTO(user.username, user.password);
            var result = userController.Update(newUser, newStaff);
            if (result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess("Cập nhật thông tin thành công");
                user.Update(newUser);
                staff.Update(newStaff);
                ThongTinCaNhanShow();
                OnUpdate();
                return;
            }

            if (result == Predefined.ID_NOT_EXIST)
            {
                CustomMessageBox.ShowError("Tài khoản không tồn tại");
                return;
            }

            CustomMessageBox.ShowError("Cập nhật thông tin thất bại");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (changePasswordDialog == null || changePasswordDialog.IsDisposed)
                changePasswordDialog = new ChangePasswordDialog(user);

            changePasswordDialog.Show();
            changePasswordDialog.WindowState = FormWindowState.Normal;
        }
    }
}