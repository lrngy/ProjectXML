using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ProjectXML.BUS;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.GUI
{
    // git add .
    // git commit -m "Quyết - update Quản lý nhân viên - !"
    // git push origin Quyet

    //git pull origin Quyet
    //lệnh giải quyết xung đột

    //git reset --hard HEAD~1
    // xóa commit trước đó, đồng thời xóa các thay đổi trước đó

    public partial class QuanLyNhanVienGUI : Form
    {
        private String id;
        private String name;
        private Boolean gender;
        private String birthday;
        private String account;
        private Boolean isManager;
        private Boolean isSeller;
        private String username;   
        private StaffBUS staffBus;
        private String oldUsername;

        public QuanLyNhanVienGUI()
        {
            InitializeComponent();
            staffBus = new StaffBUS();
        }
        private void QuanLyNhanVienForm_Load(object sender, EventArgs e)
        {
            Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2);

            save_add.Enabled = false;
            sua.Enabled = false;
            xoa.Enabled = false;
            bResetPass.Enabled = false;
            dateTimePicker1.Text = "01/01/1999";

            cboGender.Items.Add("--Chọn giới tính--");
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.SelectedIndex = 0;  // Chọn mặc định là Nam

            t_id.ReadOnly = true;
            HienThi(sender, e);
        }
        private void valUpdateValue()
        {
            this.id = t_id.Text.Trim();
            this.name = t_staff_name.Text.Trim();
            this.gender = (cboGender.Text.Trim() == "Nam") ? true : false;
            this.birthday = dateTimePicker1.Text.Trim();
            this.account = tTaiKhoan.Text.Trim();
            this.isManager = c_staff_is_manager.Checked;
            this.isSeller = c_staff_is_seller.Checked;
            this.username = tTaiKhoan.Text.Trim();
        }
        private StaffDTO currentStaff()
        {
            this.valUpdateValue();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) ||
                cboGender.Text.Trim() == "--Chọn giới tính--" ||
                string.IsNullOrEmpty(birthday) || string.IsNullOrEmpty(account) ||
                !(isManager || isSeller))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thất bại");
                return null;
            }

            return new StaffDTO(id, name, gender, birthday, isManager, isSeller, username);
        }
        private void HienThi(object sender, EventArgs e)
        {
            try                                   
            {
                Back_Click(sender, e);
                var staffs = staffBus.GetAll();
                var sd = 0;
                dataGridView1.Rows.Clear();

                foreach (StaffDTO staff in staffs)
                    if (staffBus.CheckExistUsername(staff.username.ToString()))
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[sd].Cells[0].Value = staff.id;
                        dataGridView1.Rows[sd].Cells[1].Value = staff.name;
                        dataGridView1.Rows[sd].Cells[2].Value = staff.username;
                        dataGridView1.Rows[sd].Cells[3].Value = staff.gender;
                        dataGridView1.Rows[sd].Cells[4].Value = staff.birthday;
                        dataGridView1.Rows[sd].Cells[5].Value = staff.isManager;
                        dataGridView1.Rows[sd].Cells[6].Value = staff.isSeller;
                        sd++;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đọc dữ liệu Staff: " + ex.Message);
            }
        }
        private string cell(int rowSelected, int cellNumber)
        {
            return dataGridView1.Rows[rowSelected].Cells[cellNumber].Value.ToString().Trim();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            them.Enabled = false;
            sua.Enabled = true;
            xoa.Enabled = true;
            bResetPass.Enabled = true;

            var row = dataGridView1.CurrentCell.RowIndex;
            oldUsername = this.cell(row, 2);

            t_id.Text = this.cell(row, 0);
            t_staff_name.Text = this.cell(row, 1);
            tTaiKhoan.Text = this.cell(row, 2);
            cboGender.Text = this.cell(row, 3);
            dateTimePicker1.Text = this.cell(row, 4);
            c_staff_is_manager.Checked = (this.cell(row, 5) == "True")
                ? true : false;
            c_staff_is_seller.Checked = (this.cell(row, 6) == "True")
                ? true : false;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            t_id.ReadOnly = true;

            t_id.Text = "";
            t_staff_name.Text = "";
            cboGender.Text = "--Chọn giới tính--";
            dateTimePicker1.Text = "";
            c_staff_is_manager.Checked = false;
            c_staff_is_seller.Checked = false;

            bResetPass.Enabled = false;
            tTaiKhoan.Text = "";
            them.Enabled = true;
            sua.Enabled = false;
            xoa.Enabled = false;
            save_add.Enabled = false;
            bResetPass.Enabled = false;
        }
        private void them_Click(object sender, EventArgs e)
        {
            Back_Click(sender, e);
            them.Enabled = false;
            sua.Enabled = false;
            xoa.Enabled = false;
            save_add.Enabled = true;

            t_id.ReadOnly = false;
        }
        private void save_add_Click(object sender, EventArgs e)
        {
            staffBus.addSave(this.currentStaff());
            HienThi(sender, e);
        }
        private void sua_Click(object sender, EventArgs e)
        {
            staffBus.updateStaff(this.currentStaff(), oldUsername);
            HienThi(sender, e);
        }
        private void xoa_Click(object sender, EventArgs e)
        {
            staffBus.delete(this.currentStaff(), oldUsername);
            HienThi(sender, e);
        }
        private void t_timKiem_TextChanged(object sender, EventArgs e)
        {
            var searchText = t_timKiem.Text.Trim().ToLower();

            if (searchText == "")
                HienThi(sender, e);
            else
                try
                {
                    //doc.Load(file_name);
                    //root = doc.DocumentElement;

                    //docUser.Load(fileNameUser);
                    //rootUser = docUser.DocumentElement;


                    //var ds = root.SelectNodes(
                    //    $"staff[contains(translate(staff_id, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    //    $"contains(translate(staff_name, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    //    $"contains(translate(staff_sex, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    //    $"contains(translate(staff_year_of_birth, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    //    $"contains(translate(staff_is_manager, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    //    $"contains(translate(staff_is_seller, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}')]");


                    //var users = rootUser.SelectNodes(
                    //    $"user[contains(translate(username, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    //    $"contains(translate(staff_id, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}')]");

                    //var usersList = rootUser.SelectNodes("user");
                    //var staffsList = root.SelectNodes("staff");

                    //dataGridView1.Rows.Clear();
                    //if (ds.Count > 0) DuyetTimKiemPhanTu(ds, usersList);
                    //if (users.Count > 0) DuyetTimKiemPhanTu(staffsList, users);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message);
                }
        }
        private void DuyetTimKiemPhanTu(XmlNodeList StaffList, XmlNodeList userList)
        {
            var sd = 0;
            foreach (XmlNode node in StaffList)
                foreach (XmlNode user in userList)
                    if (node.SelectSingleNode("staff_id").InnerText == user.SelectSingleNode("staff_id").InnerText)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[sd].Cells[0].Value = node.SelectSingleNode("staff_id").InnerText;
                        dataGridView1.Rows[sd].Cells[1].Value = node.SelectSingleNode("staff_name").InnerText;
                        dataGridView1.Rows[sd].Cells[2].Value = user.SelectSingleNode("username").InnerText;
                        dataGridView1.Rows[sd].Cells[3].Value = node.SelectSingleNode("staff_sex").InnerText;
                        dataGridView1.Rows[sd].Cells[4].Value = node.SelectSingleNode("staff_year_of_birth").InnerText;
                        dataGridView1.Rows[sd].Cells[5].Value = node.SelectSingleNode("staff_is_manager").InnerText;
                        dataGridView1.Rows[sd].Cells[6].Value = node.SelectSingleNode("staff_is_seller").InnerText;
                        sd++;
                    }
        }
        private void bResetPass_Click(object sender, EventArgs e)
        {
            if (t_id.Text.Trim() == "" || tTaiKhoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đủ id và thông tin tài khoản!");
                return;
            }

            //docUser.Load(fileNameUser);
            //rootUser = docUser.DocumentElement;

            //var userOld = rootUser.SelectSingleNode("user[staff_id = '" + t_id.Text.Trim() + "']");
            //if (userOld != null)
            //{
            //    XmlNode userNew = docUser.CreateElement("user");

            //    var staff_idUser = docUser.CreateElement("staff_id");
            //    staff_idUser.InnerText = t_id.Text.Trim();
            //    userNew.AppendChild(staff_idUser);

            //    var username = docUser.CreateElement("username");
            //    username.InnerText = tTaiKhoan.Text.Trim();
            //    userNew.AppendChild(username);

            //    var password = docUser.CreateElement("password");
            //    password.InnerText = "1";
            //    userNew.AppendChild(password);

            //    rootUser.ReplaceChild(userNew, userOld);
            //    docUser.Save(fileNameUser);
            //    MessageBox.Show("Reset password thành công!");
            //}
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                          if(e.GetType() == typeof(Button)) { }
        }
    }
}