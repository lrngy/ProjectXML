using System;
using System.Windows.Forms;
using ProjectXML.BUS;

namespace ProjectXML.GUI
{
    public partial class LoginGUI : Form
    {
        private readonly LoginBUS loginController = new LoginBUS();
        private MainGUI mainView;

        public LoginGUI()
        {
            InitializeComponent();
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginGUI());
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = tbPassword.PasswordChar == '*' ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lbError.Text = "";
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();
            var isEmptyField = username.Equals("") || password.Equals("");
            if (isEmptyField)
            {
                lbError.Text = "Vui lòng nhập đầy đủ thông tin";
                return;
            }

            var user = loginController.CheckExist(username, password);
            if (user is null)
            {
                lbError.Text = "Tài khoản hoặc mật khẩu không chính xác";
                return;
            }

            tbUsername.Text = "";
            tbUsername.Focus();
            tbPassword.Text = "";


            if (mainView == null || mainView.IsDisposed) mainView = new MainGUI(user, this);
            mainView.FormClosed += (_sender, _formClosed) => { Application.Exit(); };
            mainView.Show();
            Hide();
        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            lbError.Text = "";
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }
    }
}