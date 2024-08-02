namespace QPharma.DTO
{
    // Lớp đối tượng
    public class StaffDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool gender { get; set; }
        public string birthday { get; set; }
        public bool isManager { get; set; }
        public bool isSeller { get; set; }
        public string username { get; set; }

        public string staff_created { get; set; }
        public string staff_updated { get; set; }
        public string staff_deleted { get; set; }

        public StaffDTO(string id, string name, bool gender, string birthday, bool isManager, bool isSeller,
            string username)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.birthday = birthday;
            this.isManager = isManager;
            this.isSeller = isSeller;
            this.username = username;
        }

        public StaffDTO(string id, string name, bool gender, string birthday, bool isManager, bool isSeller,
            string username, string staff_created, string staff_updated, string staff_deleted)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.birthday = birthday;
            this.isManager = isManager;
            this.isSeller = isSeller;
            this.username = username;
            this.staff_created = staff_created;
            this.staff_updated = staff_updated;
            this.staff_deleted = staff_deleted;
        }

        public void Update(StaffDTO newStaff)
        {
            id = newStaff.id;
            name = newStaff.name;
            gender = newStaff.gender;
            birthday = newStaff.birthday;
            isManager = newStaff.isManager;
            isSeller = newStaff.isSeller;
            username = newStaff.username;
        }
    }
}