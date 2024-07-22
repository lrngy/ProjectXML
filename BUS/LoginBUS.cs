using ProjectXML.DAL;
using ProjectXML.DTO;
using ProjectXML.Util;
using System;
using System.Globalization;

namespace ProjectXML.BUS
{
    public class LoginBUS
    {
        private readonly LoginDAL loginDAL = new LoginDAL();
        private readonly UserDAL userDAL = new UserDAL();

        public UserDTO CheckExist(string username, string password)
        {
            return loginDAL.isExistAccount(username, password) ? userDAL.GetUser(username) : null;
        }

        public bool Login(UserDTO user)
        {
            return loginDAL.Login(user);
        }

        public bool Logout(UserDTO user)
        {
            return loginDAL.Logout(user);
        }

        public LoginLog CheckLoggedIn()
        {
            LoginLog loginLog = loginDAL.GetLoginLog();
            string currentTime = CustomDateTime.GetNow();
            string loginTime = loginLog.loginTime;

            TimeSpan timeSpan = CustomDateTime.CompareDateTime(currentTime, loginTime);
            if (!loginLog.logoutTime.Equals("") || timeSpan.TotalHours > 12)
            {
                return null;
            }
            return loginDAL.GetLoginLog();
        }
    }
}