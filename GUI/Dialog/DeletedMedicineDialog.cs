using System;
using System.Windows.Forms;
using QPharma.BUS;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma.GUI.Dialog
{
    public partial class DeletedMedicineDialog : Form
    {
        public delegate void RefreshDeletedMedicine();

        private readonly MedicineBUS medicineController;
        public RefreshDeletedMedicine refreshDeletedMedicine;

        public DeletedMedicineDialog(MedicineBUS medicineController)
        {
            InitializeComponent();
            this.medicineController = new MedicineBUS();
        }

        public void DeletedMedicine_Show()
        {
            dgvDeletedMedicine.Rows.Clear();
            var i = 0;
            var medicineList = medicineController.LoadData();
            foreach (var medicine in medicineList)
            {
                if (medicine.deleted.Equals("")) continue;
                dgvDeletedMedicine.Rows.Add(++i, medicine.id, medicine.name,
                    $"{medicine.category.name}", medicine.expireDate, medicine.quantity,
                    medicine.unit, medicine.price_out, medicine.description,
                    $"{medicine.supplier.name}", medicine.deleted);
            }
        }

        private void DeletedMedicine_Load(object sender, EventArgs e)
        {
            DeletedMedicine_Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvDeletedMedicine.Rows.Count == 1)
            {
                CustomMessageBox.ShowError("Mục lưu trữ đang trống");
                return;
            }

            try
            {
                var index = dgvDeletedMedicine.CurrentRow.Index;
                var maThuoc = dgvDeletedMedicine.Rows[index].Cells[1].Value.ToString();
                var state = medicineController.Restore(maThuoc);
                if (state == Predefined.SUCCESS)
                {
                    DeletedMedicine_Show();
                    refreshDeletedMedicine();
                    CustomMessageBox.ShowSuccess("Đã khôi phục Mã thuốc " + maThuoc);
                    return;
                }

                if (state == Predefined.ID_NOT_EXIST)
                    CustomMessageBox.ShowError(Resources.Medicine_ID_is_not_exist);
                else
                    CustomMessageBox.ShowError("Khôi phục thất bại");
            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvDeletedMedicine.Rows.Count == 1)
            {
                CustomMessageBox.ShowError("Mục lưu trữ đang trống");
                return;
            }

            try
            {
                var state = medicineController.RestoreAll();
                if (state == Predefined.ERROR)
                {
                    CustomMessageBox.ShowError("Khôi phục thất bại");
                    return;
                }

                DeletedMedicine_Show();
                refreshDeletedMedicine();
                CustomMessageBox.ShowSuccess("Khôi phục tất cả thuốc thành công");
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvDeletedMedicine.Rows.Count == 1)
            {
                CustomMessageBox.ShowError("Mục lưu trữ đang trống");
                return;
            }

            var confirmResult = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn xóa vĩnh viễn thuốc này?");
            if (confirmResult == DialogResult.Yes)
                try
                {
                    var index = dgvDeletedMedicine.CurrentRow.Index;
                    var maTheLoai = dgvDeletedMedicine.Rows[index].Cells[1].Value.ToString();
                    var state = medicineController.ForceDelete(maTheLoai);
                    if (state == Predefined.SUCCESS)
                    {
                        DeletedMedicine_Show();
                        refreshDeletedMedicine();
                        return;
                    }

                    if (state == Predefined.ID_NOT_EXIST)
                        CustomMessageBox.ShowError(Resources.Category_ID_does_not_exist);
                    else
                        CustomMessageBox.ShowError(Resources.Delete_failed);
                }
                catch (Exception)
                {
                }
        }
    }
}