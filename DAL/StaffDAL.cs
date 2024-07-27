using ProjectXML.DTO;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjectXML.DAL
{
    // Lớp csdl
    internal class StaffDAL 
    {
        // Lấy tất cả
        public List<StaffDTO> GetAll()
        {
            var list = new List<StaffDTO>();
            try
            {
                string query = "SELECT * FROM staffs";
                DataTable dt = DB.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["staff_id"].ToString();
                    var name = dr["staff_name"].ToString();
                    var sex = dr["staff_sex"].ToString() == "1";
                    var yearOfBirth = dr["staff_year_of_birth"].ToString();
                    var isManager = bool.Parse(dr["staff_is_manager"].ToString());
                    var isSeller = bool.Parse(dr["staff_is_seller"].ToString());
                    var username = dr["username"].ToString();
                    //var created = dr["staff_created"].ToString();
                    //var updated = dr["staff_updated"].ToString();
                    //var deleted = dr["staff_deleted"].ToString();


                    StaffDTO staff = new StaffDTO(id, name, sex, yearOfBirth, isManager, isSeller, username);

                    list.Add(staff);
                }
            }
            catch (Exception)
            {
            }

            return list;
        }

        // Lấy bởi tên id
        public StaffDTO GetById(string id)
        {

            StaffDTO staffDTO = null;
            try
            {
                string query = $"SELECT * FROM staffs where staff_id = {id}";
                DataTable dt = DB.ExecuteQuery(query);
                if (dt.Rows.Count != 0)
                {
                    var name = dt.Rows[0]["staff_name"].ToString();
                    var sex = dt.Rows[0]["staff_sex"].ToString() == "1";
                    var yearOfBirth = dt.Rows[0]["staff_year_of_birth"].ToString();
                    var isManager = bool.Parse(dt.Rows[0]["staff_is_manager"].ToString());
                    var isSeller = bool.Parse(dt.Rows[0]["staff_is_seller"].ToString());
                    var username = dt.Rows[0]["username"].ToString();
                    //var created = dr["staff_created"].ToString();
                    //var updated = dr["staff_updated"].ToString();
                    //var deleted = dr["staff_deleted"].ToString();

                    staffDTO = new StaffDTO(id, name, sex, yearOfBirth, isManager, isSeller, username);
                }
            }
            catch (Exception)
            {
            }

            return staffDTO;
        }

        // Lấy bởi tên người dùng
        public StaffDTO GetByUsername(string username)
        {

            StaffDTO staffDTO = null;
            try
            {
                string query = $"SELECT * FROM staffs where username = '{username}'";
                DataTable dt = DB.ExecuteQuery(query);
                if (dt.Rows.Count != 0)
                {
                    var id = dt.Rows[0]["staff_id"].ToString();
                    var name = dt.Rows[0]["staff_name"].ToString();
                    var sex = bool.Parse(dt.Rows[0]["staff_sex"].ToString());
                    var yearOfBirth = dt.Rows[0]["staff_year_of_birth"].ToString();
                    var isManager = bool.Parse(dt.Rows[0]["staff_is_manager"].ToString());
                    var isSeller = bool.Parse(dt.Rows[0]["staff_is_seller"].ToString());
                    //var username = dt.Rows[0]["username"].ToString();
                    //var created = dr["staff_created"].ToString();
                    //var updated = dr["staff_updated"].ToString();
                    //var deleted = dr["staff_deleted"].ToString();
                    staffDTO = new StaffDTO(id, name, sex, yearOfBirth, isManager, isSeller, username);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error getting staff by username:" + ex);
            }

            return staffDTO;
        }

        // Kiểm tra tồn tại
        public bool CheckExist(string id)
        {

            string query = $"SELECT * FROM staffs where staff_id = {id}";
            DataTable dt = DB.ExecuteQuery(query);
            if (dt.Rows.Count == 0) return false;
            return true;
        }

        // Chèn
        public int Insert(StaffDTO staffDTO)
        {
            try
            {
                // Chuỗi ngày tháng ban đầu
                string dateString = staffDTO.birthday;

                // Chuyển đổi thành đối tượng DateTime
                DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                // Chuyển đổi thành định dạng "yy MM dd"
                string formattedDate = date.ToString("yyyy-MM-dd");

                string query = $"INSERT INTO QlyHieuThuoc.dbo.staffs(staff_id, staff_name, staff_sex, staff_year_of_birth, staff_is_manager, staff_is_seller, staff_created, staff_updated, staff_deleted, username)" +
                    $"VALUES('{staffDTO.id}', '{staffDTO.name}', '{staffDTO.gender}', '{formattedDate}', '{staffDTO.isManager}', '{staffDTO.isSeller}', '', '', '', '{staffDTO.username}')";

                MessageBox.Show(query);
                if (DB.ExecuteQuery(query, null) == null) return Predefined.ERROR;
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        // Cập nhật
        public int Update(StaffDTO staffDTO)
        {

            try
            {
                string query = $"UPDATE QlyHieuThuoc.dbo.staffs" +
                    $"SET staff_name='{staffDTO.name}', staff_sex={staffDTO.gender}, " +
                    $"staff_year_of_birth='{staffDTO.birthday}', staff_is_manager={staffDTO.isManager}, " +
                    $"staff_is_seller={staffDTO.isSeller}, staff_created='', staff_updated='', staff_deleted='', " +
                    $"username='{staffDTO.username}' WHERE staff_id='{staffDTO.id}'";

                if (DB.ExecuteQuery(query, null) == null) return Predefined.ERROR;
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        // Xóa bỏ
        internal int Delete(string id)
        {

            try
            {
                string query = $"UPDATE staffs SET staff_deleted = '{CustomDateTime.GetNow()}' WHERE staff_id = '{id}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        // Khôi phục
        internal int Restore(string id)
        {

            try
            {
                string query = $"UPDATE staffs SET staff_deleted = '' WHERE staff_id = '{id}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        // Buộc xóa
        internal int ForceDelete(string id)
        {
            try
            {
                //var supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                //supplierNode.ParentNode.RemoveChild(supplierNode);
                //supplierDoc.Save(Config.getXMLPath("suppliers"));

                string query = $"DELETE FROM staffs WHERE staff_id = '{id}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        // Khôi phục lại tất cả
        internal int RestoreAll()
        {
          
            try
            {
                //var categoryNodes = categoryDoc.SelectNodes("/categories/category");
                //foreach (XmlNode categoryNode in categoryNodes)
                //    categoryNode.SelectSingleNode("category_deleted").InnerText = "";
                //categoryDoc.Save(Config.getXMLPath("categories"));

                string query = $"UPDATE staffs SET staff_deleted = ''";
                DB.ExecuteNonQuery(query);

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
