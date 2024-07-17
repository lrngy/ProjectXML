using System;
using System.Data;
using System.Xml;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.DAL
{
    public class UserDAL
    {
        private XmlDocument staffDoc;
        private XmlDocument userDoc;

        public void ReLoadData()
        {
            userDoc = Config.getDoc("users");
            staffDoc = Config.getDoc("staffs");
        }

        public UserDTO getUser(string username)
        {
            ReLoadData();
            UserDTO user = null;
            try
            {
                //var xPathUsers = $"//user[username='{username}']";
                //var accountNode = userDoc.SelectSingleNode(xPathUsers);
                //var password = accountNode.SelectSingleNode("password").InnerText;

                //var staffId = accountNode.SelectSingleNode("staff_id").InnerText;
                //var xPathStaffs = $"//staff[staff_id='{staffId}']";
                //var staffNode = staffDoc.SelectSingleNode(xPathStaffs);

                //var staff = new StaffDTO(
                //    staffId,
                //    staffNode.SelectSingleNode("staff_name").InnerText,
                //    staffNode.SelectSingleNode("staff_sex").InnerText.Equals("Nam") ? true : false,
                //    staffNode.SelectSingleNode("staff_year_of_birth").InnerText,
                //    staffNode.SelectSingleNode("staff_is_manager").InnerText.Equals("true") ? true : false,
                //    staffNode.SelectSingleNode("staff_is_seller").InnerText.Equals("true") ? true : false
                //);

                //return new UserDTO(username, password, staff);
                string query = $"SELECT * FROM users WHERE username = '{username}'";
                DataTable dt = DB.ExecuteQuery(query);
                if (dt.Rows.Count != 0)
                {
                    user = new UserDTO();
                    user.username = dt.Rows[0]["username"].ToString();
                    user.password = dt.Rows[0]["password"].ToString();
                    var staffId = dt.Rows[0]["staff_id"].ToString();
                    
                    StaffDTO staff = new StaffDAL().GetById(staffId);
                    user.staff = staff;
                    return user;
                }

             
            }
            catch (Exception)
            {
            }

            return user;
        }

        internal int Update(UserDTO user)
        {
            ReLoadData();
            try
            {
                var staffNode = staffDoc.SelectSingleNode($"//staff[staff_id='{user.staff.id}']");
                staffNode.SelectSingleNode("staff_name").InnerText = user.staff.name;
                staffNode.SelectSingleNode("staff_year_of_birth").InnerText = user.staff.birthday;
                staffNode.SelectSingleNode("staff_sex").InnerText = user.staff.gender ? "Nam" : "Nữ";
                staffDoc.Save(Config.getXMLPath("staffs"));


                var xPathUsers = $"//user[username='{user.username}']";
                var accountNode = userDoc.SelectSingleNode(xPathUsers);
                accountNode.SelectSingleNode("password").InnerText = user.password;
                userDoc.Save(Config.getXMLPath("users"));
                return Predefined.SUCCESS;
            }
            catch (Exception)
            {
                return Predefined.FILE_NOT_FOUND;
            }
        }
    }
}