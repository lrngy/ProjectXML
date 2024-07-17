using System;
using System.Globalization;
using System.Windows.Forms;
using ProjectXML.BUS;
using ProjectXML.DTO;
using ProjectXML.GUI.Dialog;
using ProjectXML.Util;

namespace ProjectXML.GUI
{
    public partial class ThongTinCaNhanGUI : Form
    {
        public delegate void OnUpdateHandler();

        private ChangePasswordDialog changePasswordDialog;
        public OnUpdateHandler OnUpdate;
        private UserDTO user;
        private readonly UserBUS userController = new UserBUS();

        public ThongTinCaNhanGUI(UserDTO user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void ThongTinCaNhanView_Load(object sender, EventArgs e)
        {
            ThongTinCaNhanShow();
        }

        public void ThongTinCaNhanShow()
        {
            user = userController.getUser(user.username);
            lbMaNV.Text = user.staff.id;
            lbVaiTro.Text = user.staff.isManager ? "Quản lý" : "Nhân viên";
            tbHoTen.Text = user.staff.name;
            try
            {
                dateTimePicker1.Text = DateTime
                    .ParseExact(user.staff.birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
            }
            catch (Exception)
            {
                dateTimePicker1.Text = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    .ToString();
            }

            radioButton1.Checked = user.staff.gender;
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

            var birthdayYear = DateTime.ParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            if (DateTime.Now.Year - birthdayYear < 18)
            {
                CustomMessageBox.ShowWarning("Tuổi của bạn phải lớn hơn hoặc bằng 18");
                return;
            }

            var newStaff = new StaffDTO(user.staff.id, name, gender, birthday, user.staff.isManager,
                user.staff.isSeller, user.username);
            var newUser = new UserDTO(user.username, user.password, newStaff);
            var result = userController.Update(newUser);
            if (result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess("Cập nhật thông tin thành công");
                user.Update(newUser);
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