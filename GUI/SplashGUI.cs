namespace QPharma.GUI;

public partial class SplashGUI : BaseForm
{
    private readonly LoginBUS loginBUS = new();
    private readonly LoginGUI loginGUI = new();
    private readonly double opacityIncrement =  Config.Instance.ConfigureFile.OpacityIncrement;
    private readonly StaffBUS staffBUS = new();
    private readonly UserBUS userBUS = new();
    private Timer delayTimer;
    private MainGUI mainGUI;

        public SplashGUI()
        {
            InitializeComponent();
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
        delayTimer.Interval =  Config.Instance.ConfigureFile.DelayTimerSplash;
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