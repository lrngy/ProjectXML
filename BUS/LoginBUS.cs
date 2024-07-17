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
            return loginDAL.isExistAccount(username, password) ? userDAL.getUser(username) : null;
        }
    }
}