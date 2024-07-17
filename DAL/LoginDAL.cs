using System;
using System.Xml;
using ProjectXML.Util;

namespace ProjectXML.DAL
{
    public class LoginDAL
    {
        private XmlDocument xmlDoc;

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
                var xPath = $"/users/user[username='{username}' and password='{password}']";

                accountNode = xmlDoc.SelectSingleNode(xPath);
            }
            catch (Exception)
            {
            }

            return accountNode != null;
        }
    }
}