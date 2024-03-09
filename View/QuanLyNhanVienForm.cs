using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjectXML.View
{

    // git add .
//<<<<<<< HEAD
    // git commit -m "Quyết - update Quản lý nhân viên - đồng bộ tài khoản người dùng!"
    // git push origin Quyet

    //git pull origin Quyet
    //lệnh giải quyết xung đột

    //git reset --hard HEAD~1
    // xóa commit trước đó, đồng thời xóa các thay đổi trước đó

//=======
//    // git commit -m "Quyet     "
//    // git push origin Quyet
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
    public partial class QuanLyNhanVienForm : Form
    {
        public QuanLyNhanVienForm()
        {
            InitializeComponent();
        }

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QuanLyNhanVienForm());
        }

        private void QuanLyNhanVienForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                               (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

////<<<<<<< HEAD
            save_add.Enabled = false;
            sua.Enabled = false;
            xoa.Enabled = false;
            bResetPass.Enabled = false;

            t_id.ReadOnly = true;
            HienThi();
        }

        String file_name = "C:\\Users\\quyet\\OneDrive\\Máy tính\\ProjectXML\\XML\\staffs.xml";
        XmlDocument doc = new XmlDocument();
        XmlElement root;

        String fileNameUser = "C:\\Users\\quyet\\OneDrive\\Máy tính\\ProjectXML\\XML\\users.xml";
        XmlDocument docUser = new XmlDocument();
        XmlElement rootUser;

//=======
//            save_update.Enabled = false;
//            HienThi();
//        }

//        String file_name = "E:\\Check\\ProjectXML\\XML\\staffs.xml";
//        XmlDocument doc = new XmlDocument();
//        XmlElement root;

