﻿namespace QPharma.GUI;

public partial class MainGUI : BaseForm
{
    private readonly LoginBUS loginBUS = new();
    private readonly StaffDTO staff;
    private readonly UserDTO user;
    private ChangePasswordDialog changePasswordDialog;
    private LoginGUI loginView;
    private QuanLyNhanVienGUI quanLyNhanVienView;
    private QuanLyThuocGUI quanLyThuocView;
    private ThongTinCaNhanGUI thongTinCaNhanView;

    public MainGUI(UserDTO user, LoginGUI loginView, StaffDTO staff)
    {
        InitializeComponent();
        this.user = user;
        this.loginView = loginView;
        this.staff = staff;
    }

    private void btnQlyThuoc_Click(object sender, EventArgs e)
    {


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
            CustomMessageBox.ShowWarning("Bạn không có quyền truy cập chức năng này");
            return;
        }
        Show(ref quanLyNhanVienView, () => new QuanLyNhanVienGUI());
    }


    private void btnThongTin_Click(object sender, EventArgs e)
    {
        //Show(ref thongTinCaNhanView, () => new ThongTinCaNhanGUI(user, staff));
        var thongTinCaNhanView = new ThongTinCaNhanGUI(user, staff);
        thongTinCaNhanView.OnUpdate += ChangeTextWelcome;
        thongTinCaNhanView.ShowDialog();
    }

    public void ChangeTextWelcome()
    {
        lbWelcome.Text = string.Format(Resources.Hello_text, staff.name);
    }



    private void MainView_Load(object sender, EventArgs e)
    {
        ChangeTextWelcome();
        var currentDate = DateTime.Now;
        lbDate.Text = CustomDateTime.GetFormattedDate();
        lbTime.Text = DateTime.Now.ToString(Config.Instance.ConfigureFile.TimeFormat);

        var timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += (s, args) => { lbDate.Text = CustomDateTime.GetFormattedDate(); lbTime.Text = DateTime.Now.ToString(Config.Instance.ConfigureFile.TimeFormat); };
        timer.Start();
    }

    private void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (changePasswordDialog == null || changePasswordDialog.IsDisposed)
            changePasswordDialog = new ChangePasswordDialog(user);

        changePasswordDialog.ShowDialog();
        changePasswordDialog.WindowState = FormWindowState.Normal;
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        var confirmResult = CustomMessageBox.ShowQuestion(Resources.Logout_confirm);
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
        //btnTaiChinh.PerformClick();
    }

    private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var confirmResult = CustomMessageBox.ShowQuestion(Resources.Exit_confirm);
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
#if Production
        var result = CustomMessageBox.ShowQuestion(Resources.Exit_confirm);
        if (result == DialogResult.No) e.Cancel = true;
#endif
    }

    private void MainGUI_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }

    private void btnHoaDon_Click(object sender, EventArgs e)
    {
        Show(ref quanLyThuocView, () => new QuanLyThuocGUI(user, 4));
        quanLyThuocView.tabControl1.SelectTab(4);
    }
}