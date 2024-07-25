using QPharma.DAL;
using QPharma.DTO;

namespace QPharma.BUS
{
    internal class StaffBUS
    {
        private readonly StaffDAL staffDAL = new StaffDAL();

        public StaffDTO GetByUsername(string username)
        {
            return staffDAL.GetByUsername(username);
        }
    }
}