using ProjectXML.Controller;
using ProjectXML.Model;
using ProjectXML.Util;
using ProjectXML.View.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectXML.View
{
    public partial class ThongTinCaNhanView : Form
    {
        User user;
        UserController userController = new UserController();
        ChangePasswordDialog changePasswordDialog;

        public delegate void OnUpdateHandler();
        public OnUpdateHandler OnUpdate;
        public ThongTinCaNhanView(User user)
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
            lbMaNV.Text = user.staff.id;
            lbVaiTro.Text = user.staff.isManager ? "Quản lý" : "Nhân viên";
            tbHoTen.Text = user.staff.name;
            dateTimePicker1.Text = DateTime.ParseExact(user.staff.birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
            radioButton1.Checked = user.staff.gender;
            radioButton2.Checked = !radioButton1.Checked;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = tbHoTen.Text;
            bool gender = radioButton1.Checked ? true : false;
            string birthday = dateTimePicker1.Text;

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

            int birthdayYear = DateTime.ParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            if (DateTime.Now.Year - birthdayYear < 18)
            {
                CustomMessageBox.ShowWarning("Tuổi của bạn phải lớn hơn hoặc bằng 18");
                return;
            }

            Staff newStaff = new Staff(user.staff.id, name, gender, birthday, user.staff.isManager, user.staff.isSeller);
            User newUser = new User(user.username, user.password, newStaff);
            int result = userController.Update(newUser);
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
            this.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (changePasswordDialog == null || changePasswordDialog.IsDisposed)
            {
                changePasswordDialog = new ChangePasswordDialog(user);
            }

            changePasswordDialog.Show();
            changePasswordDialog.WindowState = FormWindowState.Normal;


        }
    }
}
