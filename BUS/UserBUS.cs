using ProjectXML.DAL;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.BUS
{
    public class UserBUS
    {
        private readonly UserDAL UserDAL;

        public UserBUS()
        {
            UserDAL = new UserDAL();
        }

        public UserDTO getUser(string username)
        {
            return UserDAL.getUser(username);
        }

        public int Update(UserDTO user)
        {
            if (UserDAL.getUser(user.username) == null) return Predefined.ID_NOT_EXIST;
            return UserDAL.Update(user);
        }
    }
}