using System;
using System.Windows.Forms;
using QPharma.BUS;
using QPharma.DTO;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma.GUI.Dialog
{
    public partial class ChangePasswordDialog : BaseForm
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
                CustomMessageBox.ShowWarning(Resources.Please_enter_complete_info);
                return;
            }


            if (!oldPassword.Equals(user.password))
            {
                CustomMessageBox.ShowWarning(Resources.Old_password_not_correct);
                return;
            }

            if (!newPassword.Equals(confirmPassword))
            {
                CustomMessageBox.ShowWarning(Resources.New_password_not_correct);
                return;
            }

            var newUser = new UserDTO(user.username, newPassword);

            var result = userController.UpdatePassword(newUser);
            if (result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess(Resources.Change_password_success);
                user.password = newPassword;
                Close();
            }
            else
            {
                CustomMessageBox.ShowError(Resources.Change_password_fail
                );
            }
        }

        private void tbOldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSave.PerformClick();
        }
    }
}