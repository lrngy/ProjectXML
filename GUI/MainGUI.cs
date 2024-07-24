using System;
using System.Windows.Forms;
using ProjectXML.BUS;
using ProjectXML.DTO;
using ProjectXML.GUI.Dialog;
using ProjectXML.Util;

namespace ProjectXML.GUI
{
    public partial class MainGUI : Form
    {
        private ChangePasswordDialog changePasswordDialog;
        private readonly LoginBUS loginBUS = new LoginBUS();
        private LoginGUI loginView;
        private QuanLyNhanVienGUI quanLyNhanVienView;
        private QuanLyTaiChinhGUI quanLyTaiChinhView;
        private QuanLyThuocGUI quanLyThuocView;
        private readonly StaffDTO staff;
        private ThongTinCaNhanGUI thongTinCaNhanView;
        private readonly UserDTO user;

        public MainGUI(UserDTO user, LoginGUI loginView, StaffDTO staff)
        {
            InitializeComponent();
            this.user = user;
            this.loginView = loginView;
            this.staff = staff;
        }

        private void btnQlyThuoc_Click(object sender, EventArgs e)
        {
            if (staff.isSeller)
            {
                CustomMessageBox.ShowError("Bạn không có quyền truy cập chức năng này");
                return;
            }

            Show(ref quanLyThuocView, () => new QuanLyThuocGUI(user, 0));
            quanLyThuocView.tabControl1.SelectTab(0);
        }

        private void Show<T>(ref T form, Func<T> NewInstance) where T : Form
        {
            if (form == null || form.IsDisposed)
            {
                form = NewInstance();
                form.FormClosed += (s, args) => WindowState = FormWindowState.Normal;
            }

            form.Show();
            form.WindowState = FormWindowState.Normal;
            //this.WindowState = FormWindowState.Minimized;
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            Show(ref quanLyThuocView, () => new QuanLyThuocGUI(user, 1));
            quanLyThuocView.tabControl1.SelectTab(1);
        }

        private void btnNcc_Click(object sender, EventArgs e)
        {
            Show(ref quanLyThuocView, () => new QuanLyThuocGUI(user, 2));
            quanLyThuocView.tabControl1.SelectTab(2);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (staff.isSeller)
            {
                CustomMessageBox.ShowError("Bạn không có quyền truy cập chức năng này");
                return;
            }

            Show(ref quanLyNhanVienView, () => new QuanLyNhanVienGUI());
        }

        private void btnTaiChinh_Click(object sender, EventArgs e)
        {
            Show(ref quanLyTaiChinhView, () => new QuanLyTaiChinhGUI());
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            Show(ref thongTinCaNhanView, () => new ThongTinCaNhanGUI(user));
            thongTinCaNhanView.OnUpdate += ChangeTextWelcome;
        }

        public void ChangeTextWelcome()
        {
            lbWelcome.Text = "Xin chào, " + staff.name;
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
            var currentDate = DateTime.Now;
            var formattedDate = string.Format("{0}, ngày {1} tháng {2} năm {3}",
                GetDayOfWeekInVietnamese(currentDate.DayOfWeek),
                currentDate.Day,
                currentDate.Month,
                currentDate.Year);

            lbDate.Text = formattedDate;


            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, args) => { lbTime.Text = DateTime.Now.ToString("HH:mm:ss"); };
            timer.Start();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (changePasswordDialog == null || changePasswordDialog.IsDisposed)
                changePasswordDialog = new ChangePasswordDialog(user);

            changePasswordDialog.Show();
            changePasswordDialog.WindowState = FormWindowState.Normal;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirmResult = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn đăng xuất?");
            if (confirmResult == DialogResult.Yes)
            {
                loginBUS.Logout(user);
                Dispose();
                if (loginView == null || loginView.IsDisposed) loginView = new LoginGUI();
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
            if (confirmResult == DialogResult.Yes) Application.Exit();
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
            var aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog();
        }

        private void MainGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn thoát?");
            if (result == DialogResult.No) e.Cancel = true;
            //else
            //{
            //    loginBUS.Logout(user);
            //}
        }
    }
}