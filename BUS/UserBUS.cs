using QPharma.DAL;
using QPharma.DTO;
using QPharma.Util;

namespace QPharma.BUS
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
            return UserDAL.GetUser(username);
        }

        public int Update(UserDTO user, StaffDTO staff)
        {
            if (UserDAL.GetUser(user.username) == null) return Predefined.ID_NOT_EXIST;
            return UserDAL.Update(user, staff);
        }

        public int UpdatePassword(UserDTO user)
        {
            if (UserDAL.GetUser(user.username) == null) return Predefined.ID_NOT_EXIST;
            return UserDAL.UpdatePassword(user);
        }
    }
}