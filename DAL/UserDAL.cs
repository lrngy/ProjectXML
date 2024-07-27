using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.DAL
{
    public class UserDAL
    {
        // quyet them
        public int AddUser(UserDTO user)
        {
            try
            {
                // Kiểm tra tài khoản người dùng có tồn tại không
                if (this.CheckExistUserName(user.username))
                {
                    MessageBox.Show("username đã tồn tại!");
                    return Predefined.ERROR;
                }

                string query = "INSERT INTO users (username, password) VALUES (@username, @password)";
                SqlParameter[] parameters = {
                    new SqlParameter("@username", user.username),
                    new SqlParameter("@password", user.password)
                };

                int rowsAffected = DB.ExecuteNonQuery(query, parameters);

                return rowsAffected > 0 ? Predefined.SUCCESS : Predefined.ERROR;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi thêm người dùng: {ex.Message}", "Lỗi");
                return Predefined.ERROR;
            }
        }
        public int UpdateUser(string username, string oldUsername)
        {
            try
            {
                // Tạo câu lệnh SQL để cập nhật mật khẩu của người dùng
                string sqlQuery = "UPDATE users SET username = '@oldUsername' WHERE username = '@oldUsername'";

                // Tạo các tham số cho câu lệnh SQL
                SqlParameter[] parameters = new[]
                {
            new SqlParameter("@username", SqlDbType.VarChar) { Value = username },
            new SqlParameter("@oldUsername", SqlDbType.VarChar) { Value = oldUsername }
        };

                // Thực thi câu lệnh SQL
                // Giả sử bạn có một phương thức ExecuteNonQuery để thực hiện lệnh SQL
                int rowsAffected = DB.ExecuteNonQuery(sqlQuery, parameters);

                // Kiểm tra số hàng bị ảnh hưởng
                if (rowsAffected > 0)
                {
                    return Predefined.SUCCESS;
                }
                else
                {
                    // Không tìm thấy bản ghi để cập nhật
                    return Predefined.ERROR;
                }
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi nếu có
                Debug.WriteLine($"Update user failed: {ex.Message}");
                return Predefined.ERROR;
            }
        }
        public int DeleteUser(string username)
        {
            try
            {
                // Kiểm tra tài khoản người dùng có tồn tại không
                if (!this.CheckExistUserName(username))
                {
                    MessageBox.Show("username không tồn tại!");
                    return Predefined.ERROR;
                }

                string query = $"DELETE FROM users WHERE username = '@username'";
                SqlParameter[] parameters = { new SqlParameter("@username", username) };

                int rowsAffected = DB.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("rowsAffected > 0");
                    return Predefined.SUCCESS;
                }
                else
                {
                    MessageBox.Show("rowsAffected = 0");
                    return Predefined.ERROR;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xóa người dùng: {ex.Message}", "Lỗi");
                return Predefined.ERROR;
            }
        }
        public bool CheckExistUserName(string username)
        {
            try
            {
                string query = $"SELECT * FROM users where username = '{username}'";
                DataTable dt = DB.ExecuteQuery(query);
                if (dt.Rows.Count == 0) return false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi kiểm tra người dùng: {ex.Message}", "Lỗi");
                return false;
            }
        }
        // end quyet
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
