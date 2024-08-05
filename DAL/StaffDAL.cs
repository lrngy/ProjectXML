
namespace QPharma.DAL
{
    // Lớp csdl
    internal static class StaffDAL
    {
        // Lấy tất cả
        public static List<StaffDTO> GetAll()
        {
            var list = new List<StaffDTO>();
            try
            {
                var query = "SELECT * FROM staffs";
                var dt = DB.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["staff_id"].ToString();
                    var name = dr["staff_name"].ToString();
                    var sex = bool.Parse(dr["staff_sex"].ToString());
                    var yearOfBirth = dr["staff_year_of_birth"].ToString();
                    var isManager = bool.Parse(dr["staff_is_manager"].ToString());
                    var isSeller = bool.Parse(dr["staff_is_seller"].ToString());
                    var username = dr["username"].ToString();

                    var staff_created = dr["staff_created"].ToString();
                    var staff_updated = dr["staff_updated"].ToString();
                    var staff_deleted = dr["staff_deleted"].ToString();

                    var staff = new StaffDTO(id, name, sex, yearOfBirth, isManager, isSeller, username, staff_created,
                        staff_updated, staff_deleted);
                    list.Add(staff);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lấy thông tin nhân viên thất bại!");
            }

            return list;
        }

        // tìm kiếm
        public static List<StaffDTO> Search(string searchText)
        {
            var list = new List<StaffDTO>();
            try
            {
                string query = @"SELECT * FROM staffs
                                    WHERE
                                        staff_deleted IS NULL AND
                                        (
                                            LOWER(staff_id) LIKE '%' + LOWER(@searchText) + '%' OR
                                            LOWER(staff_name) LIKE '%' + LOWER(@searchText) + '%' OR
                                            LOWER(staff_sex) LIKE '%' + LOWER(@searchText) + '%' OR
                                            LOWER(staff_year_of_birth) LIKE '%' + LOWER(@searchText) + '%' OR
                                            LOWER(staff_is_manager) LIKE '%' + LOWER(@searchText) + '%' OR
                                            LOWER(staff_is_seller) LIKE '%' + LOWER(@searchText) + '%'
                                        );
                                ";

                SqlParameter[] sqlParameters = { new SqlParameter("@searchText", searchText) };
                var dt = DB.ExecuteQuery(query, sqlParameters);
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["staff_id"].ToString();
                    var name = dr["staff_name"].ToString();
                    var sex = dr["staff_sex"].ToString() == "1";
                    var yearOfBirth = dr["staff_year_of_birth"].ToString();
                    var isManager = bool.Parse(dr["staff_is_manager"].ToString());
                    var isSeller = bool.Parse(dr["staff_is_seller"].ToString());
                    var username = dr["username"].ToString();

                    var staff_created = dr["staff_created"].ToString();
                    var staff_updated = dr["staff_updated"].ToString();
                    var staff_deleted = dr["staff_deleted"].ToString();

                    var staff = new StaffDTO(id, name, sex, yearOfBirth, isManager, isSeller, username, staff_created,
                        staff_updated, staff_deleted);
                    list.Add(staff);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lấy thông tin nhân viên thất bại!");
            }

            return list;
        }

