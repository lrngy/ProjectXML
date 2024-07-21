using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.DAL
{
    public class UserDAL
    {
        public UserDTO GetUser(string username)
        {
            UserDTO user = null;
            try
            {
                string query = "SELECT * FROM users WHERE username = @username";
                SqlParameter[] parameters = { new SqlParameter("@username", username) };
                DataTable dt = DB.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    user = new UserDTO
                    {
                        username = dt.Rows[0]["username"].ToString(),
                        password = dt.Rows[0]["password"].ToString(),

                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting user: {ex.Message}");
            }

            return user;
        }

        public int Update(UserDTO user, StaffDTO staff)
        {
            try
            {
                var query = new Dictionary<string, SqlParameter[]>
                {
                    {
                        "UPDATE users SET password = @password WHERE username = @username",
                          new[] { new SqlParameter("@password", user.password), new SqlParameter("@username", user.username)
                    } 
                },
                    {
                    "UPDATE staffs SET staff_name = @staffName, staff_year_of_birth = @staffYearOfBirth, staff_sex = @staffSex WHERE staff_id = @staffId",
                    new []
                        {
                             new SqlParameter("@staffName", staff.name),
                             new SqlParameter("@staffYearOfBirth", staff.birthday),
                             new SqlParameter("@staffSex", staff.gender),
                             new SqlParameter("@staffId", staff.id)
                         }
                    }
                };
                DB.ExecuteTransaction(query);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Update user failed: {ex.Message}");
                return Predefined.ERROR;
            }
        }

        internal int UpdatePassword(UserDTO user)
        {
            try
            {
                string query = "UPDATE users SET password = @password WHERE username = @username";
                SqlParameter[] parameters = { new SqlParameter("@password", user.password), new SqlParameter("@username", user.username) };
                DB.ExecuteNonQuery(query, parameters);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Update password failed: {ex.Message}");
                return Predefined.ERROR;
            }
        }
    }
}
