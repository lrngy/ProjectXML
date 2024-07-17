using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using ProjectXML.BUS;
using ProjectXML.DTO;
using ProjectXML.GUI.Dialog;
using ProjectXML.Util;

namespace ProjectXML.GUI
{
    public partial class QuanLyThuocGUI : Form
    {
        private readonly CategoryBUS categoryController = new CategoryBUS();

        private int cbIndexLoc;
        private int cbIndexTieuChiThuoc = 1;
        private FilterByRangeDialog filterByRangeDialog;

        public int indexTieuChiNCC = 1;
        private readonly MedicineBUS medicineController = new MedicineBUS();

        private readonly XmlDocument nhacungcap = Config.getDoc("suppliers");

        private int rowSelectedTheLoai;
        private int rowSelectedThuoc;
        private readonly SupplierBUS supplierController = new SupplierBUS();
        private readonly int tabControlIndex;

        private readonly UserDTO user;

        public QuanLyThuocGUI(UserDTO user, int tabControlIndex)
        {
            InitializeComponent();
            this.user = user;
            this.tabControlIndex = tabControlIndex;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            var tabIndex = tabControl1.SelectedIndex;
            switch (tabIndex)
            {
                case 0:
                    if (!user.staff.isManager)
                    {
                        CustomMessageBox.ShowError("Bạn không có quyền truy cập chức năng này");
                        e.Cancel = true;
                    }

                    QuanLyThuoc_Load();
                    lbHeader.Text = "QUẢN LÝ THUỐC";

                    break;
                case 1:
                    TheLoai_Load();
                    lbHeader.Text = "QUẢN LÝ DANH MỤC THUỐC";
                    break;
                case 2:
                    NhaCungCap_Load();
                    lbHeader.Text = "QUẢN LÝ NHÀ CUNG CẤP";
                    break;
            }
        }

        private void QuanLyThuoc_Load()
        {
            TimThuocTheoDuLieu();

            cbTieuChiThuoc.SelectedIndex = cbIndexTieuChiThuoc;


            cbTLThuoc.Items.Clear();
            cbNccThuoc.Items.Clear();
            var categoryList = categoryController.LoadData();
            foreach (var category in categoryList)
            {
                if (!category.deleted.Equals("") || !category.status) continue;
                cbTLThuoc.Items.Add(category.id + "-" + category.name);
            }

            var supplierList = supplierController.LoadData();
            foreach (var supplier in supplierList)
            {
                if (!supplier.status) continue;
                cbNccThuoc.Items.Add(supplier.id + "-" + supplier.name);
            }

            try
            {
                dgvThuoc.Rows[rowSelectedThuoc].Selected = true;
            }
            catch (Exception)
            {
            }
        }

        private void QuanLyThuoc_Show(List<MedicineDTO> medicines)
        {
            var i = 0;
            dgvThuoc.Rows.Clear();
            var medicineList = medicines;


            foreach (var medicine in medicineList)
            {
                if (!medicine.deleted.Equals("") || medicine.category == null || medicine.supplier == null ||
                    !medicine.supplier.status || !medicine.category.status) continue;

                dgvThuoc.Rows.Add(++i, medicine.id, medicine.name, $"{medicine.category.id}-{medicine.category.name}",
                    medicine.expireDate, medicine.quantity, medicine.unit, medicine.price, medicine.description,
                    $"{medicine.supplier.id}-{medicine.supplier.name}", medicine.created, medicine.updated);
            }

            ClearInputThuoc();
            pictureBoxThuoc.ImageLocation = "";
            dgvThuoc_CellClick(new object(), new DataGridViewCellEventArgs(0, rowSelectedThuoc));
        }

        public void ClearInputThuoc()
        {
            tbMaThuoc.Text = "";
            tbTenThuoc.Text = "";
            tbSL.Text = "";
            tbDVT.Text = "";
            tbGia.Text = "";
            tbMoTa.Text = "";
        }

        private void NhaCungCap_Load()
        {
            var supplierNodes = nhacungcap.SelectNodes("/suppliers/supplier");
            HienThiNCC(supplierNodes);

            cbTTNCC.SelectedIndex = 0;
            cbTieuChiNCC.SelectedIndex = indexTieuChiNCC;
        }

