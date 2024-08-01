using System;
using System.Windows.Forms;
using QPharma.BUS;
using QPharma.DTO;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma.GUI
{
    public partial class SplashGUI : BaseForm
    {
        private readonly LoginBUS loginBUS = new LoginBUS();
        private readonly LoginGUI loginGUI = new LoginGUI();
        private readonly double opacityIncrement = Development.Default.OpacityIncrement;
        private readonly StaffBUS staffBUS = new StaffBUS();
        private readonly UserBUS userBUS = new UserBUS();
        private Timer delayTimer;
        private MainGUI mainGUI;

        public SplashGUI()
        {
            InitializeComponent();
            // this.TopMost = false;
        }

        private void StartMainGUI(UserDTO user)
        {
            var staff = staffBUS.GetByUsername(user.username);
            if (staff is null)
            {
                loginGUI.Show();
                return;
            }

            if (mainGUI == null || mainGUI.IsDisposed) mainGUI = new MainGUI(user, null, staff);
            mainGUI.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
            {
                Opacity += opacityIncrement;
                return;
            }

            timer1.Stop();

            delayTimer = new Timer();
            delayTimer.Interval = Development.Default.DelayTimerSplash;
            delayTimer.Tick += DelayTimer_Tick;
            delayTimer.Start();
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            delayTimer.Dispose();

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
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowError(Resources.Database_connection_error);
                Application.Exit();
            }
            finally
            {
                Hide();
            }
        }

        private void SplashGUI_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}