//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
        private void HienThi()
        {
            try
            {
                doc.Load(file_name);
                root = doc.DocumentElement;

//<<<<<<< HEAD
                docUser.Load(fileNameUser);
                rootUser = docUser.DocumentElement;

                XmlNodeList ds = root.SelectNodes("staff");
                XmlNodeList users = rootUser.SelectNodes("user");
                int sd = 0;
                dataGridView1.Rows.Clear();



                //MessageBox.Show(ds.Count.ToString());
                //MessageBox.Show(users.Count.ToString());

                foreach (XmlNode node in ds)
                {
                    foreach (XmlNode user in users)
                    {
                        //MessageBox.Show(node.SelectSingleNode("staff_id").InnerText);
                        //MessageBox.Show(user.SelectSingleNode("staff_id").InnerText);

                        //dataGridView1.Rows[sd].Cells[1].Value = node.SelectSingleNode("@staff_id").Value;
                        if (node.SelectSingleNode("staff_id").InnerText == user.SelectSingleNode("staff_id").InnerText)
                        {
                            //MessageBox.Show(user.SelectSingleNode("username").InnerText);
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
//=======
//                XmlNodeList ds = root.SelectNodes("staff");
//                int sd = 0;
//                dataGridView1.Rows.Clear();

//                foreach (XmlNode node in ds)
//                {
//                    dataGridView1.Rows.Add();
//                    //dataGridView1.Rows[sd].Cells[1].Value = node.SelectSingleNode("@staff_id").Value;
//                    dataGridView1.Rows[sd].Cells[0].Value = node.SelectSingleNode("staff_id").InnerText;
//                    dataGridView1.Rows[sd].Cells[1].Value = node.SelectSingleNode("staff_name").InnerText;
//                    dataGridView1.Rows[sd].Cells[2].Value = node.SelectSingleNode("staff_sex").InnerText;
//                    dataGridView1.Rows[sd].Cells[3].Value = node.SelectSingleNode("staff_year_of_birth").InnerText;
//                    dataGridView1.Rows[sd].Cells[4].Value = node.SelectSingleNode("staff_is_manager").InnerText;
//                    dataGridView1.Rows[sd].Cells[5].Value = node.SelectSingleNode("staff_is_seller").InnerText;
//                    sd++;
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đọc tệp XML: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
//<<<<<<< HEAD
            them.Enabled = false; 
            sua.Enabled = true;
            xoa.Enabled = true;
            bResetPass.Enabled = true;

            int t = dataGridView1.CurrentCell.RowIndex;
            t_id.Text = dataGridView1.Rows[t].Cells[0].Value.ToString();
            t_staff_name.Text = dataGridView1.Rows[t].Cells[1].Value.ToString();
            tTaiKhoan.Text = dataGridView1.Rows[t].Cells[2].Value.ToString();
            t_staff_sex.Text = dataGridView1.Rows[t].Cells[3].Value.ToString();
            t_staff_year_of_birth.Text = dataGridView1.Rows[t].Cells[4].Value.ToString();
            if (dataGridView1.Rows[t].Cells[5].Value.ToString().Trim() == "true")
            {
                c_staff_is_manager.Checked = true;
            }
            else
            {
                c_staff_is_manager.Checked = false;
            }

            if (dataGridView1.Rows[t].Cells[6].Value.ToString().Trim() == "true")
            {
                c_staff_is_seller.Checked = true;
            }
            else
            {
                c_staff_is_seller.Checked = false;
            }
//=======
//            int t = dataGridView1.CurrentCell.RowIndex;
//            t_id.Text = dataGridView1.Rows[t].Cells[0].Value.ToString();
//            t_staff_name.Text = dataGridView1.Rows[t].Cells[1].Value.ToString();
//            t_staff_sex.Text = dataGridView1.Rows[t].Cells[2].Value.ToString();
//            t_staff_year_of_birth.Text = dataGridView1.Rows[t].Cells[3].Value.ToString();
//            c_staff_is_manager.Checked = Boolean.Parse(dataGridView1.Rows[t].Cells[4].Value.ToString());
//            c_staff_is_seller.Checked = Boolean.Parse(dataGridView1.Rows[t].Cells[5].Value.ToString());
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
        }

        private void Back_Click(object sender, EventArgs e)
        {
//<<<<<<< HEAD
            t_id.ReadOnly = true;
//=======
//            t_id.ReadOnly = false;
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7

            t_id.Text = "";
            t_staff_name.Text = "";
            t_staff_sex.Text = "";
            t_staff_year_of_birth.Text = "";
            c_staff_is_manager.Checked = false;
            c_staff_is_seller.Checked = false;
//<<<<<<< HEAD
            bResetPass.Enabled = false;
            tTaiKhoan.Text = "";
            them.Enabled = true;
            sua.Enabled = false;
            xoa.Enabled = false;
            save_add.Enabled = false;
            bResetPass.Enabled = false;
//=======
//            them.Enabled = true;
//            sua.Enabled = true;
//            xoa.Enabled = true;
//            save_update.Enabled = false;
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
        }

        private void them_Click(object sender, EventArgs e)
        {
//<<<<<<< HEAD
            Back_Click(sender, e);
            them.Enabled = false;
            sua.Enabled = false;
            xoa.Enabled = false;
            save_add.Enabled = true;
            bResetPass.Enabled = true;

            t_id.ReadOnly = false;
        }

        private void sua_Click(object sender, EventArgs e)
        {

            if (t_id.Text.Trim() == "" && t_staff_name.Text.Trim() == "" && t_staff_sex.Text.Trim() == "" && t_staff_year_of_birth.Text.Trim() == "" && tTaiKhoan.Text.Trim() == "" && c_staff_is_manager.Checked == c_staff_is_seller.Checked)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            doc.Load(file_name);
            docUser.Load(fileNameUser);

            root = doc.DocumentElement;
            rootUser = docUser.DocumentElement;

            XmlNode staff_old = root.SelectSingleNode("staff[staff_id = '" + t_id.Text + "']");
            XmlNode userOld = rootUser.SelectSingleNode("user[staff_id = '" + t_id.Text + "']");
            //MessageBox.Show((staff_old.ToString() == null ? "null" : "not null"));
            if (staff_old != null && userOld != null)
            {
                XmlNode staff_new = doc.CreateElement("staff");
                XmlNode userNew = docUser.CreateElement("user");

                XmlElement staff_id = doc.CreateElement("staff_id");
                staff_id.InnerText = t_id.Text;
                staff_new.AppendChild(staff_id);

                XmlElement staff_name = doc.CreateElement("staff_name");
                staff_name.InnerText = t_staff_name.Text;
                staff_new.AppendChild(staff_name);

                //////////
                XmlElement staff_idUser = docUser.CreateElement("staff_id");
                staff_idUser.InnerText = t_id.Text;
                userNew.AppendChild(staff_idUser);

                XmlElement username = docUser.CreateElement("username");
                username.InnerText = tTaiKhoan.Text;
                userNew.AppendChild(username);

                XmlElement password = docUser.CreateElement("password");
                password.InnerText = userOld.SelectSingleNode("password").InnerText;
                userNew.AppendChild(password);
                //////////

                XmlElement staff_sex = doc.CreateElement("staff_sex");
                staff_sex.InnerText = t_staff_sex.Text;
                staff_new.AppendChild(staff_sex);

                XmlElement staff_year_of_birth = doc.CreateElement("staff_year_of_birth");
                staff_year_of_birth.InnerText = t_staff_year_of_birth.Text;
                staff_new.AppendChild(staff_year_of_birth);

                XmlElement staff_is_manager = doc.CreateElement("staff_is_manager");
                staff_is_manager.InnerText = (c_staff_is_manager.Checked ? "true" : "");
                staff_new.AppendChild(staff_is_manager);

                XmlElement staff_is_seller = doc.CreateElement("staff_is_seller");
                staff_is_seller.InnerText = (c_staff_is_seller.Checked ? "true" : "");
                staff_new.AppendChild(staff_is_seller);

                root.ReplaceChild(staff_new, staff_old);
                rootUser.ReplaceChild(userNew, userOld);
                doc.Save(file_name);
                docUser.Save(fileNameUser);
                HienThi();
                MessageBox.Show("Sửa thành công!");
            }
            Back_Click(sender, e);
        }

        private void save_add_Click(object sender, EventArgs e)
        {
            if (t_id.Text.Trim() == "" && t_staff_name.Text.Trim() == "" && t_staff_sex.Text.Trim() == "" && t_staff_year_of_birth.Text.Trim() == "" && tTaiKhoan.Text.Trim() == "" && c_staff_is_manager.Checked == c_staff_is_seller.Checked)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

//=======
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
            doc.Load(file_name);
            root = doc.DocumentElement;
            XmlNode staff = doc.CreateElement("staff");

            XmlElement staff_id = doc.CreateElement("staff_id");
            staff_id.InnerText = t_id.Text;
            staff.AppendChild(staff_id);

            XmlElement staff_name = doc.CreateElement("staff_name");
            staff_name.InnerText = t_staff_name.Text;
            staff.AppendChild(staff_name);

            XmlElement staff_sex = doc.CreateElement("staff_sex");
            staff_sex.InnerText = t_staff_sex.Text;
            staff.AppendChild(staff_sex);

            XmlElement staff_year_of_birth = doc.CreateElement("staff_year_of_birth");
            staff_year_of_birth.InnerText = t_staff_year_of_birth.Text;
            staff.AppendChild(staff_year_of_birth);

            XmlElement staff_is_manager = doc.CreateElement("staff_is_manager");
//<<<<<<< HEAD
            staff_is_manager.InnerText = (c_staff_is_manager.Checked ? "true" : "");
            staff.AppendChild(staff_is_manager);

            XmlElement staff_is_seller = doc.CreateElement("staff_is_seller");
            staff_is_seller.InnerText = (c_staff_is_seller.Checked ? "true" : "");
            staff.AppendChild(staff_is_seller);

            ////////
            docUser.Load(fileNameUser);
            rootUser = docUser.DocumentElement;
            XmlNode user = docUser.CreateElement("user");

            XmlElement staff_idUser = docUser.CreateElement("staff_id");
            staff_idUser.InnerText = t_id.Text;
            user.AppendChild(staff_idUser);

            XmlElement username = docUser.CreateElement("username");
            username.InnerText = tTaiKhoan.Text;
            user.AppendChild(username);

            XmlElement password = docUser.CreateElement("password");
            password.InnerText = "1";
            user.AppendChild(password);
            /////////

            Back_Click(sender, e);
            if (user != null && staff != null)
            {
                root.AppendChild(staff);
                rootUser.AppendChild(user);
                doc.Save(file_name);
                docUser.Save(fileNameUser);
                MessageBox.Show("Thêm thành công!");
            }
            HienThi();
        }

//=======
//            staff_is_manager.InnerText = (c_staff_is_manager.CheckState.ToString() == "Checked" ? "true" : "false");
//            staff.AppendChild(staff_is_manager);

//            XmlElement staff_is_seller = doc.CreateElement("staff_is_seller");
//            staff_is_seller.InnerText = (c_staff_is_seller.CheckState.ToString() == "Checked" ? "true" : "false"); ;
//            staff.AppendChild(staff_is_seller);

//            Back_Click(sender, e);
//            root.AppendChild(staff);
//            doc.Save(file_name);
//            HienThi();
//        }

//        private void sua_Click(object sender, EventArgs e)
//        {
//            Back_Click(sender, e);
//            them.Enabled = false;
//            sua.Enabled = false;
//            xoa.Enabled = false;
//            save_update.Enabled = true;

//            t_id.ReadOnly = true;
//        }

//        private void save_update_Click(object sender, EventArgs e)
//        {
//            doc.Load(file_name);
//            root = doc.DocumentElement;

//            XmlNode staff_old = root.SelectSingleNode("staff[staff_id = '" + t_id.Text + "']");
//            //MessageBox.Show((staff_old.ToString() == null ? "null" : "not null"));
//            if (staff_old != null)
//            {
//                XmlNode staff_new = doc.CreateElement("staff");

//                XmlElement staff_id = doc.CreateElement("staff_id");
//                staff_id.InnerText = t_id.Text;
//                staff_new.AppendChild(staff_id);

//                XmlElement staff_name = doc.CreateElement("staff_name");
//                staff_name.InnerText = t_staff_name.Text;
//                staff_new.AppendChild(staff_name);

//                XmlElement staff_sex = doc.CreateElement("staff_sex");
//                staff_sex.InnerText = t_staff_sex.Text;
//                staff_new.AppendChild(staff_sex);

//                XmlElement staff_year_of_birth = doc.CreateElement("staff_year_of_birth");
//                staff_year_of_birth.InnerText = t_staff_year_of_birth.Text;
//                staff_new.AppendChild(staff_year_of_birth);

//                XmlElement staff_is_manager = doc.CreateElement("staff_is_manager");
//                staff_is_manager.InnerText = (c_staff_is_manager.CheckState.ToString() == "Checked" ? "true" : "false");
//                staff_new.AppendChild(staff_is_manager);

//                XmlElement staff_is_seller = doc.CreateElement("staff_is_seller");
//                staff_is_seller.InnerText = (c_staff_is_seller.CheckState.ToString() == "Checked" ? "true" : "false"); ;
//                staff_new.AppendChild(staff_is_seller);

//                root.ReplaceChild(staff_new, staff_old);
//                doc.Save(file_name);
//                HienThi();
//            }
//            Back_Click(sender, e);
//        }

//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
        private void xoa_Click(object sender, EventArgs e)
        {
            doc.Load(file_name);
            root = doc.DocumentElement;
//<<<<<<< HEAD

            docUser.Load(fileNameUser);
            rootUser = docUser.DocumentElement;

            XmlNode staff_delete = root.SelectSingleNode("staff[staff_id = '" + t_id.Text + "']");
            XmlNode user_delete = rootUser.SelectSingleNode("user[staff_id = '" + t_id.Text + "']");
            if (staff_delete != null && user_delete != null)
            {
                root.RemoveChild(staff_delete);
                rootUser.RemoveChild(user_delete);
                doc.Save(file_name);
                docUser.Save(fileNameUser);
//=======
//            XmlNode staff_delete = root.SelectSingleNode("staff[staff_id = '" + t_id.Text + "']");
//            if (staff_delete != null)
//            {
//                root.RemoveChild(staff_delete);
//                doc.Save(file_name);
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
            }
            dataGridView1.Rows.Clear();
            HienThi();
            Back_Click(sender, e);
        }

        private void t_timKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = t_timKiem.Text.Trim().ToLower();

            // Kiểm tra dữ liệu tìm kiếm
            if (searchText == "")
            {
                // Nếu ô tìm kiếm trống, hiển thị lại toàn bộ dữ liệu
                HienThi();
            }
            else
            {
                try
                {
                    // Load lại dữ liệu từ tệp XML
                    doc.Load(file_name);
                    root = doc.DocumentElement;

//<<<<<<< HEAD
                    docUser.Load(fileNameUser);
                    rootUser = docUser.DocumentElement;

//=======
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
                    // Tạo danh sách nhân viên phù hợp với điều kiện tìm kiếm
                    //XmlNodeList ds = root.SelectNodes($"staff[contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}')]");
                    XmlNodeList ds = root.SelectNodes($"staff[contains(translate(staff_id, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                                    $"contains(translate(staff_name, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                                    $"contains(translate(staff_sex, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                                    $"contains(translate(staff_year_of_birth, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                                    $"contains(translate(staff_is_manager, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                                    $"contains(translate(staff_is_seller, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}')]");

//<<<<<<< HEAD
                    XmlNodeList users = root.SelectNodes($"staff[contains(translate(username, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}')]");
//=======

//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7

                    // Xóa dữ liệu hiện tại trên DataGridView
                    dataGridView1.Rows.Clear();

                    int sd = 0;
                    foreach (XmlNode node in ds)
                    {
//<<<<<<< HEAD
                        foreach (XmlNode user in users)
                        {
                            if(node.SelectSingleNode("staff_id").InnerText == user.SelectSingleNode("staff_id").InnerText)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[sd].Cells[0].Value = node.SelectSingleNode("staff_id").InnerText;
                                dataGridView1.Rows[sd].Cells[1].Value = node.SelectSingleNode("staff_name").InnerText;
                                dataGridView1.Rows[sd].Cells[2].Value = node.SelectSingleNode("username").InnerText;
                                dataGridView1.Rows[sd].Cells[3].Value = node.SelectSingleNode("staff_sex").InnerText;
                                dataGridView1.Rows[sd].Cells[4].Value = node.SelectSingleNode("staff_year_of_birth").InnerText;
                                dataGridView1.Rows[sd].Cells[5].Value = node.SelectSingleNode("staff_is_manager").InnerText;
                                dataGridView1.Rows[sd].Cells[6].Value = node.SelectSingleNode("staff_is_seller").InnerText;
                                sd++;
                            }
                        }
//=======
//                        dataGridView1.Rows.Add();
//                        dataGridView1.Rows[sd].Cells[0].Value = node.SelectSingleNode("staff_id").InnerText;
//                        dataGridView1.Rows[sd].Cells[1].Value = node.SelectSingleNode("staff_name").InnerText;
//                        dataGridView1.Rows[sd].Cells[2].Value = node.SelectSingleNode("staff_sex").InnerText;
//                        dataGridView1.Rows[sd].Cells[3].Value = node.SelectSingleNode("staff_year_of_birth").InnerText;
//                        dataGridView1.Rows[sd].Cells[4].Value = node.SelectSingleNode("staff_is_manager").InnerText;
//                        dataGridView1.Rows[sd].Cells[5].Value = node.SelectSingleNode("staff_is_seller").InnerText;
//                        sd++;
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

//<<<<<<< HEAD
        private void bResetPass_Click(object sender, EventArgs e)
        {
            if (t_id.Text.Trim() == ""  || tTaiKhoan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đủ id và thông tin tài khoản!");
                return;
            }

            //MessageBox.Show((tTaiKhoan.Text.Trim() == "") ? "true" : "false") ;

            docUser.Load(fileNameUser);
            rootUser = docUser.DocumentElement;

            XmlNode userOld = rootUser.SelectSingleNode("user[staff_id = '" + t_id.Text + "']");
            if (userOld != null)
            {
                XmlNode userNew = docUser.CreateElement("user");

                XmlElement staff_idUser = docUser.CreateElement("staff_id");
                staff_idUser.InnerText = t_id.Text;
                userNew.AppendChild(staff_idUser);

                XmlElement username = docUser.CreateElement("username");
                username.InnerText = tTaiKhoan.Text;
                userNew.AppendChild(username);

                XmlElement password = docUser.CreateElement("password");
                password.InnerText ="1";
                userNew.AppendChild(password);

                rootUser.ReplaceChild(userNew, userOld);
                docUser.Save(fileNameUser);
                MessageBox.Show("Reset password thành công!");
            }
        }
}
//=======
//    }
//>>>>>>> c2d3df597e691b1b3674c746574484aac01f0df7
}
