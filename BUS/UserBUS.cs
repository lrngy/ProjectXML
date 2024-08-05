namespace QPharma.BUS;

public class UserBUS
{
    private readonly UserDAL UserDAL;

    public UserBUS()
    {
        UserDAL = new UserDAL();
    }

    public UserDTO getUser(string username)
    {
        return UserDAL.GetByUsername(username);
    }

    public int Update(UserDTO user, StaffDTO staff)
    {
        if (UserDAL.GetByUsername(user.username) == null) return Predefined.ID_NOT_EXIST;
        return UserDAL.Update(user, staff);
    }

    public int UpdatePassword(UserDTO user)
    {
        if (UserDAL.GetByUsername(user.username) == null) return Predefined.ID_NOT_EXIST;
        return UserDAL.UpdatePassword(user);
    }
}