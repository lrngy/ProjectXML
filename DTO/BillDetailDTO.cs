namespace QPharma.DTO;

public class BillDetailDTO
{
    private MedicineDTO medicine;
    private int quantity;
    private int price;

    public BillDetailDTO()
    {
    }
    public BillDetailDTO(MedicineDTO medicine, int quantity, int price)
    {
        this.medicine = medicine;
        this.quantity = quantity;
        this.price = price;
    }

    public MedicineDTO medicine1
    {
        get => medicine;
        set => medicine = value;
    }

    public int quantity1
    {
        get => quantity;
        set => quantity = value;
    }

    public int price1
    {
        get => price;
        set => price = value;
    }
}