namespace QPharma.DTO
{
    public class LoginLogDTO
    {
        public string id { get; set; }
        public string username { get; set; }
        public string loginTime { get; set; }
        public string logoutTime { get; set; }

        public LoginLogDTO(string id, string username, string loginTime, string logoutTime)
        {
            this.id = id;
            this.username = username;
            this.loginTime = loginTime;
            this.logoutTime = logoutTime;
        }
    }
}