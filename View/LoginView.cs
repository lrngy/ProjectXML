using ProjectXML.Controller;
using ProjectXML.DAO;
using ProjectXML.Model;
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
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
        }
        LoginController loginController = new LoginController();

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QuanLyThuocView(new LoginController().CheckExist("admin", "1")));
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = tbPassword.PasswordChar == '*' ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lbError.Text = "";
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();
            bool isEmptyField = username.Equals("") || password.Equals("");
            if (isEmptyField)
            {
                lbError.Text = "Vui lòng nhập đầy đủ thông tin";
                return;
            }

            User user = loginController.CheckExist(username, password);
            if (user is null)
            {
                lbError.Text = "Tài khoản hoặc mật khẩu không chính xác";
            }
            else
            {
                MainView mainView = new MainView(user);
                mainView.FormClosed += new FormClosedEventHandler((_sender, _formClosed) =>
                {
                    Application.Exit();
                });
                mainView.Show();
                this.Hide();
            }


        }

        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
