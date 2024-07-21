namespace ProjectXML.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string username { get; set; }
        public string password { get; set; }

        public void Update(UserDTO newUser)
        {
            username = newUser.username;
            password = newUser.password;
        }
    }
}