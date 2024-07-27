using ProjectXML.DAL;
using ProjectXML.DTO;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjectXML.BUS
{
    // Lớp điều khiển
    internal class StaffBUS
    {
        private StaffDAL staffDAL;
        private UserDAL userDAL;

        private UserBUS userBUS;

        public StaffBUS()
        {
            this.staffDAL = new StaffDAL();
            this.userDAL = new UserDAL();

            this.userBUS = new UserBUS();
        }
        public bool CheckExistUsername(string username)
        {
            return userDAL.CheckExistUserName(username);
        }
        public bool CheckExistId(string id)
        {
            return staffDAL.CheckExist(id);
        }
        public StaffDTO GetByUsername(string username)
        {
            return staffDAL.GetByUsername(username);
        }
        public List<StaffDTO> GetAll()
        {
            return staffDAL.GetAll();
        }
        public void addSave(StaffDTO staff)
        {
            if (userDAL.AddUser(new UserDTO(staff.username, "1")) == Predefined.SUCCESS 
                && staffDAL.Insert(staff) == Predefined.SUCCESS) 
                MessageBox.Show("Thêm nhân viên thành công!");
        }
        public void updateStaff(StaffDTO staff, string oldUsername)
        {
            if (userDAL.UpdateUser(staff.username, oldUsername) == Predefined.SUCCESS
               && staffDAL.Update(staff) == Predefined.SUCCESS)
                MessageBox.Show("Sửa nhân viên thành công!");
        }
        public void delete(StaffDTO staff, string oldUsername)
        {
            if (staffDAL.Delete(staff.id) == Predefined.SUCCESS &&
            userDAL.DeleteUser(oldUsername) == Predefined.SUCCESS) 
                MessageBox.Show("Xóa nhân viên thành công!");
        }
    }
}
