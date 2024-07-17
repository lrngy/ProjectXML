using System;
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
            try
            {
                var xPathUsers = $"//user[username='{username}']";
                var accountNode = userDoc.SelectSingleNode(xPathUsers);
                var password = accountNode.SelectSingleNode("password").InnerText;

                var staffId = accountNode.SelectSingleNode("staff_id").InnerText;
                var xPathStaffs = $"//staff[staff_id='{staffId}']";
                var staffNode = staffDoc.SelectSingleNode(xPathStaffs);

                var staff = new StaffDTO(
                    staffId,
                    staffNode.SelectSingleNode("staff_name").InnerText,
                    staffNode.SelectSingleNode("staff_sex").InnerText.Equals("Nam") ? true : false,
                    staffNode.SelectSingleNode("staff_year_of_birth").InnerText,
                    staffNode.SelectSingleNode("staff_is_manager").InnerText.Equals("true") ? true : false,
                    staffNode.SelectSingleNode("staff_is_seller").InnerText.Equals("true") ? true : false
                );
                return new UserDTO(username, password, staff);
            }
            catch (Exception)
            {
            }

            return null;
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