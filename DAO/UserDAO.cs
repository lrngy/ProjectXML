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
        XmlDocument userDoc = Config.getDoc("users");
        XmlDocument staffDoc = Config.getDoc("staffs");
        public User getUser(string username)
        {
            string xPathUsers = $"//user[username='{username}']";
            XmlNode accountNode = userDoc.SelectSingleNode(xPathUsers);
            string password = accountNode.SelectSingleNode("password").InnerText;

            string staffId = accountNode.SelectSingleNode("staff_id").InnerText;
            string xPathStaffs = $"//staff[staff_id='{staffId}']";
            XmlNode staffNode = staffDoc.SelectSingleNode(xPathStaffs);

            Staff staff = new Staff(
                staffId,
                staffNode.SelectSingleNode("staff_info").InnerText,
                staffNode.SelectSingleNode("staff_is_manager").InnerText.Equals("true") ? true : false,
                staffNode.SelectSingleNode("staff_is_seller").InnerText.Equals("true") ? true : false
                );

            return new User(username, password, staff);
        }
    }
}
