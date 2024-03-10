using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Model
{
    public class Medicine
    {
        public string id {  get; set; }
        public string name { get; set; }
        public string expireDate { get; set; }
        public string unit { get; set; }

        public double price { get; set; }
        public int quantity { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public Supplier supplier { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string deleted { get; set; }
        public Category category { get; set; }
        
        public Medicine()
        {
        }

        public Medicine(string id, string name, string expireDate, string unit, double price, int quantity, string image, string description, Supplier supplier, string created, string updated, string deleted, Category category)
        {
            this.id = id;
            this.name = name;
            this.expireDate = expireDate;
            this.unit = unit;
            this.price = price;
            this.quantity = quantity;
            this.image = image;
            this.description = description;
            this.supplier = supplier;
            this.created = created;
            this.updated = updated;
            this.deleted = deleted;
            this.category = category;
        }
    }
}
