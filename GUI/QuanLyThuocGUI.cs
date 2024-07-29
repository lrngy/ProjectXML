using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using QPharma.BUS;
using QPharma.DAL;
using QPharma.DTO;
using QPharma.GUI.Dialog;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma.GUI
{
    public partial class QuanLyThuocGUI : BaseForm
    {
        private readonly CategoryBUS categoryBUS = new CategoryBUS();
        private readonly MedicineBUS medicineBUS = new MedicineBUS();
        private readonly MedicineLocationBUS medicineLocationBUS = new MedicineLocationBUS();
        private readonly StaffDTO staff;
        private readonly SupplierBUS supplierBUS = new SupplierBUS();
        private readonly int tabControlIndex;
        private readonly UserDTO user;
        private int cbIndexLoc;
        private int cbIndexTieuChiThuoc = 1;
        private FilterByRangeDialog filterByRangeDialog;
        public int indexTieuChiNCC = 1;
        private int rowSelectedTheLoai;
        private int rowSelectedThuoc;

        public QuanLyThuocGUI(UserDTO user, int tabControlIndex)
        {
            InitializeComponent();
            this.user = user;
            this.tabControlIndex = tabControlIndex;
            staff = new StaffDAL().GetByUsername(user.username);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            var tabIndex = tabControl1.SelectedIndex;
            switch (tabIndex)
            {
                case 0:
                    if (!staff.isManager)
                    {
                        CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
                        e.Cancel = true;
                    }

                    QuanLyThuoc_Load();
                    lbHeader.Text = Resources.Medicine_management;

                    break;
                case 1:
                    TheLoai_Load();
                    lbHeader.Text = Resources.Category_management;
                    break;
                case 2:
                    NhaCungCap_Load();
                    lbHeader.Text = Resources.Supplier_management;
                    break;
                case 3:
                    ViTriThuoc_Load();
                    lbHeader.Text = Resources.Medicine_location_management;
                    break;
            }
        }

        private void ViTriThuoc_Load()
        {
            var listViTriThuoc = medicineLocationBUS.LoadData();
            HienThiViTriThuoc(listViTriThuoc);
            cbTTViTri.SelectedIndex = 0;
            cbbTieuChiVT.SelectedIndex = 1;
        }

        private void HienThiViTriThuoc(List<MedicineLocationDTO> list)
        {
            dgvViTriThuoc.Rows.Clear();
            ClearViTriThuoc();
            BeginInvoke(new Action(() => { dgvViTriThuoc.ClearSelection(); }));

            for (var i = 0; i < list.Count; i++)
            {
                if (!list[i].deleted.Equals("")) continue;
                dgvViTriThuoc.Rows.Add(
                    i + 1,
                    list[i].id,
                    list[i].name,
                    list[i].note,
                    list[i].status ? Resources.Available : Resources.Unavailable,
                    list[i].created,
                    list[i].updated);
            }
        }

        private void ClearViTriThuoc()
        {
            tbTenViTri.Text = "";
            tbGhiChuViTri.Text = "";
        }

        private void QuanLyThuoc_Load()
        {
            try
            {
                BeginInvoke(new Action(() => { dgvThuoc.ClearSelection(); }));
                TimThuocTheoDuLieu();
                cbTLThuoc.Items.Clear();
                cbNccThuoc.Items.Clear();
                cbTieuChiThuoc.SelectedIndex = cbIndexTieuChiThuoc;
                cbLoai.Items.Clear();
                cbLoai.Items.Add(Resources.Prescription_drug);
                cbLoai.Items.Add(Resources.Unprescription_drug);
                var categoryList = categoryBUS.LoadData();
                foreach (var category in categoryList)
                {
                    if (!category.status || !category.deleted.Equals("")) continue;
                    cbTLThuoc.Items.Add(category.id + "-" + category.name);
                }

                cbTLThuoc.Items.Add(Resources.Add);

                var supplierList = supplierBUS.LoadData();
                foreach (var supplier in supplierList)
                {
                    if (!supplier.status || !supplier.deleted.Equals("")) continue;
                    cbNccThuoc.Items.Add(supplier.id + "-" + supplier.name);
                }

                cbNccThuoc.Items.Add(Resources.Add);

                var medicineLocationList = medicineLocationBUS.LoadData();
                foreach (var medicineLocation in medicineLocationList)
                {
                    if (!medicineLocation.status || !medicineLocation.deleted.Equals("")) continue;
                    cbVitri.Items.Add(medicineLocation.id + "-" + medicineLocation.name);
                }

                cbVitri.Items.Add(Resources.Add);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void QuanLyThuoc_Show(List<MedicineDTO> medicines)
        {
            var i = 0;
            dgvThuoc.Rows.Clear();

            foreach (var medicine in medicines)
            {
                if (!medicine.deleted.Equals("") || medicine.category == null || medicine.supplier == null ||
                    !medicine.supplier.status || !medicine.category.status) continue;

                dgvThuoc.Rows.Add(
                    ++i, medicine.id, medicine.name, medicine.quantity, medicine.price_out,
                    $"{medicine.category.id}-{medicine.category.name}",
                    medicine.type ? Resources.Prescription_drug : Resources.Unprescription_drug,
                    medicine.unit, medicine.mfgDate, medicine.expireDate,
                    $"{medicine.supplier.id}-{medicine.supplier.name}",
                    medicine.price_in,
                    $"{medicine.location.id}-{medicine.location.name}",
                    medicine.description,
                    medicine.created,
                    medicine.updated);
            }

            ClearInputThuoc();
            pictureBoxThuoc.ImageLocation = "";
            //dgvThuoc_CellClick(new object(), new DataGridViewCellEventArgs(0, rowSelectedThuoc));
        }

        public void ClearInputThuoc()
        {
            tbMaThuoc.Text = "";
            tbTenThuoc.Text = "";
            tbSL.Text = "";
            tbDVT.Text = "";
            tbGiaBan.Text = "";
            rtbMota.Text = "";
        }

        private void NhaCungCap_Load()
        {
            tbTimNCC_TextChanged(this, EventArgs.Empty);

            cbTTNCC.SelectedIndex = 0;
            cbTieuChiNCC.SelectedIndex = indexTieuChiNCC;
        }

        public void HienThiNCC(List<SupplierDTO> list)
        {
            var i = 0;
            dgvNhaCungCap.Rows.Clear();


            var supplierNodes = list;
            foreach (var s in supplierNodes)
            {
                if (!s.deleted.Equals("")) continue;
                var id = s.id;
                var name = s.name;
                var phone = s.phone;
                var email = s.email;
                var note = s.note;
                var status = s.status;
                var created = s.created;
                var updated = s.updated;

                dgvNhaCungCap.Rows.Add(
                    ++i, id, name, phone, email, note,
                    status ? Resources.Available : Resources.Unavailable,
                    created, updated);
            }

            ClearInputSupplier();
            BeginInvoke(new Action(() => { dgvNhaCungCap.ClearSelection(); }));
        }

        private void ClearInputSupplier()
        {
            tbMaNCC.Text = "";
            tbTenNCC.Text = "";
            tbDienThoai.Text = "";
            tbEmail.Text = "";
            tbGhiChuNCC.Text = "";
            cbTieuChiNCC.SelectedIndex = indexTieuChiNCC;
        }

        public void ClearInputCategory()
        {
            tbTenTheLoai.Text = "";
            tbGhiChuTheLoai.Text = "";
            cbTrangThaiTheLoai.SelectedIndex = 0;
        }

        public void TheLoai_Show(List<CategoryDTO> list)
        {
            var i = 0;
            dgvTheLoai.Rows.Clear();
            var categoryController = new CategoryBUS();
            var categoryList = list;
            foreach (var category in categoryList)
            {
                if (!category.deleted.Equals("")) continue;

                dgvTheLoai.Rows.Add(++i, category.id, category.name, category.note,
                    category.status ? Resources.Available : Resources.Unavailable, category.created, category.updated);
            }

            ClearInputCategory();
            BeginInvoke(new Action(() => { dgvTheLoai.ClearSelection(); }));
        }

        private void TheLoai_Load()
        {
            TimTheLoai();
            cbTrangThaiTheLoai.SelectedIndex = 0;
            cbTieuChiTheLoai.SelectedIndex = 1;
        }

        private void QuanLyThuocView_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControlIndex;
            QuanLyThuoc_Load();
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            try
            {
                var tenTheLoai = tbTenTheLoai.Text;
                var ghiChu = tbGhiChuTheLoai.Text;
                var trangThai = cbTrangThaiTheLoai.SelectedIndex == 0 ? true : false;

                if (tenTheLoai.Equals(""))
                {
                    ShowValidateError(tbTenTheLoai, Resources.Please_input_category_name);
                    return;
                }

                var category = new CategoryDTO(tenTheLoai, ghiChu, trangThai, CustomDateTime.GetNow(), null, null);
                var state = categoryBUS.Insert(category);

                if (state == Predefined.SUCCESS)
                {
                    tbTimTheLoai_TextChanged(sender, e);
                    return;
                }

                if (state == Predefined.ID_EXIST)
                    ShowValidateError(tbTenTheLoai, Resources.Category_name_already_exists);
                else
                    CustomMessageBox.ShowError(Resources.Add_failed);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void ShowValidateError(Control control, string message)
        {
            errorProvider1.SetError(control, message);
            toolTip1.SetToolTip(control, message);
            toolTip1.Show(message, control, 0, control.Height, 2000);
        }

        private void btnSuaTheLoai_Click(object sender, EventArgs e)
        {
            try
            {
                var maTheLoai = dgvTheLoai.SelectedRows[0].Cells[1].Value.ToString();
                var tenTheLoai = tbTenTheLoai.Text;
                var ghiChu = tbGhiChuTheLoai.Text;
                var trangThai = cbTrangThaiTheLoai.SelectedIndex == 0 ? true : false;
                var created = dgvTheLoai.SelectedRows[0].Cells[5].Value.ToString();
                if (maTheLoai.Equals(""))
                {
                    CustomMessageBox.ShowError(Resources.Please_select_the_category_you_want_to_edit);
                    return;
                }

                if (tenTheLoai.Equals(""))
                {
                    //CustomMessageBox.ShowError("Vui lòng nhập tên thể loại");
                    ShowValidateError(tbTenTheLoai, Resources.Please_input_category_name);
                    return;
                }

                var category = new CategoryDTO(maTheLoai, tenTheLoai, ghiChu, trangThai, created,
                    CustomDateTime.GetNow(), "");
                var state = categoryBUS.Update(category);

                if (state == Predefined.SUCCESS)
                {
                    tbTimTheLoai_TextChanged(sender, e);
                    return;
                }

                if (state == Predefined.ID_NOT_EXIST)
                    ShowValidateError(tbTenTheLoai, Resources.Category_ID_does_not_exist);
                else
                    CustomMessageBox.ShowError(Resources.Edit_failed);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbTenTheLoai.Text = dgvTheLoai.SelectedRows[0].Cells[2].Value.ToString();
                tbGhiChuTheLoai.Text = dgvTheLoai.SelectedRows[0].Cells[3].Value.ToString();
                cbTrangThaiTheLoai.SelectedIndex =
                    dgvTheLoai.SelectedRows[0].Cells[4].Value.ToString().Equals(Resources.Available) ? 0 : 1;
            }
            catch (Exception)
            {
                ClearInputCategory();
            }
        }

        private void btnXoaTheLoai_Click(object sender, EventArgs e)
        {
            try
            {
                var maTheLoai = dgvTheLoai.SelectedRows[0].Cells[1].Value.ToString();
                if (maTheLoai.Equals(""))
                {
                    CustomMessageBox.ShowError(Resources.Category_ID_does_not_valid);
                    return;
                }

                var state = categoryBUS.Delete(maTheLoai);
                if (state == Predefined.SUCCESS)
                {
                    tbTimTheLoai_TextChanged(sender, e);
                    return;
                }

                if (state == Predefined.ID_NOT_EXIST)
                    CustomMessageBox.ShowError(Resources.Category_ID_does_not_exist);
                else
                    CustomMessageBox.ShowError(Resources.Delete_failed);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnLuuTruTheLoai_Click(object sender, EventArgs e)
        {
            var deletedCategory = new DeletedCategoryDialog(categoryBUS);
            deletedCategory.refreshDeletedCategory = tbTimTheLoai_TextChanged; ;
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
                cbTTNCC.SelectedIndex = dgvNhaCungCap.Rows[index].Cells[6].Value.ToString().Equals(Resources.Available)
                    ? 0
                    : 1;
            }
            catch (Exception)
            {
                ClearInputSupplier();
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                var maNCC = tbMaNCC.Text;
                var tenNCC = tbTenNCC.Text;
                var dienThoai = tbDienThoai.Text;
                var email = tbEmail.Text;
                var ghiChu = tbGhiChuNCC.Text;
                var trangThai = cbTTNCC.SelectedIndex == 0 ? true : false;
                var isValidated = true;
                if (maNCC.Equals(""))
                {
                    ShowValidateError(tbMaNCC, Resources.Please_input_supplier_ID);
                    isValidated = false;
                }

                if (tenNCC.Equals(""))
                {
                    ShowValidateError(tbTenNCC, Resources.Please_input_supplier_name);
                    isValidated = false;
                }

                if (!email.Equals("") && !email.Contains("@"))
                {
                    ShowValidateError(tbEmail, Resources.Invalid_email);
                    isValidated = false;
                }

                if (!dienThoai.Equals("") && !int.TryParse(dienThoai, out var dt))
                {
                    ShowValidateError(tbDienThoai, Resources.Invalid_phone_number);
                    isValidated = false;
                }

                if (!isValidated) return;

                var newSupplierDTO = new SupplierDTO(maNCC, tenNCC, dienThoai, email, ghiChu, trangThai,
                    CustomDateTime.GetNow(), "", "");

                var result = supplierBUS.Insert(newSupplierDTO);
                if (result == Predefined.ID_EXIST)
                {
                    ShowValidateError(tbMaNCC, Resources.Supplier_ID_already_exists);
                    return;
                }

                if (result == Predefined.ERROR)
                {
                    CustomMessageBox.ShowError(Resources.This_provider_cannot_be_added);
                    return;
                }

                tbTimNCC_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                var maNCC = dgvNhaCungCap.SelectedRows[0].Cells[1].Value.ToString().Trim();
                var tenNCC = tbTenNCC.Text.Trim();
                var dienThoai = tbDienThoai.Text;
                var email = tbEmail.Text;
                var ghiChu = tbGhiChuNCC.Text.Trim();
                var trangThai = cbTTNCC.SelectedIndex == 0 ? true : false;
                var isValidated = true;

                if (maNCC.Equals(""))
                {
                    CustomMessageBox.ShowError(Resources.Please_select_the_supplier_you_want_to_edit);
                    return;
                }

                if (tenNCC.Equals(""))
                {
                    ShowValidateError(tbTenNCC, Resources.Please_input_supplier_name);
                    isValidated = false;
                }

                if (!email.Equals("") && !email.Contains("@"))
                {
                    ShowValidateError(tbEmail, Resources.Invalid_email);
                    isValidated = false;
                }

                if (!dienThoai.Equals("") && !int.TryParse(dienThoai, out var dt))
                {
                    ShowValidateError(tbDienThoai, Resources.Invalid_phone_number);
                    isValidated = false;
                }

                if (!isValidated) return;

                var supplierDTO = new SupplierDTO(maNCC, tenNCC, dienThoai, email, ghiChu, trangThai, "",
                    CustomDateTime.GetNow(), "");

                var result = supplierBUS.Update(supplierDTO);
                if (result == Predefined.ID_NOT_EXIST)
                {
                    ShowValidateError(tbMaNCC, Resources.Supplier_ID_is_not_exist);
                }
                else if (result == Predefined.ERROR)
                {
                    CustomMessageBox.ShowError(Resources.Cannot_edit_this_supplier);
                    return;
                }

                tbTimNCC_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                var maNCC = dgvNhaCungCap.SelectedRows[0].Cells[1].Value.ToString();
                if (maNCC.Equals(""))
                {
                    CustomMessageBox.ShowError(Resources.Please_select_the_supplier_you_want_to_delete_);
                    return;
                }

                //var choice = CustomMessageBox.ShowQuestion(Resources.Are_you_sure_you_want_to_remove_this_supplier_);
                //if (choice == DialogResult.No) return;

                var result = supplierBUS.Delete(maNCC);
                if (result == Predefined.ID_NOT_EXIST)
                {
                    ShowValidateError(tbMaNCC, Resources.Supplier_ID_is_not_exist);
                }
                tbTimNCC_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Xoá thất bại: " + ex.Message);
            }
        }

        private void tbTimNCC_TextChanged(object sender, EventArgs e)
        {
            var noidungtimkiem = tbTimNCC.Text.ToLower().Trim();
            if (noidungtimkiem.Equals(""))
            {
                HienThiNCC(supplierBUS.LoadData());
                return;
            }

            var tieuChiIndex = cbTieuChiNCC.SelectedIndex;
            dgvNhaCungCap.Rows.Clear();
            var supplierList = supplierBUS.LoadData().Where(supplier =>
            {
                switch (tieuChiIndex)
                {
                    case 0:
                        return supplier.id.ToLower().Contains(noidungtimkiem);
                    case 1:
                        return supplier.name.ToLower().Contains(noidungtimkiem);
                    case 2:
                        return supplier.phone.ToLower().Contains(noidungtimkiem);
                    case 3:
                        return supplier.email.ToLower().Contains(noidungtimkiem);

                    case 4:
                        return supplier.note.ToLower().Contains(noidungtimkiem);
                    case 5:
                        return (supplier.status ? Resources.Available : Resources.Unavailable).ToLower()
                            .Contains(noidungtimkiem);
                    case 6:
                        return supplier.created.ToLower().Contains(noidungtimkiem);
                    case 7:
                        return supplier.updated.ToLower().Contains(noidungtimkiem);
                    default:
                        return false;
                }
            }).ToList();
            HienThiNCC(supplierList);
        }

        public void TimTheLoai()
        {
            try
            {
                if (tbTimTheLoai.Text.Equals(""))
                {
                    var index = cbTieuChiTheLoai.SelectedIndex;
                    TheLoai_Show(categoryBUS.LoadData());
                    cbTieuChiTheLoai.SelectedIndex = index;
                    return;
                }

                var noidungtimkiem = tbTimTheLoai.Text.ToLower().Trim();
                var tieuChiIndex = cbTieuChiTheLoai.SelectedIndex;
                dgvTheLoai.Rows.Clear();
                var categoryList = categoryBUS.LoadData().Where(category =>
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
                            return (category.status ? Resources.Available : Resources.Unavailable).ToLower()
                                .Contains(noidungtimkiem);
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
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
                var index = dgvThuoc.SelectedRows[0].Index;
                rowSelectedThuoc = index;
                tbMaThuoc.Text = dgvThuoc.Rows[index].Cells[1].Value.ToString();
                tbTenThuoc.Text = dgvThuoc.Rows[index].Cells[2].Value.ToString();

                tbSL.Text = dgvThuoc.Rows[index].Cells[3].Value.ToString();
                tbGiaBan.Text = dgvThuoc.Rows[index].Cells[4].Value.ToString();
                tbGiaNhap.Text = dgvThuoc.Rows[index].Cells[11].Value.ToString();
                var theLoai = dgvThuoc.Rows[index].Cells[5].Value.ToString();
                for (var i = 0; i < cbTLThuoc.Items.Count; i++)
                    if (cbTLThuoc.Items[i].ToString().Equals(theLoai))
                    {
                        cbTLThuoc.SelectedIndex = i;
                        break;
                    }

                var viTri = dgvThuoc.Rows[index].Cells[12].Value.ToString();
                for (var i = 0; i < cbVitri.Items.Count; i++)
                    if (cbVitri.Items[i].ToString().Equals(viTri))
                    {
                        cbVitri.SelectedIndex = i;
                        break;
                    }

                var loai = dgvThuoc.Rows[index].Cells[6].Value.ToString();
                for (var i = 0; i < cbLoai.Items.Count; i++)
                    if (cbLoai.Items[i].ToString().Equals(loai))
                    {
                        cbLoai.SelectedIndex = i;
                        break;
                    }

                var image = medicineBUS.LoadData().FirstOrDefault(item => item.id.Equals(tbMaThuoc.Text))
                    ?.image;
                //pictureBoxThuoc.ImageLocation =
                //    image.Equals("") ? "" : Path.Combine(Config.getImagePath(), $"{tbMaThuoc.Text}.jpg");

                pictureBoxThuoc.ImageLocation =
                    image.Equals("") ? "" : image;
                dtpkMFG.Value = DateTime.Parse(dgvThuoc.Rows[index].Cells[8].Value.ToString());
                dtpkEXP.Value = DateTime.Parse(dgvThuoc.Rows[index].Cells[9].Value.ToString());


                rtbMota.Text = dgvThuoc.Rows[index].Cells[13].Value.ToString();
                tbDVT.Text = dgvThuoc.Rows[index].Cells[7].Value.ToString();
                var nhaCungCap = dgvThuoc.Rows[index].Cells[10].Value.ToString();

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
            try
            {
                var id = tbMaThuoc.Text;
                var name = tbTenThuoc.Text;
                var quantityText = tbSL.Text;
                var priceOutText = tbGiaBan.Text;
                var unit = tbDVT.Text;
                var mfgDate = dtpkMFG.Value.ToString("dd/MM/yyyy");
                var expireDate = dtpkEXP.Value.ToString("dd/MM/yyyy");

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(unit) ||
                    string.IsNullOrEmpty(quantityText) || string.IsNullOrEmpty(priceOutText))
                {
                    CustomMessageBox.ShowWarning(Resources.Please_enter_complete_info);
                    return;
                }


                if (!int.TryParse(quantityText, out var quantity))
                {
                    CustomMessageBox.ShowWarning(Resources.Quantity_must_be_a_number);
                    return;
                }

                if (!double.TryParse(priceOutText, out var priceOut))
                {
                    CustomMessageBox.ShowWarning(Resources.Price_must_be_a_number);
                    return;
                }

                if (quantity < 0)
                {
                    CustomMessageBox.ShowWarning(Resources.Quantity_must_be_greater_or_equal_0);
                    return;
                }

                if (priceOut < 0)
                {
                    CustomMessageBox.ShowWarning(Resources.Price_must_be_greater_or_equal_0);
                    return;
                }

                var tlIndex = cbTLThuoc.SelectedIndex;
                var nccIndex = cbNccThuoc.SelectedIndex;
                var vttIndex = cbVitri.SelectedIndex;
                if (tlIndex == -1)
                {
                    CustomMessageBox.ShowWarning(Resources.Please_select_a_category);
                    return;
                }

                if (nccIndex == -1)
                {
                    CustomMessageBox.ShowWarning(Resources.Please_select_a_supplier);
                    return;
                }
                if (vttIndex == -1)
                {
                    CustomMessageBox.ShowWarning(Resources.Please_choose_a_medicine_location);
                    return;
                }

                var tl = cbTLThuoc.Items[tlIndex].ToString();
                var ncc = cbNccThuoc.Items[nccIndex].ToString();
                var vtt = cbVitri.Items[vttIndex].ToString();

                var tlArr = tl.Split('-');
                var nccArr = ncc.Split('-');
                var vttArr = vtt.Split('-');
                var priceIn = double.Parse(tbGiaNhap.Text);
                var description = rtbMota.Text;

                var type = cbLoai.SelectedIndex == 0;

                var image = "";

                var supplier = supplierBUS.LoadData().FirstOrDefault(s => s.id.Equals(nccArr[0]));
                var category = categoryBUS.LoadData().FirstOrDefault(c => c.id.Equals(tlArr[0]));
                var location = medicineLocationBUS.LoadData().FirstOrDefault(l => l.id.Equals(vttArr[0]));
                var newMedicine = new MedicineDTO(id, name, quantity, priceOut, category, type, unit, mfgDate, expireDate, supplier, priceIn, location, description,
                    CustomDateTime.GetNow(), "", "", image);


                var result = medicineBUS.Insert(newMedicine);


                if (result == Predefined.SUCCESS)
                {
                    QuanLyThuoc_Load();
                    CustomMessageBox.ShowSuccess(Resources.Added_medicine_information_successfully);
                    return;
                }

                if (result == Predefined.ID_EXIST)
                    CustomMessageBox.ShowError(Resources.Medicine_ID_already_exist);
                else
                    CustomMessageBox.ShowError(Resources.Cannot_added_this_medicine);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnSuaThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                var id = tbMaThuoc.Text;
                var name = tbTenThuoc.Text;
                var quantityText = tbSL.Text;
                var priceOutText = tbGiaBan.Text;
                var categoryId = cbTLThuoc.SelectedItem.ToString().Split('-')[0];
                var type = cbLoai.SelectedIndex == 0;
                var unit = tbDVT.Text;
                var mfgDate = dtpkMFG.Value.ToString("dd/MM/yyyy");
                var expireDate = dtpkEXP.Value.ToString("dd/MM/yyyy");
                var supplierId = cbNccThuoc.SelectedItem.ToString().Split('-')[0];
                var priceIn = double.Parse(tbGiaNhap.Text);
                var locationId = cbVitri.SelectedItem.ToString().Split('-')[0];
                var description = rtbMota.Text;
                var created = medicineBUS.LoadData().FirstOrDefault(item => item.id.Equals(id))?.created;
                var updated = CustomDateTime.GetNow();
                var image = medicineBUS.LoadData().FirstOrDefault(item => item.id.Equals(id))?.image;

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(unit) ||
                    string.IsNullOrEmpty(quantityText) || string.IsNullOrEmpty(priceOutText))
                {
                    CustomMessageBox.ShowWarning(Resources.Please_enter_complete_info);
                    return;
                }


                if (!int.TryParse(quantityText, out var quantity))
                {
                    CustomMessageBox.ShowWarning(Resources.Quantity_must_be_a_number);
                    return;
                }

                if (!double.TryParse(priceOutText, out var priceOut))
                {
                    CustomMessageBox.ShowWarning(Resources.Price_must_be_a_number);
                    return;
                }

                if (quantity < 0)
                {
                    CustomMessageBox.ShowWarning(Resources.Quantity_must_be_greater_or_equal_0);
                    return;
                }

                if (priceOut < 0)
                {
                    CustomMessageBox.ShowWarning(Resources.Price_must_be_greater_or_equal_0);
                    return;
                }

                var tlIndex = cbTLThuoc.SelectedIndex;
                var nccIndex = cbNccThuoc.SelectedIndex;
                var vttIndex = cbVitri.SelectedIndex;
                if (tlIndex == -1)
                {
                    CustomMessageBox.ShowWarning(Resources.Please_select_a_category);
                    return;
                }

                if (nccIndex == -1)
                {
                    CustomMessageBox.ShowWarning(Resources.Please_select_a_supplier);
                    return;
                }
                if (vttIndex == -1)
                {
                    CustomMessageBox.ShowWarning(Resources.Please_choose_a_medicine_location);
                    return;
                }

                var supplier = supplierBUS.LoadData().FirstOrDefault(s => s.id.Equals(supplierId));
                var category = categoryBUS.LoadData().FirstOrDefault(c => c.id.Equals(categoryId));
                var location = medicineLocationBUS.LoadData().FirstOrDefault(l => l.id.Equals(locationId));

                var medicine = new MedicineDTO(id, name, quantity, priceOut, category, type, unit, mfgDate, expireDate, supplier, priceIn, location, description,
                    created, updated, "", image);

                var result = medicineBUS.Update(medicine);
                if (result == Predefined.SUCCESS)
                {
                    QuanLyThuoc_Load();
                    CustomMessageBox.ShowSuccess(Resources.Successfully_edited_medicine_information);
                    return;
                }

                if (result == Predefined.ERROR) MessageBox.Show(Resources.Edit_failed);
            }
            catch (NullReferenceException)
            {
                CustomMessageBox.ShowError(Resources.Invalid_Medicine_ID);
            }
        }

        private void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                var maThuoc = dgvThuoc.SelectedRows[0].Cells[1].Value.ToString();
                if (maThuoc.Equals(""))
                {
                    CustomMessageBox.ShowError(Resources.Category_ID_does_not_valid);
                    return;
                }

                var state = medicineBUS.Delete(maThuoc);
                if (state == Predefined.SUCCESS)
                {
                    if (rowSelectedThuoc != 0) rowSelectedThuoc--;
                    QuanLyThuoc_Load();

                    return;
                }

                if (state == Predefined.ID_NOT_EXIST)
                    CustomMessageBox.ShowError(Resources.Category_ID_does_not_exist);
                else
                    CustomMessageBox.ShowError(Resources.Delete_failed);
            }
            catch (Exception)
            {
                CustomMessageBox.ShowError(Resources.Category_ID_does_not_valid);
            }
        }

        private void btnLuuThuoc_Click(object sender, EventArgs e)
        {
            var deletedMedicine = new DeletedMedicineDialog(medicineBUS);
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
                QuanLyThuoc_Show(list == null ? medicineBUS.LoadData() : list);
                return;
            }

            var tieuChiIndex = cbTieuChiThuoc.SelectedIndex;
            dgvThuoc.Rows.Clear();
            var medicineList = list != null ? list : medicineBUS.LoadData();
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
                        return medicine.price_out.ToString().ToLower().Contains(noidungtimkiem);
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
                CustomMessageBox.ShowError(Resources.Please_select_a_valid_medicine);
                return;
            }

            var result = medicineBUS.ChangeImage(medicineId);

            if (result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess(Resources.Change_image_successfully);
                QuanLyThuoc_Load();
                return;
            }

            if (result == Predefined.ID_NOT_EXIST)
                CustomMessageBox.ShowWarning(Resources.Medicine_ID_is_not_exist);
            else
                CustomMessageBox.ShowError(Resources.Cannot_save_this_image);
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            var medicineId = tbMaThuoc.Text;
            if (medicineId.Equals(""))
            {
                CustomMessageBox.ShowError(Resources.Please_select_a_valid_medicine);
                return;
            }

            var confirmResult = CustomMessageBox.ShowQuestion(Resources.Do_you_want_to_delete_this_image);
            if (confirmResult == DialogResult.No) return;

            var result = medicineBUS.RemoveImage(medicineId);

            if (result == Predefined.SUCCESS)
            {
                QuanLyThuoc_Load();
                return;
            }

            if (result == Predefined.ID_NOT_EXIST)
                CustomMessageBox.ShowWarning(Resources.Medicine_ID_is_not_exist);
            else
                CustomMessageBox.ShowError(Resources.Cannot_save_this_image);
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
                    filterByRangeDialog = new FilterByRangeDialog(medicineBUS);

                    cbLocDuLieuThuoc.Enabled = false;
                    filterByRangeDialog.onClick += TimThuoc;
                    filterByRangeDialog.Disposed += (_sender, _args) => { FilterByRangeDialog_Disposed(); };
                    filterByRangeDialog.FormClosing += (_sender, _args) => { FilterByRangeDialog_Disposed(); };
                }

                filterByRangeDialog.Show();
                filterByRangeDialog.btnFilter.PerformClick();
                return;
            }

            var list = medicineBUS.LoadData().Where(medicine =>
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

        private void tbTenTheLoai_TextChanged(object sender, EventArgs e)
        {
            ShowValidateError(tbTenTheLoai, "");
        }

        private void tbMaNCC_TextChanged(object sender, EventArgs e)
        {
            ShowValidateError((Control)sender, "");
        }

        private void cbTLThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex == comboBox.Items.Count - 1) comboBox.SelectedIndex = -1;
        }

        private void dgvViTriThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var index = dgvViTriThuoc.SelectedRows[0].Index;
                tbTenViTri.Text = dgvViTriThuoc.Rows[index].Cells[2].Value.ToString();
                tbGhiChuViTri.Text = dgvViTriThuoc.Rows[index].Cells[3].Value.ToString();
                cbTTViTri.SelectedIndex =
                    dgvViTriThuoc.Rows[index].Cells[4].Value.ToString().Equals(Resources.Available) ? 0 : 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ClearViTriThuoc();
            }
        }

        private void btnThemVT_Click(object sender, EventArgs e)
        {
            try
            {
                var tenViTri = tbTenViTri.Text;
                var ghiChu = tbGhiChuViTri.Text;
                var trangThai = cbTTViTri.SelectedIndex == 0 ? true : false;

                if (tenViTri.Equals(""))
                {
                    ShowValidateError(tbTenViTri, Resources.Please_input_location_name);
                    return;
                }

                var medicineLocation =
                    new MedicineLocationDTO(tenViTri, ghiChu, trangThai, CustomDateTime.GetNow(), null, null);
                var state = medicineLocationBUS.Insert(medicineLocation);

                if (state == Predefined.SUCCESS)
                {
                    tbTimViTri_TextChanged(sender, e);
                    return;
                }

                if (state == Predefined.ID_EXIST)
                    ShowValidateError(tbTenViTri, Resources.Location_name_already_exists);
                else
                    CustomMessageBox.ShowError(Resources.Add_failed);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void tbTenViTri_TextChanged(object sender, EventArgs e)
        {
            ShowValidateError(tbTenViTri, "");
        }

        private void btnSuaVT_Click(object sender, EventArgs e)
        {
            try
            {
                var maViTri = dgvViTriThuoc.SelectedRows[0].Cells[1].Value.ToString();
                var tenViTri = tbTenViTri.Text;
                var ghiChu = tbGhiChuViTri.Text;
                var trangThai = cbTTViTri.SelectedIndex == 0 ? true : false;

                if (tenViTri.Equals(""))
                {
                    ShowValidateError(tbTenViTri, Resources.Please_input_location_name);
                    return;
                }

                var medicineLocation =
                    new MedicineLocationDTO(tenViTri, ghiChu, trangThai, null, CustomDateTime.GetNow(), null, maViTri);
                var state = medicineLocationBUS.Update(medicineLocation);

                if (state == Predefined.SUCCESS)
                {
                    tbTimViTri_TextChanged(sender, e);
                    return;
                }

                if (state == Predefined.ID_EXIST)
                    ShowValidateError(tbTenViTri, Resources.Location_name_already_exists);
                else
                    CustomMessageBox.ShowError(Resources.Add_failed);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnXoaVT_Click(object sender, EventArgs e)
        {
            try
            {
                var maViTri = dgvViTriThuoc.SelectedRows[0].Cells[1].Value.ToString();
                var state = medicineLocationBUS.Delete(maViTri);

                if (state == Predefined.SUCCESS) tbTimViTri_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void tbTimViTri_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var searchValue = tbTimViTri.Text.ToLower().Trim();
                var list = medicineLocationBUS.LoadData();
                if (searchValue.Equals(""))
                {
                    HienThiViTriThuoc(list);
                    return;
                }

                var criteriaIndex = cbbTieuChiVT.SelectedIndex;
                switch (criteriaIndex)
                {
                    case 0:
                        list = list.Where(item => item.id.ToLower().Contains(searchValue)).ToList();
                        break;
                    case 1:
                        list = list.Where(item => item.name.ToLower().Contains(searchValue)).ToList();
                        break;
                    case 2:
                        list = list.Where(item => item.note.ToLower().Contains(searchValue)).ToList();
                        break;
                    case 3:
                        list = list.Where(item =>
                                (item.status ? Resources.Available : Resources.Unavailable).ToLower()
                                .Contains(searchValue))
                            .ToList();
                        break;
                    case 4:
                        list = list.Where(item => item.created.ToLower().Contains(searchValue)).ToList();
                        break;
                    case 5:
                        list = list.Where(item => item.updated.ToLower().Contains(searchValue)).ToList();
                        break;
                }

                HienThiViTriThuoc(list);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void cbbTieuChiVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbTimViTri_TextChanged(sender, e);
        }

        private void StripedTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
                e.CellStyle.BackColor = Color.LightGray;
            else
                e.CellStyle.BackColor = Color.White;
        }

        private void btnDeletedLocation_Click(object sender, EventArgs e)
        {
            var deletedMedicineLocation = new DeletedMedicineLocationDialog(tbTimViTri_TextChanged);
            deletedMedicineLocation.ShowDialog();
        }

        private void btnDeletedSupplier_Click(object sender, EventArgs e)
        {
            var deletedSupplier = new DeletedSupplierDialog(tbTimNCC_TextChanged);
            deletedSupplier.ShowDialog();
        }

        private void btnTh(object sender, EventArgs e)
        {

        }
    }
}