using ProjectXML.Model;
using ProjectXML.Util;
using ProjectXML.View.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectXML.View
{
    public partial class MainView : Form
    {
        User user;
        LoginView loginView;
        QuanLyThuocView quanLyThuocView;
        ThongTinCaNhanView thongTinCaNhanView;
        ChangePasswordDialog changePasswordDialog;


        public MainView(User user, LoginView loginView)
        {
            InitializeComponent();
            this.user = user;
            this.loginView = loginView;
        }

        private void btnQlyThuoc_Click(object sender, EventArgs e)
        {
            if (user.staff.isSeller)
            {
                CustomMessageBox.ShowError("Bạn không có quyền truy cập chức năng này");
                return;
            }
            Show(ref quanLyThuocView, () => new QuanLyThuocView(user, 0));
        }

        private void Show<T>(ref T form, Func<T> NewInstance) where T : Form
        {
            if (form == null || form.IsDisposed)
            {
                form = NewInstance();
                form.FormClosed += (s, args) => this.WindowState = FormWindowState.Normal;
            }
            form.Show();
            form.WindowState = FormWindowState.Normal;
            //this.WindowState = FormWindowState.Minimized;

        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            Show(ref quanLyThuocView, () => new QuanLyThuocView(user, 1));
        }

        private void btnNcc_Click(object sender, EventArgs e)
        {
            Show(ref quanLyThuocView, () => new QuanLyThuocView(user, 2));
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (user.staff.isSeller)
            {
                CustomMessageBox.ShowError("Bạn không có quyền truy cập chức năng này");
                return;
            }
            //Show(ref quanLyThuocView, () => new QuanLyThuocView(user, 2));
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            Show(ref thongTinCaNhanView, () => new ThongTinCaNhanView(user));
            thongTinCaNhanView.OnUpdate += ChangeTextWelcome;
        }

        public void ChangeTextWelcome()
        {
            lbWelcome.Text = "Xin chào, " + user.staff.name;
        }

        private string GetDayOfWeekInVietnamese(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "Chủ nhật";
                case DayOfWeek.Monday:
                    return "Thứ hai";
                case DayOfWeek.Tuesday:
                    return "Thứ ba";
                case DayOfWeek.Wednesday:
                    return "Thứ tư";
                case DayOfWeek.Thursday:
                    return "Thứ năm";
                case DayOfWeek.Friday:
                    return "Thứ sáu";
                case DayOfWeek.Saturday:
                    return "Thứ bảy";
                default:
                    return "";
            }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            ChangeTextWelcome();
            DateTime currentDate = DateTime.Now;
            string formattedDate = string.Format("{0}, ngày {1} tháng {2} năm {3}",
                GetDayOfWeekInVietnamese(currentDate.DayOfWeek),
                currentDate.Day,
                currentDate.Month,
                currentDate.Year);

            lbDate.Text = formattedDate;


            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler((s, args) =>
            {
                lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
            });
            timer.Start();

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (changePasswordDialog == null || changePasswordDialog.IsDisposed)
            {
                changePasswordDialog = new ChangePasswordDialog(user);
            }

            changePasswordDialog.Show();
            changePasswordDialog.WindowState = FormWindowState.Normal;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirmResult = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn đăng xuất?");
            if (confirmResult == DialogResult.Yes)
            {
                this.Dispose();
                loginView.Show();
            }
        }

        private void thuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnQlyThuoc.PerformClick();
        }

        private void danhMụcThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDanhMuc.PerformClick();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNcc.PerformClick();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNhanVien.PerformClick();
        }

        private void tàiChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTaiChinh.PerformClick();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn thoát?");
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cậpNhậtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThongTin.PerformClick();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnChangePassword.PerformClick();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLogout.PerformClick();
        }

        private void thôngTinỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog();
        }
    }
}
