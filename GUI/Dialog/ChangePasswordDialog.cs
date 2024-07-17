using System;
using System.Windows.Forms;
using ProjectXML.BUS;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.GUI.Dialog
{
    public partial class ChangePasswordDialog : Form
    {
        private readonly UserDTO user;
        private readonly UserBUS userController = new UserBUS();

        public ChangePasswordDialog(UserDTO user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var oldPassword = tbOldPass.Text.Trim();
            var newPassword = tbNewPass.Text.Trim();
            var confirmPassword = tbReNewPass.Text.Trim();

            if (oldPassword.Equals("") || newPassword.Equals("") || confirmPassword.Equals(""))
            {
                CustomMessageBox.ShowWarning("Vui lòng nhập đầy đủ thông tin");
                return;
            }


            if (!oldPassword.Equals(user.password))
            {
                CustomMessageBox.ShowWarning("Mật khẩu cũ không đúng");
                return;
            }

            if (!newPassword.Equals(confirmPassword))
            {
                CustomMessageBox.ShowWarning("Mật khẩu mới không khớp");
                return;
            }

            var newUser = new UserDTO(user.username, newPassword, user.staff);

            var result = userController.Update(newUser);
            if (result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess("Đổi mật khẩu thành công");
                user.password = newPassword;
                Close();
            }
            else
            {
                CustomMessageBox.ShowError("Đổi mật khẩu thất bại");
            }
        }

        private void tbOldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSave.PerformClick();
        }
    }
}