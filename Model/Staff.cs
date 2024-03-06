using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Model
{
    public class Staff
    {
        string id { get; set; }
        string info { get; set; }
        bool isManager { get; set; }
        bool isSeller { get; set; }

        public Staff()
        {
        }

        public Staff(string id, string info, bool isManager, bool isSeller)
        {
            this.id = id;
            this.info = info;
            this.isManager = isManager;
            this.isSeller = isSeller;
        }
    }
}
