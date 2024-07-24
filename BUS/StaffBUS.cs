using ProjectXML.DAL;
using ProjectXML.DTO;

namespace ProjectXML.BUS
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