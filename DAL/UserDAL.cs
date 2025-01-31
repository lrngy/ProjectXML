
namespace QPharma.DAL
{
    public class UserDAL
    {
        public UserDTO GetByUsername(string username)
        {
            UserDTO user = null;
            try
            {
                var query = "SELECT * FROM users WHERE username = @username";
                SqlParameter[] parameters = { new SqlParameter("@username", username) };
                var dt = DB.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                    user = new UserDTO
                    {
                        username = dt.Rows[0]["username"].ToString(),
                        hashPassword = dt.Rows[0]["hash_pw"].ToString()
                    };
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
                        "UPDATE users SET hash_pw = @password WHERE username = @username",
                        new[]
                        {
                            new SqlParameter("@password", user.hashPassword), new SqlParameter("@username", user.username)
                        }
                    },
                    {
                        "UPDATE staffs SET staff_name = @staffName, staff_year_of_birth = @staffYearOfBirth, staff_sex = @staffSex WHERE staff_id = @staffId",
                        new[]
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
        public static int UpdatePassword(UserDTO user)
        {
            try
            {
                var query = "UPDATE users SET hash_pw = @password WHERE username = @username";
                SqlParameter[] parameters =
                    { new SqlParameter("@password", user.hashPassword), new SqlParameter("@username", user.username) };
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