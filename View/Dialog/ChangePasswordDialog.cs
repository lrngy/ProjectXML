using ProjectXML.Controller;
using ProjectXML.Model;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectXML.View.Dialog
{
    public partial class ChangePasswordDialog : Form
    {
        User user;
        UserController userController = new UserController();
        public ChangePasswordDialog(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPassword = tbOldPass.Text.Trim();
            string newPassword = tbNewPass.Text.Trim();
            string confirmPassword = tbReNewPass.Text.Trim();

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

            User newUser = new User(user.username, newPassword, user.staff);
           
            int result = userController.Update(newUser);
            if(result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess("Đổi mật khẩu thành công");
                user.password = newPassword;
                this.Close();
            }
            else
            {
                CustomMessageBox.ShowError("Đổi mật khẩu thất bại");
            }
            
        
        }

        private void tbOldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }
    }
}
