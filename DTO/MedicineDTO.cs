using System;

namespace ProjectXML.DTO
{
    public class MedicineDTO
    {
        public MedicineDTO()
        {
        }

        public MedicineDTO(string id, string name, string expireDate, string unit, double price_in, double price_out, int quantity, bool type, string image, string description, string created, string updated, string deleted, SupplierDTO supplier, CategoryDTO category, MedicineLocationDTO location)
        {
            this.id = id;
            this.name = name;
            this.expireDate = expireDate;
            this.unit = unit;
            this.price_in = price_in;
            this.price_out = price_out;
            this.quantity = quantity;
            this.type = type;
            this.image = image;
            this.description = description;
            this.created = created;
            this.updated = updated;
            this.deleted = deleted;
            this.supplier = supplier;
            this.category = category;
            this.location = location;
        }

        public MedicineDTO(string id, string name, string expireDate, string unit, double price_out, int quantity, string image, string description, string created, string updated, string deleted, SupplierDTO supplier, CategoryDTO category)
        {
            this.id = id;
            this.name = name;
            this.expireDate = expireDate;
            this.unit = unit;
            this.price_out = price_out;
            this.quantity = quantity;
            this.image = image;
            this.description = description;
            this.created = created;
            this.updated = updated;
            this.deleted = deleted;
            this.supplier = supplier;
            this.category = category;
        }

        public string id { get; set; }
        public string name { get; set; }
        public string expireDate { get; set; }
        public string unit { get; set; }

        public double price_in { get; set; }
        public double price_out { get; set; }
        public int quantity { get; set; }
        public bool type;
        public string image { get; set; }

        public string description { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string deleted { get; set; }
        public SupplierDTO supplier { get; set; }
        public CategoryDTO category { get; set; }
        public MedicineLocationDTO location { get; set; }
    }
}