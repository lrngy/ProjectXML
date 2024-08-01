namespace QPharma.DTO
{
    public class MedicineLocationDTO
    {
        public MedicineLocationDTO()
        {
        }

        public MedicineLocationDTO(string name, string note, bool status, string created, string updated,
            string deleted, string id = null)
        {
            this.id = id;
            this.name = name;
            this.note = note;
            this.status = status;
            this.created = created;
            this.updated = updated;
            this.deleted = deleted;
        }

        public string id { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public bool status { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string deleted { get; set; }
    }
}