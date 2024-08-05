namespace QPharma.DTO;

public class CustomerDTO
{
    private int id;
    private string name;
    private string phone;
    private string address;
    private string note;
    private bool status;
    private string created;
    private string updated;
    private string deleted;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Phone
    {
        get => phone;
        set => phone = value;
    }

    public string Address
    {
        get => address;
        set => address = value;
    }

    public string Note
    {
        get => note;
        set => note = value;
    }

    public bool Status
    {
        get => status;
        set => status = value;
    }

    public string Created
    {
        get => created;
        set => created = value;
    }

    public string Updated
    {
        get => updated;
        set => updated = value;
    }

    public string Deleted
    {
        get => deleted;
        set => deleted = value;
    }
}