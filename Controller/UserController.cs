using ProjectXML.DAO;
using ProjectXML.Model;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Controller
{
    public class UserController
    {
        UserDAO UserDAO;
        public UserController()
        {
            UserDAO = new UserDAO();
        }


        public int Update(User user)
        {
            if (UserDAO.getUser(user.username) == null)
            {
                return Predefined.ID_NOT_EXIST;
            }
            return UserDAO.Update(user);
        }
    }
}
