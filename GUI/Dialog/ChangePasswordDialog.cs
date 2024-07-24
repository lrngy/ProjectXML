using System;
using System.Windows.Forms;
using ProjectXML.BUS;
using ProjectXML.DTO;
using ProjectXML.Properties;
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
                CustomMessageBox.ShowWarning(Resources.PleaseEnterCompleteInfo);
                return;
            }


            if (!oldPassword.Equals(user.password))
            {
                CustomMessageBox.ShowWarning(Resources.OldPasswordNotCorrect);
                return;
            }

            if (!newPassword.Equals(confirmPassword))
            {
                CustomMessageBox.ShowWarning(Resources.NewPasswordNotCorrect);
                return;
            }

            var newUser = new UserDTO(user.username, newPassword);

            var result = userController.UpdatePassword(newUser);
            if (result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess(Resources.ChangePasswordSuccess);
                user.password = newPassword;
                Close();
            }
            else
            {
                CustomMessageBox.ShowError(Resources.ChangePasswordFail
                );
            }
        }

        private void tbOldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSave.PerformClick();
        }
    }
}