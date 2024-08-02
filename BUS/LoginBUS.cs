namespace QPharma.BUS;

public class LoginBUS
{
    private readonly LoginDAL loginDAL = new();
    private readonly UserDAL userDAL = new();

    public UserDTO CheckExist(string username, string password)
    {
        return loginDAL.isExistAccount(username, password) ? userDAL.GetUser(username) : null;
    }

    public bool Login(UserDTO user)
    {
        return loginDAL.Login(user);
    }

    public bool Logout(UserDTO user)
    {
        return loginDAL.Logout(user);
    }

    public LoginLog CheckLoggedIn()
    {
        var loginLog = loginDAL.GetLoginLog();
        if (loginLog == null)
            return null;

        var currentTime = CustomDateTime.GetNow();
        var loginTime = loginLog.loginTime;

        var timeSpan = CustomDateTime.CompareDateTime(currentTime, loginTime);
        if (timeSpan.TotalMinutes <= Development.Default.SessionDurationMinute &&
            string.IsNullOrEmpty(loginLog.logoutTime)) return loginLog;
        return null;
    }
}