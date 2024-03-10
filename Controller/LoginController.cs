using ProjectXML.DAO;
using ProjectXML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Controller
{
    public class LoginController
    {
        LoginDAO loginDAO = new LoginDAO();
        UserDAO userDAO = new UserDAO();
        public User CheckExist(string username, string password)
        {
            return loginDAO.isExistAccount(username, password) ? userDAO.getUser(username) : null;
        }
    }
}
