using ProjectXML.DAL;
using ProjectXML.DTO;

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

        public bool CheckLoggedIn(UserDTO user)
        {
            return loginDAL.CheckLoggedIn(user);
        }
    }
}