        public void HienThiNCC(XmlNodeList list)
        {
            var i = 0;
            dgvNhaCungCap.Rows.Clear();


            var supplierNodes = list;
            foreach (XmlNode supplierNode in supplierNodes)
            {
                var id = supplierNode.SelectSingleNode("supplier_id").InnerText;
                var name = supplierNode.SelectSingleNode("supplier_name").InnerText;
                var phone = supplierNode.SelectSingleNode("supplier_phone").InnerText;
                var email = supplierNode.SelectSingleNode("supplier_email").InnerText;
                var note = supplierNode.SelectSingleNode("supplier_note").InnerText;
                var status = bool.Parse(supplierNode.SelectSingleNode("supplier_status").InnerText);

                dgvNhaCungCap.Rows.Add(++i, id, name, phone, email, note, status ? "Khả dụng" : "Không khả dụng");
            }

            tbMaNCC.Text = "";
            tbTenNCC.Text = "";
            tbDienThoai.Text = "";
            tbEmail.Text = "";
            tbGhiChuNCC.Text = "";
            cbTieuChiNCC.SelectedIndex = indexTieuChiNCC;
        }

        public void ClearInput()
        {
            tbMaTheLoai.Text = "";
            tbTenTheLoai.Text = "";
            tbGhiChuTheLoai.Text = "";
            cbTrangThaiTheLoai.SelectedIndex = 0;
        }

        public void TheLoai_Show(List<Category> list)
        {
            var i = 0;
            dgvTheLoai.Rows.Clear();
            var categoryController = new CategoryBUS();
            var categoryList = list;
            foreach (var category in categoryList)
            {
                if (!category.deleted.Equals(""))
                {
                    Debug.WriteLine("Deleted: " + category.deleted);
                    continue;
                }

                dgvTheLoai.Rows.Add(++i, category.id, category.name, category.note,
                    category.status ? "Khả dụng" : "Không khả dụng", category.created, category.updated);
            }

            ClearInput();
        }

        private void TheLoai_Load()
        {
            if (tbTimTheLoai.Text.Equals(""))
                TheLoai_Show(categoryController.LoadData());
            else TimTheLoai();

            cbTieuChiTheLoai.SelectedIndex = cbIndexTieuChiThuoc;

            try
            {
                dgvTheLoai.Rows[rowSelectedTheLoai].Selected = true;
            }
            catch (Exception)
            {
            }
        }

        private void QuanLyThuocView_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControlIndex;
            QuanLyThuoc_Load();
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            var maTheLoai = tbMaTheLoai.Text;
            var tenTheLoai = tbTenTheLoai.Text;
            var ghiChu = tbGhiChuTheLoai.Text;
            var trangThai = cbTrangThaiTheLoai.SelectedIndex == 0 ? true : false;
            if (maTheLoai.Equals("") || tenTheLoai.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập mã thể loại");
                return;
            }

            if (tenTheLoai.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập tên thể loại");
                return;
            }

            var category = new Category(maTheLoai, tenTheLoai, ghiChu, trangThai, CustomDateTime.GetNow(), "", "");
            var state = categoryController.Insert(category);

            if (state == Predefined.SUCCESS)
            {
                TheLoai_Load();
                return;
            }

            if (state == Predefined.ID_EXIST)
                CustomMessageBox.ShowError("Mã thể loại đã tồn tại");
            else
                CustomMessageBox.ShowError("Thêm thất bại");
        }

        private void btnSuaTheLoai_Click(object sender, EventArgs e)
        {
            var maTheLoai = tbMaTheLoai.Text;
            var tenTheLoai = tbTenTheLoai.Text;
            var ghiChu = tbGhiChuTheLoai.Text;
            var trangThai = cbTrangThaiTheLoai.SelectedIndex == 0 ? true : false;
            var created = dgvTheLoai.Rows[rowSelectedTheLoai].Cells[5].Value.ToString();
            if (maTheLoai.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập mã thể loại");
                return;
            }

            var category = new Category(maTheLoai, tenTheLoai, ghiChu, trangThai, created, CustomDateTime.GetNow(), "");
            var state = categoryController.Update(category);

            if (state == Predefined.SUCCESS)
            {
                TheLoai_Load();
                return;
            }

            if (state == Predefined.ID_NOT_EXIST)
                CustomMessageBox.ShowError("Mã thể loại không tồn tại");
            else
                CustomMessageBox.ShowError("Sửa thất bại");
        }

