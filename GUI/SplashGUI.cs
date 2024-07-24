using System;
using System.Threading;
using System.Windows.Forms;
using ProjectXML.BUS;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.GUI
{
    public partial class SplashGUI : Form
    {
        private readonly LoginBUS loginBUS = new LoginBUS();
        private readonly LoginGUI loginGUI = new LoginGUI();
        private readonly StaffBUS staffBUS = new StaffBUS();
        private readonly UserBUS userBUS = new UserBUS();
        private MainGUI mainGUI;
        private double opacityIncrement = 0.05;


        public SplashGUI()
        {
            InitializeComponent();
            loginGUI.FormClosed += (_sender, _formClosed) => { Application.Exit(); };
        }


        private void StartMainGUI(UserDTO user)
        {
            var staff = staffBUS.GetByUsername(user.username);
            if (staff is null)
            {
                loginGUI.Show();
                return;
            }

            if (mainGUI == null || mainGUI.IsDisposed)
            {
                mainGUI = new MainGUI(user, null, staff);

                mainGUI.FormClosed += (_sender, _formClosed) => { Application.Exit(); };
            }

            mainGUI.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += opacityIncrement;
                return;
            }
            else
            {
                timer1.Stop();
                Hide();
                try
                {
                    var log = loginBUS.CheckLoggedIn();
                    if (log is null)
                    {
                        loginGUI.Show();
                        return;
                    }

                    var user = userBUS.getUser(log.username);
                    user.guid = log.id;
                    StartMainGUI(user);
                } catch (Exception ex)
                {
                    CustomMessageBox.ShowError(Properties.Resources.DatabaseConnectionError);
                    Application.Exit();
                }
            }
        }

        private void SplashGUI_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}