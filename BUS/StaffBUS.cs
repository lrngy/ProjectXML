using ProjectXML.DAL;
using ProjectXML.DTO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectXML.BUS
{
    internal class StaffBUS
    {
        private StaffDAL staffDAL = new StaffDAL();

        public StaffDTO GetByUsername(string username)
        {
            return staffDAL.GetByUsername(username);
        }
    }
}
