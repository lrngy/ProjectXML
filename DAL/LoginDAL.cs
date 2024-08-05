
namespace QPharma.DAL
{
    public class LoginDAL
    {

        public bool Login(UserDTO user)
        {
            var query = "INSERT INTO login_log(login_log_id, username, login_time) VALUES(@id, @username, @loginTime)";
            SqlParameter[] sqlParameters =
            {
            new SqlParameter("@id", user.guid),
            new SqlParameter("@username", user.username),
            new SqlParameter("@loginTime", CustomDateTime.GetNow())
        };
            return DB.ExecuteNonQuery(query, sqlParameters) == 1;
        }

        public bool Logout(UserDTO user)
        {

            var query = "UPDATE login_log SET logout_time = @logoutTime WHERE login_log_id = @id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id", user.guid),
                new SqlParameter("@logoutTime", CustomDateTime.GetNow())
            };
            return DB.ExecuteNonQuery(query, sqlParameters) == 1;
        }

        public LoginLog GetLoginLog()
        {
            var query = "select top 1 * from login_log order by login_time desc";
            var dt = DB.ExecuteQuery(query);
            if (dt.Rows.Count == 0) return null;
            var id = dt.Rows[0]["login_log_id"].ToString();
            var username = dt.Rows[0]["username"].ToString();
            var loginTime = dt.Rows[0]["login_time"].ToString();
            var logoutTime = dt.Rows[0]["logout_time"].ToString();
            return new LoginLog(id, username, loginTime, logoutTime);
        }
    }
}