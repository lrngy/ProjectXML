using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Model
{
    public class Supplier
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string note { get; set; }
        public bool status { get; set; }

        public Supplier()
        {
        }

        public Supplier(string id, string name, string phone, string email, string note, bool status)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.note = note;
            this.status = status;
        }
    }
}