        private void dgvTheLoai_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var index = dgvTheLoai.CurrentRow.Index;
                rowSelectedTheLoai = index;
                tbMaTheLoai.Text = dgvTheLoai.Rows[index].Cells[1].Value.ToString();
                tbTenTheLoai.Text = dgvTheLoai.Rows[index].Cells[2].Value.ToString();
                tbGhiChuTheLoai.Text = dgvTheLoai.Rows[index].Cells[3].Value.ToString();
                cbTrangThaiTheLoai.SelectedIndex =
                    dgvTheLoai.Rows[index].Cells[4].Value.ToString().Equals("Khả dụng") ? 0 : 1;
            }
            catch (Exception)
            {
                ClearInput();
            }
        }

        private void btnXoaTheLoai_Click(object sender, EventArgs e)
        {
            var maTheLoai = tbMaTheLoai.Text;
            if (maTheLoai.Equals(""))
            {
                CustomMessageBox.ShowError("Mã thể loại không hợp lệ");
                return;
            }

            var state = categoryController.Delete(maTheLoai);
            if (state == Predefined.SUCCESS)
            {
                TheLoai_Load();
                return;
            }

            if (state == Predefined.ID_NOT_EXIST)
                CustomMessageBox.ShowError("Mã thể loại không tồn tại");
            else
                CustomMessageBox.ShowError("Xóa thất bại");
        }

        private void btnLuuTruTheLoai_Click(object sender, EventArgs e)
        {
            var deletedCategory = new DeletedCategoryDialog(categoryController);
            deletedCategory.refreshDeletedCategory += TheLoai_Load;
            deletedCategory.ShowDialog();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var index = e.RowIndex;
                tbMaNCC.Text = dgvNhaCungCap.Rows[index].Cells[1].Value.ToString();
                tbTenNCC.Text = dgvNhaCungCap.Rows[index].Cells[2].Value.ToString();
                tbDienThoai.Text = dgvNhaCungCap.Rows[index].Cells[3].Value.ToString();
                tbEmail.Text = dgvNhaCungCap.Rows[index].Cells[4].Value.ToString();
                tbGhiChuNCC.Text = dgvNhaCungCap.Rows[index].Cells[5].Value.ToString();
                cbTTNCC.SelectedIndex = dgvNhaCungCap.Rows[index].Cells[6].Value.ToString().Equals("Khả dụng") ? 0 : 1;
            }
            catch (Exception)
            {
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            var maNCC = tbMaNCC.Text;
            var tenNCC = tbTenNCC.Text;
            var dienThoai = tbDienThoai.Text;
            var email = tbEmail.Text;
            var ghiChu = tbGhiChuNCC.Text;
            var trangThai = cbTTNCC.SelectedIndex == 0 ? "true" : "false";
            if (maNCC.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập mã nhà cung cấp");
                return;
            }

            if (tenNCC.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập tên nhà cung cấp");
                return;
            }

            if (!email.Equals("") && !email.Contains("@"))
            {
                CustomMessageBox.ShowError("Email không hợp lệ");
                return;
            }

            if (!dienThoai.Equals("") && !int.TryParse(dienThoai, out var dt))
            {
                CustomMessageBox.ShowError("Số điện thoại không hợp lệ");
                return;
            }


            var xmlNode = nhacungcap.SelectSingleNode("/suppliers/supplier[supplier_id='" + maNCC + "']");
            if (xmlNode != null)
            {
                CustomMessageBox.ShowError("Mã nhà cung cấp đã tồn tại");
                return;
            }


            XmlNode supplierNode = nhacungcap.CreateElement("supplier");

            XmlNode idNode = nhacungcap.CreateElement("supplier_id");
            idNode.InnerText = maNCC;
            supplierNode.AppendChild(idNode);

            XmlNode nameNode = nhacungcap.CreateElement("supplier_name");
            nameNode.InnerText = tenNCC;
            supplierNode.AppendChild(nameNode);


            XmlNode noteNode = nhacungcap.CreateElement("supplier_note");
            noteNode.InnerText = ghiChu;
            supplierNode.AppendChild(noteNode);


            XmlNode phoneNode = nhacungcap.CreateElement("supplier_phone");
            phoneNode.InnerText = dienThoai;
            supplierNode.AppendChild(phoneNode);

            XmlNode emailNode = nhacungcap.CreateElement("supplier_email");
            emailNode.InnerText = email;
            supplierNode.AppendChild(emailNode);

            XmlNode statusNode = nhacungcap.CreateElement("supplier_status");
            statusNode.InnerText = trangThai;
            supplierNode.AppendChild(statusNode);


            nhacungcap.SelectSingleNode("/suppliers").AppendChild(supplierNode);
            nhacungcap.Save(Config.getXMLPath("suppliers"));
            NhaCungCap_Load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var maNCC = tbMaNCC.Text;
            var tenNCC = tbTenNCC.Text;
            var dienThoai = tbDienThoai.Text;
            var email = tbEmail.Text;
            var ghiChu = tbGhiChuNCC.Text;
            var trangThai = cbTTNCC.SelectedIndex == 0 ? true : false;


            if (maNCC.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập mã nhà cung cấp");
                return;
            }

            if (tenNCC.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập tên nhà cung cấp");
                return;
            }

            if (!email.Equals("") && !email.Contains("@"))
            {
                CustomMessageBox.ShowError("Email không hợp lệ");
                return;
            }

            if (!dienThoai.Equals("") && !int.TryParse(dienThoai, out var dt))
            {
                CustomMessageBox.ShowError("Số điện thoại không hợp lệ");
                return;
            }

            var xmlNode = nhacungcap.SelectSingleNode("/suppliers/supplier[supplier_id='" + maNCC + "']");
            if (xmlNode == null)
            {
                CustomMessageBox.ShowError("Mã nhà cung cấp không hợp lệ");
                return;
            }

            xmlNode.SelectSingleNode("supplier_name").InnerText = tenNCC;
            xmlNode.SelectSingleNode("supplier_phone").InnerText = dienThoai;
            xmlNode.SelectSingleNode("supplier_email").InnerText = email;
            xmlNode.SelectSingleNode("supplier_note").InnerText = ghiChu;
            xmlNode.SelectSingleNode("supplier_status").InnerText = trangThai.ToString();
            nhacungcap.Save(Config.getXMLPath("suppliers"));
            NhaCungCap_Load();
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            var maNCC = tbMaNCC.Text;
            var xmlNode = nhacungcap.SelectSingleNode("/suppliers/supplier[supplier_id='" + maNCC + "']");
            if (xmlNode == null)
            {
                CustomMessageBox.ShowError("Mã nhà cung cấp không hợp lệ");
                return;
            }

            nhacungcap.SelectSingleNode("/suppliers").RemoveChild(xmlNode);
            nhacungcap.Save(Config.getXMLPath("suppliers"));
            NhaCungCap_Load();
        }

        private void tbTimNCC_TextChanged(object sender, EventArgs e)
        {
            var noidungtimkiem = tbTimNCC.Text;
            if (noidungtimkiem.Equals(""))
            {
                NhaCungCap_Load();
                return;
            }

            var tieuChiIndex = cbTieuChiNCC.SelectedIndex;
            dgvNhaCungCap.Rows.Clear();
            switch (tieuChiIndex)
            {
                case 0:
                    var supplierNodes =
                        nhacungcap.SelectNodes("/suppliers/supplier[contains(supplier_id,'" + noidungtimkiem + "')]");
                    HienThiNCC(supplierNodes);
                    break;
                case 1:
                    var supplierNodes2 =
                        nhacungcap.SelectNodes("/suppliers/supplier[contains(supplier_name,'" + noidungtimkiem + "')]");
                    HienThiNCC(supplierNodes2);
                    break;
                case 2:
                    var supplierNodes3 =
                        nhacungcap.SelectNodes("/suppliers/supplier[contains(supplier_phone,'" + noidungtimkiem +
                                               "')]");
                    HienThiNCC(supplierNodes3);
                    break;
                case 3:
                    var supplierNodes4 =
                        nhacungcap.SelectNodes("/suppliers/supplier[contains(supplier_email,'" + noidungtimkiem +
                                               "')]");
                    HienThiNCC(supplierNodes4);
                    break;
                case 4:
                    var supplierNodes5 =
                        nhacungcap.SelectNodes("/suppliers/supplier[contains(supplier_note,'" + noidungtimkiem + "')]");
                    HienThiNCC(supplierNodes5);
                    break;
                case 5:
                    var supplierNodes6 =
                        nhacungcap.SelectNodes(
                            "/suppliers/supplier[contains(supplier_status,'" + noidungtimkiem + "')]");
                    HienThiNCC(supplierNodes6);
                    break;
            }
        }

        public void TimTheLoai()
        {
            var noidungtimkiem = tbTimTheLoai.Text.ToLower().Trim();
            if (noidungtimkiem.Equals(""))
            {
                var index = cbTieuChiTheLoai.SelectedIndex;
                TheLoai_Load();
                cbTieuChiTheLoai.SelectedIndex = index;
                return;
            }

            var tieuChiIndex = cbTieuChiTheLoai.SelectedIndex;
            dgvTheLoai.Rows.Clear();
            var categoryList = categoryController.LoadData().Where(category =>
            {
                switch (tieuChiIndex)
                {
                    case 0:
                        return category.id.ToLower().Contains(noidungtimkiem);
                    case 1:
                        return category.name.ToLower().Contains(noidungtimkiem);
                    case 2:
                        return category.note.ToLower().Contains(noidungtimkiem);
                    case 3:
                        return (category.status ? "Khả dụng" : "Không khả dụng").ToLower().Contains(noidungtimkiem);
                    case 4:
                        return category.created.ToLower().Contains(noidungtimkiem);
                    case 5:
                        return category.updated.ToLower().Contains(noidungtimkiem);

                    default:
                        return false;
                }
            }).ToList();


            TheLoai_Show(categoryList);
        }

        private void tbTimTheLoai_TextChanged(object sender, EventArgs e)
        {
            TimTheLoai();
        }

        private void cbTieuChiTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbTimTheLoai_TextChanged(sender, e);
        }

        private void cbTieuChiNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexTieuChiNCC = cbTieuChiNCC.SelectedIndex;
            tbTimNCC_TextChanged(sender, e);
        }

        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var index = e.RowIndex;
                rowSelectedThuoc = index;
                tbMaThuoc.Text = dgvThuoc.Rows[index].Cells[1].Value.ToString();
                tbTenThuoc.Text = dgvThuoc.Rows[index].Cells[2].Value.ToString();

                var theLoai = dgvThuoc.Rows[index].Cells[3].Value.ToString();
                for (var i = 0; i < cbTLThuoc.Items.Count; i++)
                    if (cbTLThuoc.Items[i].ToString().Equals(theLoai))
                    {
                        cbTLThuoc.SelectedIndex = i;
                        break;
                    }

                var image = medicineController.LoadData().Where(item => item.id.Equals(tbMaThuoc.Text)).FirstOrDefault()
                    .image;
                pictureBoxThuoc.ImageLocation =
                    image.Equals("") ? "" : Path.Combine(Config.getImagePath(), $"{tbMaThuoc.Text}.jpg");


                dateTimePicker1.Value = DateTime.Parse(dgvThuoc.Rows[index].Cells[4].Value.ToString());
                tbSL.Text = dgvThuoc.Rows[index].Cells[5].Value.ToString();
                tbDVT.Text = dgvThuoc.Rows[index].Cells[6].Value.ToString();
                tbGia.Text = dgvThuoc.Rows[index].Cells[7].Value.ToString();
                tbMoTa.Text = dgvThuoc.Rows[index].Cells[8].Value.ToString();
                var nhaCungCap = dgvThuoc.Rows[index].Cells[9].Value.ToString();

                for (var i = 0; i < cbNccThuoc.Items.Count; i++)
                    if (cbNccThuoc.Items[i].ToString().Equals(nhaCungCap))
                    {
                        cbNccThuoc.SelectedIndex = i;
                        break;
                    }
            }
            catch (Exception)
            {
                ClearInputThuoc();
            }
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            var id = tbMaThuoc.Text;
            var name = tbTenThuoc.Text;
            var expireDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            var unit = tbDVT.Text;
            var quantityText = tbSL.Text;
            var priceText = tbGia.Text;
            var description = tbMoTa.Text;


            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(unit) ||
                string.IsNullOrEmpty(quantityText) || string.IsNullOrEmpty(priceText))
            {
                CustomMessageBox.ShowWarning("Vui lòng điền đầy đủ thông tin.");
                return;
            }


            if (!int.TryParse(quantityText, out var quantity))
            {
                CustomMessageBox.ShowWarning("Số lượng phải là số.");
                return;
            }

            if (!double.TryParse(priceText, out var price))
            {
                CustomMessageBox.ShowWarning("Giá phải là số.");
                return;
            }

            if (quantity < 0)
            {
                CustomMessageBox.ShowWarning("Số lượng phải lớn hơn hoặc bằng 0.");
                return;
            }

            if (price < 0)
            {
                CustomMessageBox.ShowWarning("Giá phải lớn hơn hoặc bằng 0.");
                return;
            }

            var tlIndex = cbTLThuoc.SelectedIndex;
            var nccIndex = cbNccThuoc.SelectedIndex;
            if (tlIndex == -1)
            {
                CustomMessageBox.ShowWarning("Vui lòng chọn thể loại.");
                return;
            }

            if (nccIndex == -1)
            {
                CustomMessageBox.ShowWarning("Vui lòng chọn nhà cung cấp.");
                return;
            }

            var tl = cbTLThuoc.Items[tlIndex].ToString();
            var ncc = cbNccThuoc.Items[nccIndex].ToString();

            var tlArr = tl.Split('-');
            var nccArr = ncc.Split('-');


            var image = "";

            var supplier = supplierController.LoadData().Where(s => s.id.Equals(nccArr[0])).FirstOrDefault();
            var category = categoryController.LoadData().Where(c => c.id.Equals(tlArr[0])).FirstOrDefault();
            var newMedicine = new MedicineDTO(id, name, expireDate, unit, price, quantity, image, description, supplier,
                CustomDateTime.GetNow(), "", "", category);


            var result = medicineController.Insert(newMedicine);


            if (result == Predefined.SUCCESS)
            {
                QuanLyThuoc_Load();
                CustomMessageBox.ShowSuccess("Thêm thông tin thuốc thành công");
                return;
            }

            if (result == Predefined.ID_EXIST)
                CustomMessageBox.ShowError("Mã thuốc đã tồn tại.");
            else
                CustomMessageBox.ShowError("Lỗi thêm thuốc.");
        }

        private void btnSuaThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                var id = tbMaThuoc.Text;
                var name = tbTenThuoc.Text;
                var expireDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                var unit = tbDVT.Text;
                var quantityText = tbSL.Text;
                var priceText = tbGia.Text;
                var image = medicineController.LoadData().Where(item => item.id.Equals(id)).FirstOrDefault().image;
                var description = tbMoTa.Text;
                var supplierId = cbNccThuoc.SelectedItem.ToString().Split('-')[0];
                var created = medicineController.LoadData().Where(item => item.id.Equals(id)).FirstOrDefault().created;
                var updated = CustomDateTime.GetNow();
                var categoryId = cbTLThuoc.SelectedItem.ToString().Split('-')[0];

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(unit) ||
                    string.IsNullOrEmpty(quantityText) || string.IsNullOrEmpty(priceText))
                {
                    CustomMessageBox.ShowWarning("Vui lòng điền đầy đủ thông tin.");
                    return;
                }


                if (!int.TryParse(quantityText, out var quantity))
                {
                    CustomMessageBox.ShowWarning("Số lượng phải là số.");
                    return;
                }

                if (!double.TryParse(priceText, out var price))
                {
                    CustomMessageBox.ShowWarning("Giá phải là số.");
                    return;
                }

                if (quantity < 0)
                {
                    CustomMessageBox.ShowWarning("Số lượng phải lớn hơn hoặc bằng 0.");
                    return;
                }

                if (price < 0)
                {
                    CustomMessageBox.ShowWarning("Giá phải lớn hơn hoặc bằng 0.");
                    return;
                }

                var tlIndex = cbTLThuoc.SelectedIndex;
                var nccIndex = cbNccThuoc.SelectedIndex;
                if (tlIndex == -1)
                {
                    CustomMessageBox.ShowWarning("Vui lòng chọn thể loại.");
                    return;
                }

                if (nccIndex == -1)
                {
                    CustomMessageBox.ShowWarning("Vui lòng chọn nhà cung cấp.");
                    return;
                }

                var supplier = supplierController.LoadData().Where(s => s.id.Equals(supplierId)).FirstOrDefault();
                var category = categoryController.LoadData().Where(c => c.id.Equals(categoryId)).FirstOrDefault();

                var medicine = new MedicineDTO(id, name, expireDate, unit, price, quantity, image, description,
                    supplier, created, updated, "", category);

                var result = medicineController.Update(medicine);
                if (result == Predefined.SUCCESS)
                {
                    QuanLyThuoc_Load();
                    CustomMessageBox.ShowSuccess("Sửa thông tin thuốc thành công");
                    return;
                }

                if (result == Predefined.FILE_NOT_FOUND) MessageBox.Show("Sửa thất bại");
            }
            catch (NullReferenceException)
            {
                CustomMessageBox.ShowError("Mã thuốc không hợp lệ");
            }
        }

        private void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                var maThuoc = dgvThuoc.Rows[dgvThuoc.CurrentRow.Index].Cells[1].Value.ToString();
                if (maThuoc.Equals(""))
                {
                    CustomMessageBox.ShowError("Mã thể loại không hợp lệ");
                    return;
                }

                var state = medicineController.Delete(maThuoc);
                if (state == Predefined.SUCCESS)
                {
                    if (rowSelectedThuoc != 0) rowSelectedThuoc--;
                    QuanLyThuoc_Load();

                    return;
                }

                if (state == Predefined.ID_NOT_EXIST)
                    CustomMessageBox.ShowError("Mã thể loại không tồn tại");
                else
                    CustomMessageBox.ShowError("Xóa thất bại");
            }
            catch (Exception)
            {
                CustomMessageBox.ShowError("Mã thể loại không hợp lệ");
            }
        }

        private void btnLuuThuoc_Click(object sender, EventArgs e)
        {
            var deletedMedicine = new DeletedMedicineDialog(medicineController);
            deletedMedicine.refreshDeletedMedicine += QuanLyThuoc_Load;
            deletedMedicine.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TimThuocTheoDuLieu();
        }

        private void TimThuoc(List<MedicineDTO> list = null)
        {
            var noidungtimkiem = tbTimThuoc.Text.ToLower().Trim();
            if (noidungtimkiem.Equals(""))
            {
                QuanLyThuoc_Show(list == null ? medicineController.LoadData() : list);
                return;
            }

            var tieuChiIndex = cbTieuChiThuoc.SelectedIndex;
            dgvThuoc.Rows.Clear();
            var medicineList = list != null ? list : medicineController.LoadData();
            var filterdMedicineList = medicineList.Where(medicine =>
            {
                switch (tieuChiIndex)
                {
                    case 0:
                        return medicine.id.ToLower().Contains(noidungtimkiem);
                    case 1:
                        return medicine.name.ToLower().Contains(noidungtimkiem);
                    case 2:
                        return medicine.category.name.ToLower().Contains(noidungtimkiem);
                    case 3:
                        return medicine.expireDate.ToLower().Contains(noidungtimkiem);
                    case 4:
                        return medicine.quantity.ToString().ToLower().Contains(noidungtimkiem);
                    case 5:
                        return medicine.unit.ToLower().Contains(noidungtimkiem);
                    case 6:
                        return medicine.price.ToString().ToLower().Contains(noidungtimkiem);
                    case 7:
                        return medicine.description.ToLower().Contains(noidungtimkiem);
                    case 8:
                        return medicine.supplier.name.ToLower().Contains(noidungtimkiem);
                    case 9:
                        return medicine.created.ToLower().Contains(noidungtimkiem);
                    case 10:
                        return medicine.updated.ToLower().Contains(noidungtimkiem);

                    default:
                        return false;
                }
            }).ToList();

            QuanLyThuoc_Show(filterdMedicineList);
        }

        private void cbTieuChiThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIndexTieuChiThuoc = cbTieuChiThuoc.SelectedIndex;
        }

        private void btnNhapLaiThuoc_Click(object sender, EventArgs e)
        {
            ClearInputThuoc();
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            var medicineId = tbMaThuoc.Text;
            if (medicineId.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng chọn thuốc hợp lệ");
                return;
            }

            var result = medicineController.ChangeImage(medicineId);

            if (result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess("Đổi ảnh thành công");
                QuanLyThuoc_Load();
                return;
            }

            if (result == Predefined.ID_NOT_EXIST)
                CustomMessageBox.ShowWarning("Mã thuốc không tồn tại");
            else
                CustomMessageBox.ShowError("Sự cố khi lưu ảnh");
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            var medicineId = tbMaThuoc.Text;
            if (medicineId.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng chọn thuốc hợp lệ");
                return;
            }

            var confirmResult = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn xóa ảnh này?");
            if (confirmResult == DialogResult.No) return;

            var result = medicineController.RemoveImage(medicineId);

            if (result == Predefined.SUCCESS)
            {
                QuanLyThuoc_Load();
                return;
            }

            if (result == Predefined.ID_NOT_EXIST)
                CustomMessageBox.ShowWarning("Mã thuốc không tồn tại");
            else
                CustomMessageBox.ShowError("Sự cố khi lưu ảnh");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbTimNCC.Text = "";
        }

        private void ckbLocDuLieuThuoc_CheckedChanged(object sender, EventArgs e)
        {
            cbLocDuLieuThuoc.Visible = ckbLocDuLieuThuoc.Checked;
            if (!ckbLocDuLieuThuoc.Checked && filterByRangeDialog != null) filterByRangeDialog.Dispose();

            cbLocDuLieuThuoc.SelectedIndex = cbIndexLoc;
            TimThuocTheoDuLieu();
        }

        public void FilterByRangeDialog_Disposed()
        {
            cbLocDuLieuThuoc.Enabled = true;
            //ckbLocDuLieuThuoc.Checked = false;
            cbIndexLoc = 0;
            cbLocDuLieuThuoc.SelectedIndex = 0;
            QuanLyThuoc_Load();
        }

        public void TimThuocTheoDuLieu()
        {
            if (!ckbLocDuLieuThuoc.Checked)
            {
                TimThuoc();
                return;
            }

            if (cbLocDuLieuThuoc.SelectedIndex == 1)
            {
                if (filterByRangeDialog == null || filterByRangeDialog.IsDisposed)
                {
                    filterByRangeDialog = new FilterByRangeDialog(medicineController);

                    cbLocDuLieuThuoc.Enabled = false;
                    filterByRangeDialog.onClick += TimThuoc;
                    filterByRangeDialog.Disposed += (_sender, _args) => { FilterByRangeDialog_Disposed(); };
                    filterByRangeDialog.FormClosing += (_sender, _args) => { FilterByRangeDialog_Disposed(); };
                }

                filterByRangeDialog.Show();
                filterByRangeDialog.btnFilter.PerformClick();
                return;
            }

            var list = medicineController.LoadData().Where(medicine =>
            {
                var expireDate = DateTime.Parse(medicine.expireDate);
                switch (cbLocDuLieuThuoc.SelectedIndex)
                {
                    case 2:
                        return expireDate.CompareTo(DateTime.Now) < 0;
                    case 3:
                        return expireDate.CompareTo(DateTime.Now) > 0;
                    case 4:
                        return medicine.quantity <= 0;
                    default:
                        return true;
                }
            }).ToList();
            TimThuoc(list);
        }

        private void cbLocDuLieuThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIndexLoc = cbLocDuLieuThuoc.SelectedIndex;
            TimThuocTheoDuLieu();
        }
    }
}