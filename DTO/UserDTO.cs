namespace QPharma.DTO;

public class UserDTO
{
    public UserDTO()
    {
    }

    public UserDTO(string username, string password, string guid = "")
    {
        this.username = username;
        this.password = password;
        this.guid = guid;
    }

    public string username { get; set; }
    public string password { get; set; }
    public string guid { get; set; }


    public void Update(UserDTO newUser)
    {
        username = newUser.username;
        password = newUser.password;
    }
}