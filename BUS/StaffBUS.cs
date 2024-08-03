namespace QPharma.BUS;

    // Lớp điều khiển
internal class StaffBUS
{
    private UserDAL userDAL;

        public StaffBUS()
        {
            this.userDAL = new UserDAL();
        }
        public static bool CheckExistUsername(string username)
        {
            return StaffDAL.CheckExistUsername(username);
        }
    public StaffDTO GetByUsername(string username)
    {
        return StaffDAL.GetByUsername(username);
        }
        public static List<StaffDTO> GetAll()
        {
            return StaffDAL.GetAll();
        }
        public void addSave(StaffDTO staff)
        {
            if (staff is null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thất bại");
                return;
            }

           if( StaffDAL.Insert(staff)== Predefined.SUCCESS)
                MessageBox.Show("Thêm nhân viên thành công!");
        }
        public void updateStaff(StaffDTO staff)
        {
            if (staff is null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thất bại");
                return;
            }

            if (StaffDAL.Update(staff) == Predefined.SUCCESS)
                MessageBox.Show("Sửa nhân viên thành công!");
            else
                MessageBox.Show("Sửa nhân viên thất bại!");
        }
        public void delete(string id)
        {
            if (id is null || id == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thất bại");
                return;
            }
            if (StaffDAL.Delete(id) == Predefined.SUCCESS)
                MessageBox.Show("Đã thêm nhân viên vào nhân viên đã xóa thành công!");
            else
                MessageBox.Show("Thêm nhân viên vào nhân viên đã xóa thất bại!");
        }

        internal void resetUserPassword(string oldUsername)
        {
            if (CustomMessageBox.ShowQuestion("Chắc chắn muốn đặt lại mật khẩu nhân viên?") == DialogResult.Yes)
            {
                if (UserDAL.UpdatePassword(new UserDTO(oldUsername, "1")) == Predefined.SUCCESS)
                    MessageBox.Show("Đặt lại mật khẩu nhân viên thành công!");
                else
                    MessageBox.Show("Đặt lại mật khẩu nhân viên thất bại!");
            }
    }
}