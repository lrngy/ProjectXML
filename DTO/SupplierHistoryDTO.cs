using System.Runtime.CompilerServices;

namespace QPharma.DTO;

public class SupplierHistoryDTO
{
    private SupplierDTO supplier;
    private MedicineDTO medicine;
    private string created;
    private int price;
    private int quantity;
    private string deleted;

    public SupplierDTO Supplier
    {
        get => supplier;
        set => supplier = value;
    }

    public MedicineDTO Medicine
    {
        get => medicine;
        set => medicine = value;
    }

    public string Created
    {
        get => created;
        set => created = value;
    }

    public int Price
    {
        get => price;
        set => price = value;
    }

    public int Quantity
    {
        get => quantity;
        set => quantity = value;
    }

    public string Deleted
    {
        get => deleted;
        set => deleted = value;
    }
}