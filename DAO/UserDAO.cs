using ProjectXML.Model;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectXML.DAO
{
    public class UserDAO
    {
        XmlDocument userDoc;
        XmlDocument staffDoc;
        public void ReLoadData()
        {
            userDoc = Config.getDoc("users");
            staffDoc = Config.getDoc("staffs");
        }
        public User getUser(string username)
        {
            ReLoadData();
            try
            {
                string xPathUsers = $"//user[username='{username}']";
                XmlNode accountNode = userDoc.SelectSingleNode(xPathUsers);
                string password = accountNode.SelectSingleNode("password").InnerText;

                string staffId = accountNode.SelectSingleNode("staff_id").InnerText;
                string xPathStaffs = $"//staff[staff_id='{staffId}']";
                XmlNode staffNode = staffDoc.SelectSingleNode(xPathStaffs);

                Staff staff = new Staff(
                    staffId,
                    staffNode.SelectSingleNode("staff_name").InnerText,
                    staffNode.SelectSingleNode("staff_sex").InnerText.Equals("Nam") ? true : false,
                    staffNode.SelectSingleNode("staff_year_of_birth").InnerText,
                    staffNode.SelectSingleNode("staff_is_manager").InnerText.Equals("true") ? true : false,
                    staffNode.SelectSingleNode("staff_is_seller").InnerText.Equals("true") ? true : false
                    );
                return new User(username, password, staff);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        internal int Update(User user)
        {
            ReLoadData();
            try
            {
                XmlNode staffNode = staffDoc.SelectSingleNode($"//staff[staff_id='{user.staff.id}']");
                staffNode.SelectSingleNode("staff_name").InnerText = user.staff.name;
                staffNode.SelectSingleNode("staff_year_of_birth").InnerText = user.staff.birthday;
                staffNode.SelectSingleNode("staff_sex").InnerText = user.staff.gender ? "Nam" : "Nữ";
                staffDoc.Save(Config.getXMLPath("staffs"));


                string xPathUsers = $"//user[username='{user.username}']";
                XmlNode accountNode = userDoc.SelectSingleNode(xPathUsers);
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
