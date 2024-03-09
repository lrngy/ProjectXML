using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ProjectXML.Util;
using System.Diagnostics;
using System.Xml;

namespace ProjectXML.DAO
{
    public class LoginDAO
    {
        XmlDocument xmlDoc;
        public void ReLoadData()
        {
            xmlDoc = Config.getDoc("users");
        }
        public bool isExistAccount(string username, string password)
        {
            ReLoadData();
            XmlNode accountNode = null;
            try
            {
                string xPath = $"/users/user[username='{username}' and password='{password}']";

                accountNode = xmlDoc.SelectSingleNode(xPath);
            } catch (Exception ex)
            {

            }
            return accountNode != null;
        }

    }
}
