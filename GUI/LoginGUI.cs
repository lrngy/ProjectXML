using System;
using System.Windows.Forms;
using ProjectXML.BUS;
using ProjectXML.DTO;
using ProjectXML.Properties;

namespace ProjectXML.GUI
{
    public partial class LoginGUI : Form
    {
        private readonly LoginBUS loginBus = new LoginBUS();
        private readonly StaffBUS staffBus = new StaffBUS();
        private readonly UserBUS userBUS = new UserBUS();
        private MainGUI mainView;


        public LoginGUI()
        {
            InitializeComponent();
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
                lbError.Text = Resources.PleaseEnterCompleteInfo;
                return;
            }

            var user = loginBus.CheckExist(username, password);
            if (user is null)
            {
                lbError.Text = Resources.WrongUsernameOrPassword;
                return;
            }

            tbUsername.Text = "";
            tbUsername.Focus();
            tbPassword.Text = "";
            user.guid = Guid.NewGuid().ToString();


            var isLoggedIn = loginBus.Login(user);
            if (!isLoggedIn)
            {
                lbError.Text = Resources.LoginFail;
            }

            var staff = staffBus.GetByUsername(user.username);
            if (staff is null)
            {
                lbError.Text = Resources.AccountNotValid;
                return;
            }

            if (mainView == null || mainView.IsDisposed)
            {
                mainView = new MainGUI(user, this, staff);

                mainView.FormClosed += (_sender, _formClosed) => { Application.Exit(); };
            }
            Hide();
            mainView.Show();
        }


        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            lbError.Text = "";
            if (e.KeyCode == Keys.Enter) btnLogin.PerformClick();
        }
    }
}