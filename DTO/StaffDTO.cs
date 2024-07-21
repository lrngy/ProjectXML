namespace ProjectXML.DTO
{
    public class StaffDTO
    {
        public StaffDTO()
        {
        }

        public StaffDTO(string id, string name, bool gender, string birthday, bool isManager, bool isSeller, string username)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.birthday = birthday;
            this.isManager = isManager;
            this.isSeller = isSeller;
            this.username = username;
        }

        public string id { get; set; }
        public string name { get; set; }
        public bool gender { get; set; }
        public string birthday { get; set; }

        public bool isManager { get; set; }
        public bool isSeller { get; set; }

        public string username { get; set; }

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