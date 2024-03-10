using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Model
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public Staff staff { get; set; }
        public User() { }
        public User(string username, string password, Staff staff)
        {
            this.username = username;
            this.password = password;
            this.staff = staff;
        }
        public void Update(User newUser)
        {
            this.username = newUser.username;
            this.password = newUser.password;
            this.staff = newUser.staff;
        }
    }
}
