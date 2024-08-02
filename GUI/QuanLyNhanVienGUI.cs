namespace QPharma.GUI;

public partial class QuanLyNhanVienGUI : BaseForm
{
    private readonly XmlDocument doc = new();
    private readonly XmlDocument docUser = new();

    private readonly string file_name = Config.getXMLPath("staffs");

    private readonly string fileNameUser = Config.getXMLPath("users");
    private XmlElement root;
    private XmlElement rootUser;

    public QuanLyNhanVienGUI()
    {
        InitializeComponent();
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
        //dateTimePicker1.Text = "00/00/0000";

        t_id.ReadOnly = true;
        HienThi();
    }


    private void HienThi()
    {
        try
        {
            doc.Load(file_name);
            root = doc.DocumentElement;


            docUser.Load(fileNameUser);
            rootUser = docUser.DocumentElement;

            var ds = root.SelectNodes("staff");
            var users = rootUser.SelectNodes("user");
            var sd = 0;
            dataGridView1.Rows.Clear();


            foreach (XmlNode node in ds)
            foreach (XmlNode user in users)
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
        catch (Exception ex)
        {
            MessageBox.Show("Đã xảy ra lỗi khi đọc tệp XML: " + ex.Message);
        }
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        them.Enabled = false;
        sua.Enabled = true;
        xoa.Enabled = true;
        bResetPass.Enabled = true;

        var t = dataGridView1.CurrentCell.RowIndex;
        t_id.Text = dataGridView1.Rows[t].Cells[0].Value.ToString();
        t_staff_name.Text = dataGridView1.Rows[t].Cells[1].Value.ToString();
        tTaiKhoan.Text = dataGridView1.Rows[t].Cells[2].Value.ToString();
        t_staff_sex.Text = dataGridView1.Rows[t].Cells[3].Value.ToString();
        dateTimePicker1.Text = dataGridView1.Rows[t].Cells[4].Value.ToString();
        if (dataGridView1.Rows[t].Cells[5].Value.ToString().Trim() == "true")
            c_staff_is_manager.Checked = true;
        else
            c_staff_is_manager.Checked = false;

        if (dataGridView1.Rows[t].Cells[6].Value.ToString().Trim() == "true")
            c_staff_is_seller.Checked = true;
        else
            c_staff_is_seller.Checked = false;
    }

    private void Back_Click(object sender, EventArgs e)
    {
        t_id.ReadOnly = true;


        t_id.Text = "";
        t_staff_name.Text = "";
        t_staff_sex.Text = "";
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

    private void sua_Click(object sender, EventArgs e)
    {
        if (t_id.Text.Trim() == "" && t_staff_name.Text.Trim() == "" && t_staff_sex.Text.Trim() == "" &&
            dateTimePicker1.Text.Trim() == "" && tTaiKhoan.Text.Trim() == "" &&
            c_staff_is_manager.Checked == c_staff_is_seller.Checked)
        {
            MessageBox.Show("Vui lòng nhập đủ thông tin!");
            return;
        }

        doc.Load(file_name);
        docUser.Load(fileNameUser);

        root = doc.DocumentElement;
        rootUser = docUser.DocumentElement;

        var staff_old = root.SelectSingleNode("staff[staff_id = '" + t_id.Text.Trim() + "']");
        var userOld = rootUser.SelectSingleNode("user[staff_id = '" + t_id.Text.Trim() + "']");
        if (staff_old != null && userOld != null)
        {
            XmlNode staff_new = doc.CreateElement("staff");
            XmlNode userNew = docUser.CreateElement("user");

            var staff_id = doc.CreateElement("staff_id");
            staff_id.InnerText = t_id.Text.Trim();
            staff_new.AppendChild(staff_id);

            var staff_name = doc.CreateElement("staff_name");
            staff_name.InnerText = t_staff_name.Text.Trim();
            staff_new.AppendChild(staff_name);


            var staff_idUser = docUser.CreateElement("staff_id");
            staff_idUser.InnerText = t_id.Text.Trim();
            userNew.AppendChild(staff_idUser);

            var username = docUser.CreateElement("username");
            username.InnerText = tTaiKhoan.Text.Trim();
            userNew.AppendChild(username);

            var password = docUser.CreateElement("password");
            password.InnerText = userOld.SelectSingleNode("password").InnerText;
            userNew.AppendChild(password);


            var staff_sex = doc.CreateElement("staff_sex");
            staff_sex.InnerText = t_staff_sex.Text.Trim();
            staff_new.AppendChild(staff_sex);

            var staff_year_of_birth = doc.CreateElement("staff_year_of_birth");
            staff_year_of_birth.InnerText = dateTimePicker1.Text.Trim();
            staff_new.AppendChild(staff_year_of_birth);

            var staff_is_manager = doc.CreateElement("staff_is_manager");
            staff_is_manager.InnerText = c_staff_is_manager.Checked ? "true" : "";
            staff_new.AppendChild(staff_is_manager);

            var staff_is_seller = doc.CreateElement("staff_is_seller");
            staff_is_seller.InnerText = c_staff_is_seller.Checked ? "true" : "";
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
        if (t_id.Text.Trim() == "" && t_staff_name.Text.Trim() == "" && t_staff_sex.Text.Trim() == "" &&
            dateTimePicker1.Text.Trim() == "" && tTaiKhoan.Text.Trim() == "" &&
            c_staff_is_manager.Checked == c_staff_is_seller.Checked)
        {
            MessageBox.Show("Vui lòng nhập đủ thông tin!");
            return;
        }

        doc.Load(file_name);
        root = doc.DocumentElement;
        XmlNode staff = doc.CreateElement("staff");

        var staffs = root.SelectSingleNode("staff[staff_id = '" + t_id.Text.Trim() + "']");
        if (staffs != null)
            if (staffs.SelectSingleNode("staff_id").InnerText != "")
            {
                MessageBox.Show("Đã có nhân viên tồn tại id trên!");
                return;
            }

        var staff_id = doc.CreateElement("staff_id");
        staff_id.InnerText = t_id.Text.Trim();
        staff.AppendChild(staff_id);

        var staff_name = doc.CreateElement("staff_name");
        staff_name.InnerText = t_staff_name.Text.Trim();
        staff.AppendChild(staff_name);

        var staff_sex = doc.CreateElement("staff_sex");
        staff_sex.InnerText = t_staff_sex.Text.Trim();
        staff.AppendChild(staff_sex);

        var staff_year_of_birth = doc.CreateElement("staff_year_of_birth");
        staff_year_of_birth.InnerText = dateTimePicker1.Text.Trim();
        staff.AppendChild(staff_year_of_birth);

        var staff_is_manager = doc.CreateElement("staff_is_manager");

        staff_is_manager.InnerText = c_staff_is_manager.Checked ? "true" : "";
        staff.AppendChild(staff_is_manager);

        var staff_is_seller = doc.CreateElement("staff_is_seller");
        staff_is_seller.InnerText = c_staff_is_seller.Checked ? "true" : "";
        staff.AppendChild(staff_is_seller);


        docUser.Load(fileNameUser);
        rootUser = docUser.DocumentElement;
        XmlNode user = docUser.CreateElement("user");

        var staff_idUser = docUser.CreateElement("staff_id");
        staff_idUser.InnerText = t_id.Text.Trim();
        user.AppendChild(staff_idUser);

        var username = docUser.CreateElement("username");
        username.InnerText = tTaiKhoan.Text.Trim();
        user.AppendChild(username);

        var password = docUser.CreateElement("password");
        password.InnerText = "1";
        user.AppendChild(password);


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


    private void xoa_Click(object sender, EventArgs e)
    {
        doc.Load(file_name);
        root = doc.DocumentElement;


        docUser.Load(fileNameUser);
        rootUser = docUser.DocumentElement;

        var staff_delete = root.SelectSingleNode("staff[staff_id = '" + t_id.Text.Trim() + "']");
        var user_delete = rootUser.SelectSingleNode("user[staff_id = '" + t_id.Text.Trim() + "']");
        if (staff_delete != null && user_delete != null)
        {
            root.RemoveChild(staff_delete);
            rootUser.RemoveChild(user_delete);
            doc.Save(file_name);
            docUser.Save(fileNameUser);
            MessageBox.Show("Xóa thành công!");
        }

        dataGridView1.Rows.Clear();
        HienThi();
        Back_Click(sender, e);
    }

    private void t_timKiem_TextChanged(object sender, EventArgs e)
    {
        var searchText = t_timKiem.Text.Trim().ToLower();


        if (searchText == "")
            HienThi();
        else
            try
            {
                doc.Load(file_name);
                root = doc.DocumentElement;

                docUser.Load(fileNameUser);
                rootUser = docUser.DocumentElement;


                var ds = root.SelectNodes(
                    $"staff[contains(translate(staff_id, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    $"contains(translate(staff_name, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    $"contains(translate(staff_sex, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    $"contains(translate(staff_year_of_birth, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    $"contains(translate(staff_is_manager, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    $"contains(translate(staff_is_seller, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}')]");


                var users = rootUser.SelectNodes(
                    $"user[contains(translate(username, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}') or " +
                    $"contains(translate(staff_id, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{searchText}')]");

                var usersList = rootUser.SelectNodes("user");
                var staffsList = root.SelectNodes("staff");

                dataGridView1.Rows.Clear();
                if (ds.Count > 0) DuyetTimKiemPhanTu(ds, usersList);
                if (users.Count > 0) DuyetTimKiemPhanTu(staffsList, users);
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

    //<<<<<<< HEAD
    private void bResetPass_Click(object sender, EventArgs e)
    {
        if (t_id.Text.Trim() == "" || tTaiKhoan.Text.Trim() == "")
        {
            MessageBox.Show("Vui lòng nhập đủ id và thông tin tài khoản!");
            return;
        }

        //MessageBox.Show((tTaiKhoan.Text.Trim() == "") ? "true" : "false") ;

        docUser.Load(fileNameUser);
        rootUser = docUser.DocumentElement;

        var userOld = rootUser.SelectSingleNode("user[staff_id = '" + t_id.Text.Trim() + "']");
        if (userOld != null)
        {
            XmlNode userNew = docUser.CreateElement("user");

            var staff_idUser = docUser.CreateElement("staff_id");
            staff_idUser.InnerText = t_id.Text.Trim();
            userNew.AppendChild(staff_idUser);

            var username = docUser.CreateElement("username");
            username.InnerText = tTaiKhoan.Text.Trim();
            userNew.AppendChild(username);

            var password = docUser.CreateElement("password");
            password.InnerText = "1";
            userNew.AppendChild(password);

            rootUser.ReplaceChild(userNew, userOld);
            docUser.Save(fileNameUser);
            MessageBox.Show("Reset password thành công!");
        }
    }
}