        // Lấy bởi tên id
        public static StaffDTO GetById(string id)
        {
            StaffDTO staffDTO = null;
            try
            {
                var query = $"SELECT * FROM staffs where staff_id = '{id}'";
                var dt = DB.ExecuteQuery(query);
                if (dt.Rows.Count != 0)
                {
                    var name = dt.Rows[0]["staff_name"].ToString();
                    var sex = dt.Rows[0]["staff_sex"].ToString() == "1";
                    var yearOfBirth = dt.Rows[0]["staff_year_of_birth"].ToString();
                    var isManager = bool.Parse(dt.Rows[0]["staff_is_manager"].ToString());
                    var isSeller = bool.Parse(dt.Rows[0]["staff_is_seller"].ToString());
                    var username = dt.Rows[0]["username"].ToString();

                    var staff_created = dt.Rows[0]["staff_created"].ToString();
                    var staff_updated = dt.Rows[0]["staff_updated"].ToString();
                    var staff_deleted = dt.Rows[0]["staff_deleted"].ToString();

                    staffDTO = new StaffDTO(id, name, sex, yearOfBirth, isManager, isSeller, username, staff_created,
                        staff_updated, staff_deleted);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy thông tin nhân viên qua id thất bại!" + "\n" + ex.Message);
            }

            return staffDTO;
        }

        // Lấy bởi tên người dùng
        public static StaffDTO GetByUsername(string username)
        {
            StaffDTO staffDTO = null;
            try
            {
                var query = $"SELECT * FROM staffs where username = '{username}'";
                var dt = DB.ExecuteQuery(query);
                if (dt.Rows.Count != 0)
                {
                    var id = dt.Rows[0]["staff_id"].ToString();
                    var name = dt.Rows[0]["staff_name"].ToString();
                    var sex = bool.Parse(dt.Rows[0]["staff_sex"].ToString());
                    var yearOfBirth = dt.Rows[0]["staff_year_of_birth"].ToString();
                    var isManager = bool.Parse(dt.Rows[0]["staff_is_manager"].ToString());
                    var isSeller = bool.Parse(dt.Rows[0]["staff_is_seller"].ToString());

                    var staff_created = dt.Rows[0]["staff_created"].ToString();
                    var staff_updated = dt.Rows[0]["staff_updated"].ToString();
                    var staff_deleted = dt.Rows[0]["staff_deleted"].ToString();

                    staffDTO = new StaffDTO(id, name, sex, yearOfBirth, isManager, isSeller, username, staff_created,
                        staff_updated, staff_deleted);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error getting staff by username:" + ex);
            }

            return staffDTO;
        }

        // Kiểm tra tồn tại
        public static bool CheckExistUsername(string username)
        {
            var query = $"SELECT * FROM users where username = '{username}'";
            var dt = DB.ExecuteQuery(query);
            if (dt.Rows.Count == 0) return false;
            return true;
        }

        // Chèn
        public static int Insert(StaffDTO staffDTO)
        {
            try
            {
                var query =
                    "INSERT INTO staffs(staff_id, staff_name, staff_sex, staff_year_of_birth, " +
                    "staff_is_manager, staff_is_seller, staff_created, staff_updated, staff_deleted, username)" +
                    "VALUES(@staff_id, @staff_name, @staff_sex, @staff_year_of_birth, @staff_is_manager, @staff_is_seller," +
                    " @staff_created, @staff_updated, @staff_deleted, @username )";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@staff_id", staffDTO.id),
                    new SqlParameter("@staff_name", staffDTO.name),
                    new SqlParameter("@staff_sex", staffDTO.gender),
                    new SqlParameter("@staff_year_of_birth", staffDTO.birthday),
                    new SqlParameter("@staff_is_manager", staffDTO.isManager),
                    new SqlParameter("@staff_is_seller", staffDTO.isSeller),
                    new SqlParameter("@staff_created", CustomDateTime.GetNow()),
                    new SqlParameter("@staff_updated", DBNull.Value),
                    new SqlParameter("@staff_deleted", DBNull.Value),
                    new SqlParameter("@username", staffDTO.username)
                };

                // add user
                if (CheckExistUsername(staffDTO.username))
                {
                    MessageBox.Show("username đã tồn tại!");
                    return Predefined.ERROR;
                }

                string hashPassword = BCrypt.Net.BCrypt.HashPassword("1");
                string query2 = "INSERT INTO users (username, hash_pw) VALUES (@username, @password)";

                if (DB.ExecuteNonQuery(query2,
                        new SqlParameter[]
                        {
                            new SqlParameter("@username", staffDTO.username),
                            new SqlParameter("@password", hashPassword)
                        }) <= 0)
                {
                    MessageBox.Show("Thêm người dùng thất bại!");
                    return Predefined.ERROR;
                }

                if (DB.ExecuteNonQuery(query, parameters) <= 0)
                {
                    MessageBox.Show("Thêm nhân viên thất bại!");
                    return Predefined.ERROR;
                }
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        // Cập nhật
        public static int Update(StaffDTO staffDTO)
        {
            try
            {
                var query = "UPDATE staffs " +
                            " SET staff_name=@staff_name, staff_sex=@staff_sex, staff_year_of_birth=@staff_year_of_birth, " +
                            "staff_is_manager=@staff_is_manager, staff_is_seller=@staff_is_seller, staff_created= @staff_created, " +
                            "staff_updated=@staff_updated, staff_deleted=@staff_deleted, username=@username WHERE staff_id=@staff_id";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@staff_id", staffDTO.id),
                    new SqlParameter("@staff_name", staffDTO.name),
                    new SqlParameter("@staff_sex", staffDTO.gender),
                    new SqlParameter("@staff_year_of_birth", staffDTO.birthday),
                    new SqlParameter("@staff_is_manager", staffDTO.isManager),
                    new SqlParameter("@staff_is_seller", staffDTO.isSeller),
                    new SqlParameter("@staff_created", SqlDbType.DateTime)
                    {
                        Value = DateTime.TryParse(GetByUsername(staffDTO.username).staff_created,
                            out DateTime parsedDate)
                            ? (object)parsedDate
                            : DBNull.Value
                    },
                    new SqlParameter("@staff_updated", CustomDateTime.GetNow()),
                    new SqlParameter("@staff_deleted", DBNull.Value),
                    new SqlParameter("@username", staffDTO.username)
                };

                if (DB.ExecuteNonQuery(query, parameters) <= 0) return Predefined.ERROR;
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        internal static int Delete(string id)
        {
            try
            {
                var query = $"UPDATE staffs SET staff_deleted = '{CustomDateTime.GetNow()}' WHERE staff_id = '{id}'";
                if (DB.ExecuteNonQuery(query) <= 0) return Predefined.ERROR;
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        // Khôi phục
        internal static int Restore(string currentUsername)
        {
            try
            {
                var query = $"UPDATE staffs SET staff_deleted = null WHERE username = @username";
                if (DB.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@username", currentUsername) }) <=
                    0) return Predefined.ERROR;

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        internal static int ForceDelete(string username)
        {
            try
            {
                var query = $"DELETE FROM staffs WHERE username = '{username}'";

                string query2 = $"DELETE FROM login_log WHERE username = @username";
                SqlParameter[] parameters2 = { new SqlParameter("@username", username) };

                string query3 = $"DELETE FROM users WHERE username = @username";
                SqlParameter[] parameters = { new SqlParameter("@username", username) };

                if (DB.ExecuteNonQuery(query) <= 0) return Predefined.ERROR;
                if (DB.ExecuteNonQuery(query2, parameters2) < 0) MessageBox.Show("Xóa log thất bại!");

                if (DB.ExecuteNonQuery(query3, parameters) <= 0) MessageBox.Show("Xóa người dùng thất bại!");

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        // Khôi phục lại tất cả
        internal static int RestoreAll()
        {
            try
            {
                var query = "UPDATE staffs SET staff_deleted = null";
                if (DB.ExecuteNonQuery(query) <= 0) return Predefined.ERROR;

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        internal static int ForceAllDelete()
        {
            try
            {
                var query = $"DELETE FROM staffs WHERE staff_deleted IS NOT NULL";
                if (DB.ExecuteNonQuery(query) <= 0) return Predefined.ERROR;

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }
    }
}