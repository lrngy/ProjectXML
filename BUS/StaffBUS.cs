namespace QPharma.BUS;

internal class StaffBUS
{
    private readonly StaffDAL staffDAL = new();

    public StaffDTO GetByUsername(string username)
    {
        return staffDAL.GetByUsername(username);
    }
}