namespace QPharma.DTO;

public class UserDTO
{
    public UserDTO()
    {
    }

    public UserDTO(string username, string hashPassword, string guid = "")
    {
        this.username = username;
        this.hashPassword = hashPassword;
        this.guid = guid;
    }

    public string username { get; set; }
    public string hashPassword { get; set; }
    public string guid { get; set; }


    public void Update(UserDTO newUser)
    {
        username = newUser.username;
        hashPassword = newUser.hashPassword;
    }
}