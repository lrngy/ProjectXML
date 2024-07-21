using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
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
    }
}