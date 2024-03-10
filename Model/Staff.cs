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
        public string name { get; set; }
        public bool gender { get; set; }
        public string birthday { get; set; }

        public bool isManager { get; set; }
        public bool isSeller { get; set; }

        public Staff()
        {
        }

        public Staff(string id, string name, bool gender, string birthday, bool isManager, bool isSeller)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.birthday = birthday;
            this.isManager = isManager;
            this.isSeller = isSeller;
        }
    }
}
