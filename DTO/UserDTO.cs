namespace ProjectXML.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(string username, string password, StaffDTO staff)
        {
            this.username = username;
            this.password = password;
            this.staff = staff;
        }

        public string username { get; set; }
        public string password { get; set; }
        public StaffDTO staff { get; set; }

        public void Update(UserDTO newUser)
        {
            username = newUser.username;
            password = newUser.password;
            staff = newUser.staff;
        }
    }
}