using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Model
{
    public class User
    {
        string username { get; set; }
        string password { get; set; }
        Staff staff { get; set; }
        public User() { }
        public User(string username, string password, Staff staff)
        {
            this.username = username;
            this.password = password;
            this.staff = staff;
        }
    }
}
