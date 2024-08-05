namespace QPharma.DTO;

public class MedicineDTO
{
    public MedicineDTO()
    {
    }

    public MedicineDTO(string id, string name, int quantity, double priceOut, CategoryDTO category, bool type,
        string unit, string mfgDate, string expDate, SupplierDTO supplier, double priceIn,
        MedicineLocationDTO location, string description, string created, string updated, string deleted, string imagePath)
    {
        this.id = id;
        this.name = name;
        this.quantity = quantity;
        price_out = priceOut;
        this.category = category;
        this.type = type;
        this.unit = unit;
        this.mfgDate = mfgDate;
        this.expDate = expDate;
        this.supplier = supplier;
        price_in = priceIn;
        this.location = location;
        this.description = description;
        this.created = created;
        this.updated = updated;
        this.deleted = deleted;
        this.imagePath = imagePath;
    }


    public string id { get; set; }
    public string name { get; set; }
    public int quantity { get; set; }
    public double price_out { get ; set; }
    public CategoryDTO category { get; set; }
    public bool type { get; set; }
    public string unit { get; set; }
    public string mfgDate { get; set; }
    public string expDate { get; set; }

    public SupplierDTO supplier { get; set; }

    public double price_in { get; set; }
    public MedicineLocationDTO location { get; set; }
    public string description { get; set; }
    public string created { get; set; }

    public string updated { get; set; }
    public string deleted { get; set; }
    public string imagePath { get; set; }

}