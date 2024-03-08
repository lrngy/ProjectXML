using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Model
{
    public class Staff
    {
        public string id { get; set; }
        public string info { get; set; }
        public bool isManager { get; set; }
        public bool isSeller { get; set; }

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
