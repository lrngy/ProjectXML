namespace QPharma.DTO;

public class CustomerDTO
{
    private string id;
    private string name;
    private string phone;
    private string address;
    private string note;
    private bool status;
    private string created;
    private string updated;
    private string deleted;

    public CustomerDTO()
    {
    }
    public CustomerDTO(string id, string name, string phone, string address, string note, bool status, string created, string updated, string deleted)
    {
        this.id = id;
        this.name = name;
        this.phone = phone;
        this.address = address;
        this.note = note;
        this.status = status;
        this.created = created;
        this.updated = updated;
        this.deleted = deleted;
    }

    public string Id
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