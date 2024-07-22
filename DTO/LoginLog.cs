using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.DTO
{
    internal class LoginLog
    {
        public string id { get; set; }
        public string username { get; set; }
        public string loginTime { get; set; }
        public string logoutTime { get; set; }

        public LoginLog(string id, string username, string loginTime, string logoutTime)
        {
            this.id = id;
            this.username = username;
            this.loginTime = loginTime;
            this.logoutTime = logoutTime;
        }
    }
}
