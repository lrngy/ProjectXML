namespace QPharma.DTO;

public class BillDTO
{
    private int id;
    private int total;
    private int customerPaid;
    private bool status;
    private string note;
    private CustomerDTO customer;
    private StaffDTO staff;
    private string created;
    private string deleted;
    private List<BillDetailDTO> billDetails;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public int Total
    {
        get => total;
        set => total = value;
    }

    public int CustomerPaid
    {
        get => customerPaid;
        set => customerPaid = value;
    }

    public bool Status
    {
        get => status;
        set => status = value;
    }

    public string Note
    {
        get => note;
        set => note = value;
    }

    public CustomerDTO Customer
    {
        get => customer;
        set => customer = value;
    }

    public StaffDTO Staff
    {
        get => staff;
        set => staff = value;
    }

    public string Created
    {
        get => created;
        set => created = value;
    }

    public string Deleted
    {
        get => deleted;
        set => deleted = value;
    }

    public List<BillDetailDTO> BillDetails
    {
        get => billDetails;
        set => billDetails = value;
    }
}