namespace QPharma.DTO;

public class BillDTO
{
    private string id;
    private decimal total;
    private decimal customerPaid;
    private bool status;
    private string note;
    private CustomerDTO customer;
    private StaffDTO staff;
    private string created;
    private string deleted;
    private List<(MedicineDTO medicine, decimal quantity, decimal price)> billDetails;
    private string doctorPrescribed;

    public BillDTO()
    {
    }

    public BillDTO(string id, decimal total, decimal customerPaid, bool status, string note, CustomerDTO customer, StaffDTO staff, string created, string deleted, List<(MedicineDTO medicine, decimal quantity, decimal price)> billDetails, string doctorPrescribed)
    {
        this.id = id;
        this.total = total;
        this.customerPaid = customerPaid;
        this.status = status;
        this.note = note;
        this.customer = customer;
        this.staff = staff;
        this.created = created;
        this.deleted = deleted;
        this.billDetails = billDetails;
        this.doctorPrescribed = doctorPrescribed;
    }

    public string Id
    {
        get => id;
        set => id = value;
    }

    public decimal Total
    {
        get => total;
        set => total = value;
    }

    public decimal CustomerPaid
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

    public List<(MedicineDTO medicine, decimal quantity, decimal price)> BillDetails
    {
        get => billDetails;
        set => billDetails = value;
    }

    public string DoctorPrescribed
    {
        get => doctorPrescribed;
        set => doctorPrescribed = value;
    }
}