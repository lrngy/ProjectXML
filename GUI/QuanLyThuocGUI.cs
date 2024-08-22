using System;
using System.Collections.Generic;

namespace QPharma.GUI;

public partial class QuanLyThuocGUI : BaseForm
{
    private readonly CategoryBUS categoryBUS = new();
    private readonly MedicineBUS medicineBUS = new();
    private readonly MedicineLocationBUS medicineLocationBUS = new();
    private readonly StaffDTO staff;
    private readonly SupplierBUS supplierBUS = new();
    private readonly int tabControlIndex;
    private readonly UserDTO user;
    private readonly BillBUS billBUS = new();
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
        staff = StaffDAL.GetByUsername(user.username);
    }

    private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
    {
        var tabIndex = tabControl1.SelectedIndex;
        switch (tabIndex)
        {
            case 0:

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
            case 4:
                RefreshBill();
                break;
            case 5:
                LoadThongKe();
                break;
        }
    }



    private void RefreshBill()
    {
        var sender = new object();
        var e = new EventArgs();
        if (isSearching)
        {
            btnTimKiemHoaDon_Click(sender, e);
        }
        else
        {
            HoaDon_Load();
        }
    }

    private int cbbPageSizeIndex = 0;
    private bool isOldDataHoaDon = false;
    private int totalPage = 0;
    private int numRecord = 0;
    private int oldNumRecord = 0;
    private void HoaDon_Load()
    {
        flowLayoutTimKiem.Visible = false;


        cbbPageSize.SelectedIndex = cbbPageSizeIndex;
        var dateList = billBUS.GetDateList().ToArray();
        var priceList = billBUS.GetPriceList().ToArray();
        var staffList = billBUS.GetStaffList().ToArray();
        cbbTuNgay.Items.Clear();
        cbbDenNgay.Items.Clear();
        cbbGiaTriTu.Items.Clear();
        cbbGiaTriDen.Items.Clear();
        cbbNhanVien.Items.Clear();


        cbbTuNgay.Items.AddRange(dateList);
        cbbDenNgay.Items.AddRange(dateList);
        cbbGiaTriTu.Items.AddRange(priceList);
        cbbGiaTriDen.Items.AddRange(priceList);
        cbbNhanVien.Items.AddRange(staffList);

        var pageSize = int.Parse(cbbPageSize.Text);
        var currentPage = int.Parse(numCurrentPage.Text);
        var result = billBUS.LoadData(pageSize, currentPage);
        totalPage = result.totalPage;
        numRecord = result.numRecord;
        lbTotalPage.Text = "/" + totalPage;
        var numCurrentPageInt = int.Parse(numCurrentPage.Text);
        if (numCurrentPageInt > totalPage || numCurrentPage.Minimum == 0)
        {
            currentPage = 1;
        }

        if (totalPage > 0)
        {
            numCurrentPage.Minimum = 1;
        }
        numCurrentPage.Maximum = totalPage;
        if (oldNumRecord != numRecord)
        {
            isOldDataHoaDon = false;
        }
        if (isOldDataHoaDon)
        {
            return;
        }
        oldNumRecord = numRecord;
        isOldDataHoaDon = true;
        HienThiHoaDon(result.listBills);
    }

    private void HienThiHoaDon(List<BillDTO> list)
    {
        dgvHoaDon.Rows.Clear();
        ckbSelectAll.Checked = false;
        BeginInvoke(() => { dgvHoaDon.ClearSelection(); });

        lbSoDong.Text = $"hoá đơn (tổng cộng {numRecord} hoá đơn)";
        for (var i = 0; i < list.Count; i++)
        {
            if (!list[i].Deleted.Equals("")) continue;

            dgvHoaDon.Rows.Add(
                false,
                list[i].Id,
                list[i].Status ? Resources.Paid : Resources.Awaiting_payment,
                list[i].Created,
                list[i].Customer?.Name,
                Currency.FormatCurrency(list[i].Total.ToString()),
                list[i].Staff?.name
            );

            if (list[i].Status)
            {
                dgvHoaDon.Rows[dgvHoaDon.RowCount - 1].Cells[2].Style.BackColor = Color.LightGreen;
            }
            else
            {
                dgvHoaDon.Rows[dgvHoaDon.RowCount - 1].Cells[2].Style.BackColor = Color.BurlyWood;
            }
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
        BeginInvoke(() => { dgvViTriThuoc.ClearSelection(); });

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
            BeginInvoke(() => { dgvThuoc.ClearSelection(); });
            TimThuocTheoDuLieu();
            cbLoai.Items.Clear();
            cbLoai.Items.Add(Resources.Prescription_drug);
            cbLoai.Items.Add(Resources.Unprescription_drug);
            cbTieuChiThuoc.SelectedIndex = cbIndexTieuChiThuoc;

            cbTLThuoc.Items.Clear();
            cbTLThuoc.Items.Add(Resources.Unknown);


            var categoryList = categoryBUS.LoadData();
            foreach (var category in categoryList)
            {
                if (!category.deleted.Equals("")) continue;
                cbTLThuoc.Items.Add(category.id + "-" + category.name);
            }

            cbTLThuoc.Items.Add(Resources.Add);

            cbNccThuoc.Items.Clear();
            cbNccThuoc.Items.Add(Resources.Unknown);

            var supplierList = supplierBUS.LoadData();
            foreach (var supplier in supplierList)
            {
                if (!supplier.deleted.Equals("")) continue;
                cbNccThuoc.Items.Add(supplier.id + "-" + supplier.name);
            }

            cbNccThuoc.Items.Add(Resources.Add);

            cbVitri.Items.Clear();
            cbVitri.Items.Add(Resources.Unknown);

            var medicineLocationList = medicineLocationBUS.LoadData();
            foreach (var medicineLocation in medicineLocationList)
            {
                if (!medicineLocation.deleted.Equals("")) continue;
                cbVitri.Items.Add(medicineLocation.id + "-" + medicineLocation.name);
            }

            cbVitri.Items.Add(Resources.Add);


            cbTLThuoc.SelectedIndex = 0;
            cbNccThuoc.SelectedIndex = 0;
            cbVitri.SelectedIndex = 0;
            cbLoai.SelectedIndex = 0;
            dtpkMFG.Value = DateTime.Now;
            dtpkEXP.Value = DateTime.Now;
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
            if (!medicine.deleted.Equals("")) continue;

            dgvThuoc.Rows.Add(
                ++i, medicine.id, medicine.name, medicine.quantity, medicine.price_out,
               medicine.category == null ? Resources.Unknown : $"{medicine.category.id}-{medicine.category.name}",
                medicine.type ? Resources.Prescription_drug : Resources.Unprescription_drug,
                medicine.unit, medicine.mfgDate, medicine.expDate,
                medicine.supplier == null ? Resources.Unknown : $"{medicine.supplier.id}-{medicine.supplier.name}",
                medicine.price_in,
                medicine.location == null ? Resources.Unknown : $"{medicine.location.id}-{medicine.location.name}",
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
        numSL.Text = "";
        tbDVT.Text = "";
        numGiaBan.Text = "";
        numGiaNhap.Text = "";
        rtbMota.Text = "";
        ShowValidateError(numSL, "");
        ShowValidateError(numGiaBan, "");
        ShowValidateError(numGiaNhap, "");

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
        BeginInvoke(() => { dgvNhaCungCap.ClearSelection(); });
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
        BeginInvoke(() => { dgvTheLoai.ClearSelection(); });
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
                CustomMessageBox.ShowSuccess(Resources.Add_category_successfully);
                return;
            }

            if (state == Predefined.ID_EXIST)
                ShowValidateError(tbTenTheLoai, Resources.Category_name_already_exists);
            else if (state == Predefined.ID_EXIST_IN_ARCHIVE)
                ShowValidateError(tbTenTheLoai, Resources.Category_name_already_exists_in_archive);
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
                CustomMessageBox.ShowSuccess(Resources.Edit_Category_Successfully);
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
        var deletedCategory = new DeletedCategoryDialog(categoryBUS);
        deletedCategory.refreshDeletedCategory = tbTimTheLoai_TextChanged;
        ;
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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

            if (result == Predefined.ID_EXIST_IN_ARCHIVE)
            {
                ShowValidateError(tbMaNCC, Resources.Supplier_ID_already_exists_in_archive);
                return;
            }

            if (result == Predefined.ERROR)
            {
                CustomMessageBox.ShowError(Resources.This_provider_cannot_be_added);
                return;
            }

            CustomMessageBox.ShowSuccess(Resources.Add_supplier_successfully);
            tbTimNCC_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void btnSuaNCC_Click(object sender, EventArgs e)
    {
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
            CustomMessageBox.ShowSuccess(Resources.Edit_supplier_sucessfully);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void btnXoaNCC_Click(object sender, EventArgs e)
    {
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
            if (result == Predefined.ID_NOT_EXIST) ShowValidateError(tbMaNCC, Resources.Supplier_ID_is_not_exist);
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

            numSL.Text = dgvThuoc.Rows[index].Cells[3].Value.ToString();
            numGiaBan.Text = dgvThuoc.Rows[index].Cells[4].Value.ToString();
            numGiaNhap.Text = dgvThuoc.Rows[index].Cells[11].Value.ToString();
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
                ?.imagePath;
            //pictureBoxThuoc.ImageLocation =
            //    image.Equals("") ? "" : Path.Combine(Config.getImagePath(), $"{tbMaThuoc.Text}.jpg");

            pictureBoxThuoc.ImageLocation =
                image.Equals("") ? "" : image;
            dtpkMFG.Value = DateTime.ParseExact(dgvThuoc.Rows[index].Cells[8].Value.ToString(), "dd/MM/yyyy", null);
            dtpkEXP.Value = DateTime.ParseExact(dgvThuoc.Rows[index].Cells[9].Value.ToString(), "dd/MM/yyyy", null);


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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
        try
        {
            var id = tbMaThuoc.Text;
            var name = tbTenThuoc.Text;
            var quantityText = numSL.Text;
            var priceOutText = numGiaBan.Text;
            var priceInText = numGiaNhap.Text;
            var unit = tbDVT.Text;
            var mfgDate = dtpkMFG.Value.ToString();
            var expireDate = dtpkEXP.Value.ToString();

            bool isValid = true;
            bool CheckEmpty()
            {
                if (string.IsNullOrEmpty(id))
                {
                    ShowValidateError(tbMaThuoc, Resources.Please_input_medicine_id);
                    isValid = false;

                }
                if (string.IsNullOrEmpty(name))
                {
                    ShowValidateError(tbTenThuoc, Resources.Please_input_medicine_name);
                    isValid = false;
                }
                if (string.IsNullOrEmpty(unit))
                {
                    ShowValidateError(tbDVT, Resources.Please_input_medicine_unit);
                    isValid = false;
                }
                if (string.IsNullOrEmpty(quantityText))
                {
                    ShowValidateError(numSL, Resources.Please_input_medicine_quantity);
                    isValid = false;
                }
                if (string.IsNullOrEmpty(priceInText))
                {
                    ShowValidateError(numGiaNhap, Resources.Please_input_medicine_price_out);
                    isValid = false;
                }
                if (string.IsNullOrEmpty(priceOutText))
                {
                    ShowValidateError(numGiaBan, Resources.Please_input_medicine_price_out);
                    isValid = false;
                }

                return isValid;
            }


            int quantity = -1;
            decimal priceIn = -1, priceOut = -1;


            bool CheckValidNumber()
            {
                if (!int.TryParse(quantityText, out quantity))
                {

                    ShowValidateError(numSL, Resources.Quantity_must_be_a_number);
                    isValid = false;
                }
                if (!decimal.TryParse(priceInText, out priceIn))
                {

                    ShowValidateError(numGiaNhap, Resources.Price_must_be_a_number);
                    isValid = false;
                }

                if (!decimal.TryParse(priceOutText, out priceOut))
                {

                    ShowValidateError(numGiaBan, Resources.Price_must_be_a_number);
                    isValid = false;
                }
                return isValid;
            };

            bool CheckNumberValue()
            {
                if (quantity < 0)
                {
                    ShowValidateError(numSL, Resources.Quantity_must_be_greater_or_equal_0);
                    isValid = false;
                }

                if (priceOut < 0)
                {
                    ShowValidateError(numGiaBan, Resources.Price_must_be_greater_or_equal_0);
                    isValid = false;
                }

                if (priceIn < 0)
                {
                    ShowValidateError(numGiaNhap, Resources.Price_must_be_greater_or_equal_0);
                    isValid = false;
                }

                if (priceOut < priceIn)
                {
                    ShowValidateError(numGiaBan, "Giá bán phải lớn hơn hoặc bằng giá nhập");
                    isValid = false;
                }
                return isValid;
            }

            bool CheckLength()
            {
                if (tbMaThuoc.Text.Length > 30)
                {
                    ShowValidateError(tbMaThuoc, "Mã thuốc không vượt quá 30 kí tự");
                    isValid = false;
                }

                if (numSL.Text.Length > 9)
                {
                    ShowValidateError(numSL, "Số lượng không thể vượt quá 999999999");
                    isValid = false;
                }

                if (numGiaBan.Text.Length > 9)
                {
                    ShowValidateError(numGiaBan, "Giá bán không thể vượt quá 999999999");
                    isValid = false;
                }

                if (numGiaNhap.Text.Length > 9)
                {
                    ShowValidateError(numGiaNhap, "Giá nhập không thể vượt quá 999999999");
                    isValid = false;
                }

                if (tbDVT.Text.Length > 30)
                {
                    ShowValidateError(tbDVT, "Đơn vị tính không quá 30 kí tự");
                    isValid = false;
                }
                return isValid;
            }


            var tlIndex = cbTLThuoc.SelectedIndex;
            var nccIndex = cbNccThuoc.SelectedIndex;
            var vttIndex = cbVitri.SelectedIndex;

            bool CheckComboBox()
            {
                if (tlIndex == -1)
                {
                    ShowValidateError(cbTLThuoc, Resources.Please_select_a_category);
                    isValid = false;
                }

                if (nccIndex == -1)
                {
                    ShowValidateError(cbNccThuoc, Resources.Please_select_a_supplier);
                    isValid = false;
                }

                if (vttIndex == -1)
                {
                    ShowValidateError(cbVitri, Resources.Please_choose_a_medicine_location);
                    isValid = false;
                }

                return isValid;
            }

            bool CheckDate()
            {
                if (dtpkEXP.Value < dtpkMFG.Value)
                {
                    ShowValidateError(dtpkEXP, Resources.Expiry_date_must_be_greater_than_or_equal_to_Production_date);
                    isValid = false;
                }
                return isValid;
            }


            bool isValidate = CheckEmpty() && CheckValidNumber() && CheckLength() && CheckNumberValue() && CheckComboBox() && CheckDate();

            if (!isValidate) return;


            var tl = cbTLThuoc.Items[tlIndex].ToString();
            var ncc = cbNccThuoc.Items[nccIndex].ToString();
            var vtt = cbVitri.Items[vttIndex].ToString();

            var tlArr = tl.Split('-');
            var nccArr = ncc.Split('-');
            var vttArr = vtt.Split('-');
            var description = rtbMota.Text;

            var type = cbLoai.SelectedIndex == 0;

            var image = "";

            var supplier = supplierBUS.LoadData().FirstOrDefault(s => s.id.Equals(nccArr[0]));
            var category = categoryBUS.LoadData().FirstOrDefault(c => c.id.Equals(tlArr[0]));
            var location = medicineLocationBUS.LoadData().FirstOrDefault(l => l.id.Equals(vttArr[0]));
            var newMedicine = new MedicineDTO(id, name, quantity, priceOut, category, type, unit, mfgDate, expireDate,
                supplier, priceIn, location, description,
                CustomDateTime.GetNow(), "", "", image);
            var result = medicineBUS.Insert(newMedicine);

            if (result == Predefined.SUCCESS)
            {
                QuanLyThuoc_Load();
                CustomMessageBox.ShowSuccess(Resources.Added_medicine_information_successfully);
                return;
            }

            if (result == Predefined.ID_EXIST_IN_ARCHIVE)
            {
                CustomMessageBox.ShowError(Resources.Medicine_ID_already_exist_in_archive);
            }
            else if (result == Predefined.ID_EXIST)
            {
                //CustomMessageBox.ShowError(Resources.Medicine_ID_already_exist);
                ShowValidateError(tbMaThuoc, Resources.Medicine_ID_already_exist);
            }
            else
            {
                CustomMessageBox.ShowError(Resources.Cannot_added_this_medicine);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void btnSuaThuoc_Click(object sender, EventArgs e)
    {
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
        try
        {
            var id = tbMaThuoc.Text;
            var name = tbTenThuoc.Text;
            var quantityText = numSL.Text;
            var priceOutText = numGiaBan.Text;
            var priceInText = numGiaNhap.Text;
            var categoryId = cbTLThuoc.SelectedItem.ToString().Split('-')[0];
            var type = cbLoai.SelectedIndex == 0;
            var unit = tbDVT.Text;
            var mfgDate = dtpkMFG.Value.ToString();
            var expireDate = dtpkEXP.Value.ToString();
            var supplierId = cbNccThuoc.SelectedItem.ToString().Split('-')[0];
            var locationId = cbVitri.SelectedItem.ToString().Split('-')[0];
            var description = rtbMota.Text;
            var created = medicineBUS.LoadData().FirstOrDefault(item => item.id.Equals(id))?.created;
            var updated = CustomDateTime.GetNow();
            var image = medicineBUS.LoadData().FirstOrDefault(item => item.id.Equals(id))?.imagePath;

            bool isValid = true;
            bool CheckEmpty()
            {
                if (string.IsNullOrEmpty(id))
                {
                    ShowValidateError(tbMaThuoc, Resources.Please_input_medicine_id);
                    isValid = false;

                }
                if (string.IsNullOrEmpty(name))
                {
                    ShowValidateError(tbTenThuoc, Resources.Please_input_medicine_name);
                    isValid = false;
                }
                if (string.IsNullOrEmpty(unit))
                {
                    ShowValidateError(tbDVT, Resources.Please_input_medicine_unit);
                    isValid = false;
                }
                if (string.IsNullOrEmpty(quantityText))
                {
                    ShowValidateError(numSL, Resources.Please_input_medicine_quantity);
                    isValid = false;
                }
                if (string.IsNullOrEmpty(priceInText))
                {
                    ShowValidateError(numGiaNhap, Resources.Please_input_medicine_price_out);
                    isValid = false;
                }
                if (string.IsNullOrEmpty(priceOutText))
                {
                    ShowValidateError(numGiaBan, Resources.Please_input_medicine_price_out);
                    isValid = false;
                }

                return isValid;
            }

            int quantity = -1;
            decimal priceIn = -1, priceOut = -1;


            bool CheckValidNumber()
            {
                if (!int.TryParse(quantityText, out quantity))
                {

                    ShowValidateError(numSL, Resources.Quantity_must_be_a_number);
                    isValid = false;
                }
                if (!decimal.TryParse(priceInText, out priceIn))
                {

                    ShowValidateError(numGiaNhap, Resources.Price_must_be_a_number);
                    isValid = false;
                }

                if (!decimal.TryParse(priceOutText, out priceOut))
                {

                    ShowValidateError(numGiaBan, Resources.Price_must_be_a_number);
                    isValid = false;
                }
                return isValid;
            };

            bool CheckNumberValue()
            {
                if (quantity < 0)
                {
                    ShowValidateError(numSL, Resources.Quantity_must_be_greater_or_equal_0);
                    isValid = false;
                }

                if (priceOut < 0)
                {
                    ShowValidateError(numGiaBan, Resources.Price_must_be_greater_or_equal_0);
                    isValid = false;
                }

                if (priceIn < 0)
                {
                    ShowValidateError(numGiaNhap, Resources.Price_must_be_greater_or_equal_0);
                    isValid = false;
                }

                if (priceOut < priceIn)
                {
                    ShowValidateError(numGiaBan, "Giá bán phải lớn hơn hoặc bằng giá nhập");
                    isValid = false;
                }

                return isValid;
            }
            bool CheckLength()
            {
                if (tbMaThuoc.Text.Length > 30)
                {
                    ShowValidateError(tbMaThuoc, "Mã thuốc không vượt quá 30 kí tự");
                    isValid = false;
                }

                if (numSL.Text.Length > 9)
                {
                    ShowValidateError(numSL, "Số lượng không thể vượt quá 999999999");
                    isValid = false;
                }

                if (numGiaBan.Text.Length > 9)
                {
                    ShowValidateError(numGiaBan, "Giá bán không thể vượt quá 999999999");
                    isValid = false;
                }

                if (numGiaNhap.Text.Length > 9)
                {
                    ShowValidateError(numGiaNhap, "Giá nhập không thể vượt quá 999999999");
                    isValid = false;
                }

                if (tbDVT.Text.Length > 30)
                {
                    ShowValidateError(tbDVT, "Đơn vị tính không quá 30 kí tự");
                    isValid = false;
                }
                return isValid;
            }


            var tlIndex = cbTLThuoc.SelectedIndex;
            var nccIndex = cbNccThuoc.SelectedIndex;
            var vttIndex = cbVitri.SelectedIndex;

            bool CheckComboBox()
            {
                if (tlIndex == -1)
                {
                    ShowValidateError(cbTLThuoc, Resources.Please_select_a_category);
                    isValid = false;
                }

                if (nccIndex == -1)
                {
                    ShowValidateError(cbNccThuoc, Resources.Please_select_a_supplier);
                    isValid = false;
                }

                if (vttIndex == -1)
                {
                    ShowValidateError(cbVitri, Resources.Please_choose_a_medicine_location);
                    isValid = false;
                }

                return isValid;
            }

            bool CheckDate()
            {
                if (dtpkEXP.Value < dtpkMFG.Value)
                {
                    ShowValidateError(dtpkEXP, Resources.Expiry_date_must_be_greater_than_or_equal_to_Production_date);
                    isValid = false;
                }
                return isValid;
            }


            bool isValidate = CheckEmpty() && CheckValidNumber() && CheckLength() && CheckNumberValue() && CheckComboBox() && CheckDate();

            if (!isValidate) return;

            var supplier = supplierBUS.LoadData().FirstOrDefault(s => s.id.Equals(supplierId));
            var category = categoryBUS.LoadData().FirstOrDefault(c => c.id.Equals(categoryId));
            var location = medicineLocationBUS.LoadData().FirstOrDefault(l => l.id.Equals(locationId));

            var medicine = new MedicineDTO(id, name, quantity, priceOut, category, type, unit, mfgDate, expireDate,
                supplier, priceIn, location, description,
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
                    return medicine.expDate.ToLower().Contains(noidungtimkiem);
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowWarning("Bạn không có quyền truy cập chức năng này");
            return;
        }
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowWarning("Bạn không có quyền truy cập chức năng này");
            return;
        }
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
            var expireDate = DateTime.ParseExact(medicine.expDate, "dd/MM/yyyy", null);
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

    private void ClearTextBox_TextChanged(object sender, EventArgs e)
    {
        ShowValidateError((Control)sender, "");
    }

    private void cbTLThuoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (comboBox.SelectedIndex == comboBox.Items.Count - 1)
        {
            tabControl1.SelectTab(1);
            comboBox.SelectedIndex = -1;
        }
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
                CustomMessageBox.ShowSuccess(Resources.Add_medicine_location_successfully);
                return;
            }

            if (state == Predefined.ID_EXIST)
                ShowValidateError(tbTenViTri, Resources.Location_name_already_exists);
            else if (state == Predefined.ID_EXIST_IN_ARCHIVE)
                ShowValidateError(tbTenViTri, Resources.Location_name_already_exists_in_archive);
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
                CustomMessageBox.ShowSuccess(Resources.Edit_medicine_location_successfully);
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
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
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
        var deletedMedicineLocation = new DeletedMedicineLocationDialog(tbTimViTri_TextChanged);
        deletedMedicineLocation.ShowDialog();
    }

    private void btnDeletedSupplier_Click(object sender, EventArgs e)
    {
        if (staff.isSeller)
        {
            CustomMessageBox.ShowError(Resources.Do_not_have_permission_to_access);
            return;
        }
        var deletedSupplier = new DeletedSupplierDialog(tbTimNCC_TextChanged);
        deletedSupplier.ShowDialog();
    }


    private void cbNccThuoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (comboBox.SelectedIndex == comboBox.Items.Count - 1)
        {
            tabControl1.SelectTab(2);
            comboBox.SelectedIndex = -1;
        }
    }

    private void cbVitri_SelectedIndexChanged(object sender, EventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (comboBox.SelectedIndex == comboBox.Items.Count - 1)
        {
            tabControl1.SelectTab(3);
            comboBox.SelectedIndex = -1;
        }
    }

    private void tb_NonSpace_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsWhiteSpace(e.KeyChar))
        {
            e.Handled = true;
        }
    }


    private void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dgvHoaDon.Rows)
        {
            row.Cells[0].Value = ckbSelectAll.Checked;
        }
    }

    private void cbbPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        cbbPageSizeIndex = cbbPageSize.SelectedIndex;
        isOldDataHoaDon = false;
        numCurrentPage.Value = numCurrentPage.Minimum;
        RefreshBill();
    }


    private void numCurrentPage_Click(object sender, EventArgs e)
    {
        isOldDataHoaDon = false;
        RefreshBill();
    }

    private void numCurrentPage_KeyUp(object sender, KeyEventArgs e)
    {
        if (numCurrentPage.Text.Length == 0)
            return;
        numCurrentPage_Click(sender, e);
    }

    private void btnBillDelete_Click(object sender, EventArgs e)
    {
        var isDeleted = false;
        foreach (DataGridViewRow row in dgvHoaDon.Rows)
        {
            if (row.Cells[0].Value != null && (bool)row.Cells[0].Value)
            {
                var id = row.Cells[1].Value.ToString();
                var state = billBUS.Delete(id);
                if (state != Predefined.SUCCESS)
                {
                    CustomMessageBox.ShowError(Resources.Delete_failed);
                    return;
                }
                isDeleted = true;
            }
        }

        if (isDeleted)
        {
            isOldDataHoaDon = false;
            if (isSearching)
            {
                btnTimKiemHoaDon_Click(sender, e);
            }
            else
            {
                HoaDon_Load();
            }
            return;
        }
        CustomMessageBox.ShowError(Resources.Please_check_bill_to_delete);
    }

    private bool isSearching = false;
    private void btnTimKiemHoaDon_Click(object sender, EventArgs e)
    {
        string maHoaDon = tbMaHoaDon.Text.Trim();
        string maHoacTenThuoc = tbMaTenThuoc.Text.Trim();
        string tenKhachHang = tbTenKhach.Text.Trim();
        int trangThai = cbbTrangThai.SelectedIndex;
        string tuNgay = cbbTuNgay.Text;
        string denNgay = cbbDenNgay.Text;
        string giaTriTu = cbbGiaTriTu.Text;
        string giaTriDen = cbbGiaTriDen.Text;
        string maNhanVien = cbbNhanVien.Text.Split("-")[0];

        bool isValidate = true;
        if (!string.IsNullOrEmpty(tuNgay) && !string.IsNullOrEmpty(denNgay))
        {
            if (!DateTime.TryParseExact(tuNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var a))
            {
                ShowValidateError(cbbTuNgay, "Ngày phải ở định dạng dd/MM/yyyy (ngày/tháng/năm)");
                isValidate = false;
            }


            if (!DateTime.TryParseExact(denNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var b))
            {
                ShowValidateError(cbbDenNgay, "Ngày phải ở định dạng dd/MM/yyyy (ngày/tháng/năm)");
                isValidate = false;
            }

            var one = DateTime.ParseExact(tuNgay, "dd/MM/yyyy", null);
            var two = DateTime.ParseExact(denNgay, "dd/MM/yyyy", null);
            var timespan = one - two;
            if (isValidate && timespan.TotalDays > 0)
            {
                ShowValidateError(cbbDenNgay, "Giá trị ngày phải lớn hơn hoặc bằng ngày bắt đầu");
                isValidate = false;
            }
        }



        if (!isValidate)
        {
            return;
        }



        cbbPageSize.SelectedIndex = cbbPageSizeIndex;
        var pageSize = int.Parse(cbbPageSize.Text);
        var currentPage = int.Parse(numCurrentPage.Text);
        var result = billBUS.Search(pageSize, currentPage, maHoaDon, maHoacTenThuoc, tenKhachHang, trangThai, tuNgay, denNgay, giaTriTu, giaTriDen, maNhanVien);
        totalPage = result.totalPage;
        numRecord = result.numRecord;
        lbTotalPage.Text = "/" + totalPage;
        var numCurrentPageInt = int.Parse(numCurrentPage.Text);
        if (numCurrentPageInt > totalPage || numCurrentPage.Minimum == 0)
        {
            currentPage = 1;
        }
        if (totalPage > 0)
        {
            numCurrentPage.Minimum = 1;
        }
        numCurrentPage.Maximum = totalPage;
        if (oldNumRecord != numRecord)
        {
            isOldDataHoaDon = false;
        }

        if (isOldDataHoaDon)
        {
            return;
        }
        isOldDataHoaDon = true;
        oldNumRecord = numRecord;
        HienThiHoaDon(result.listBills);
        flowLayoutTimKiem.Visible = true;
        isSearching = true;
    }

    private void cbbGiaTriTu_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void btnResetSearchBill_Click(object sender, EventArgs e)
    {
        tbMaHoaDon.Text = "";
        tbMaTenThuoc.Text = "";
        tbTenKhach.Text = "";
        cbbTrangThai.Text = "";
        cbbTuNgay.Text = "";
        cbbDenNgay.Text = "";
        cbbGiaTriTu.Text = "";
        cbbGiaTriDen.Text = "";
        cbbNhanVien.Text = "";
        //isOldDataHoaDon = false;
    }

    private void btnExitSearch_Click(object sender, EventArgs e)
    {
        isOldDataHoaDon = false;
        isSearching = false;
        HoaDon_Load();

    }

    private void button5_Click(object sender, EventArgs e)
    {

        DeletedBillDialog deletedBillDialog = new DeletedBillDialog();
        deletedBillDialog.refreshBillForm += () =>
        {
            isOldDataHoaDon = false;
            if (isSearching)
            {
                btnTimKiemHoaDon_Click(sender, e);
            }
            else
            {
                HoaDon_Load();
            }
        };
        deletedBillDialog.ShowDialog();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        oldNumRecord = 0;
        RefreshBill();
    }

    private void btnBanHang_Click(object sender, EventArgs e)
    {
        BanThuocGUI banThuocGui = new BanThuocGUI(user, () =>
            {
                isOldDataHoaDon = false;
                RefreshBill();
            }
            );
        banThuocGui.Show();
    }

    private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != dgvHoaDon.Columns[0].Index && e.RowIndex >= 0)
        {
            var id = dgvHoaDon.Rows[e.RowIndex].Cells[1].Value.ToString();
            var bill = billBUS.GetById(id);
            if (bill == null) return;
            BanThuocGUI banThuocGui = new BanThuocGUI(user, bill, () =>
            {
                isOldDataHoaDon = false;
                RefreshBill();
            }
                );
            banThuocGui.Show();
        }
    }

    private void LoadThongKe()
    {
        StatDAL statDAL = new();
        var listAllDoanhThuLoiNhuan = statDAL.TatCaDoanhThuLoiNhuan();
        foreach (var item in listAllDoanhThuLoiNhuan)
        {
            dgvDoanhThuAll.Rows.Add(item.doanhthu, item.loinhuan);
        }


        var listDoanhThuTheoNgay = statDAL.DoanhThuNgay();
        foreach (var item in listDoanhThuTheoNgay)
        {
            dgvDoanhThuNgay.Rows.Add(item.ngay.Split(" ")[0], item.doanhthu, item.loinhuan);
        }

        var listDoanhThuTheoThang = statDAL.DoanhThuThang();
        foreach (var item in listDoanhThuTheoThang)
        {
            dgvDoanhThuThang.Rows.Add(item.nam, item.thang, item.doanhthu, item.loinhuan);
        }

        var listDoanhThuThuoc = statDAL.DoanhThuThuoc();
        foreach (var item in listDoanhThuThuoc)
        {
            dgvDoanhThuThuoc.Rows.Add(item.mathuoc, item.tenthuoc, item.gianhap, item.giaban, item.soluong, item.doanhthu, item.loinhuan);
        }

    }
}