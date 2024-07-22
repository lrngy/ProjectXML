using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.DAL
{
    public class LoginDAL
    {
        public bool isExistAccount(string username, string password)
        {
            string query = $"SELECT * FROM users WHERE username = @username AND password = @password";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };
            DataTable dt = DB.ExecuteQuery(query, sqlParameters);
            return dt.Rows.Count != 0;
        }

        public bool Login(UserDTO user)
        {
            string query = "INSERT INTO login_log(login_log_id, username, login_time) VALUES(@id, @username, @loginTime)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id", user.guid),
                new SqlParameter("@username", user.username),
                new SqlParameter("@loginTime", CustomDateTime.GetNow()),
            };
            return DB.ExecuteNonQuery(query, sqlParameters) == 1;
        }

        public bool Logout(UserDTO user)
        {
           
            string query = "UPDATE login_log SET logout_time = @logoutTime WHERE login_log_id = @id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id", user.guid),
                new SqlParameter("@logoutTime", CustomDateTime.GetNow()),
            };
            return DB.ExecuteNonQuery(query, sqlParameters) == 1;
        }

        public LoginLog GetLoginLog()
        {
            string query = "select top 1 * from login_log order by login_time desc";
            DataTable dt = DB.ExecuteQuery(query);
            if(dt.Rows.Count == 0)
            {
                return null;
            }
            string id = dt.Rows[0]["login_log_id"].ToString();
            string username = dt.Rows[0]["username"].ToString();
            string loginTime = dt.Rows[0]["login_time"].ToString();
            string logoutTime = dt.Rows[0]["logout_time"].ToString();
            return new LoginLog(id, username, loginTime, logoutTime);
        }
    }
}