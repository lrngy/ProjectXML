namespace QPharma.GUI;

public partial class LoginGUI : BaseForm
{
    private readonly LoginBUS loginBus = new();
    private readonly StaffBUS staffBus = new();
    private readonly UserBUS userBUS = new();
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
            lbError.Text = Resources.Please_enter_complete_info;
            return;
        }

        var user = loginBus.CheckExist(username, password);
        if (user is null)
        {
            lbError.Text = Resources.Wrong_username_or_password;
            return;
        }

        tbUsername.Text = "";
        tbUsername.Focus();
        tbPassword.Text = "";
        user.guid = Guid.NewGuid().ToString();


        var isLoggedIn = loginBus.Login(user);
        if (!isLoggedIn) lbError.Text = Resources.Login_fail;

        var staff = staffBus.GetByUsername(user.username);
        if (staff is null)
        {
            lbError.Text = Resources.Account_not_valid;
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

    private void LoginGUI_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }
}