using ProjectXML.Controller;
using ProjectXML.Model;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectXML.View
{
    public partial class DeletedMedicine : Form
    {
        MedicineController medicineController;
        public delegate void RefreshDeletedMedicine();
        public RefreshDeletedMedicine refreshDeletedMedicine;
        public DeletedMedicine(MedicineController medicineController)
        {
            InitializeComponent();
            this.medicineController = new MedicineController();
        }

        public void DeletedMedicine_Show()
        {
            dgvDeletedMedicine.Rows.Clear();
            int i = 0;
            List<Medicine> medicineList = medicineController.LoadData();
            foreach (Medicine medicine in medicineList)
            {
                if (medicine.deleted.Equals(""))
                {
                    continue;
                }
                dgvDeletedMedicine.Rows.Add(++i, medicine.id, medicine.name, $"{medicine.category.id}-{medicine.category.name}", medicine.expireDate, medicine.quantity, medicine.unit, medicine.price, medicine.description, $"{medicine.supplier.id}-{medicine.supplier.name}", medicine.deleted);
            }
        }

        private void DeletedMedicine_Load(object sender, EventArgs e)
        {
            DeletedMedicine_Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvDeletedMedicine.CurrentRow.Index;
                string maTheLoai = dgvDeletedMedicine.Rows[index].Cells[1].Value.ToString();
                int state = medicineController.Restore(maTheLoai);
                if (state == Predefined.SUCCESS)
                {
                    DeletedMedicine_Show();
                    refreshDeletedMedicine();
                    return;
                }
                if (state == Predefined.ID_NOT_EXIST)
                {
                    CustomMessageBox.ShowError("Mã thuốc không tồn tại");
                }
                else
                {
                    CustomMessageBox.ShowError("Khôi phục thất bại");
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int state = medicineController.RestoreAll();
                if (state == Predefined.FILE_NOT_FOUND)
                {
                    CustomMessageBox.ShowError("Khôi phục thất bại");
                    return;
                }
                DeletedMedicine_Show();
                refreshDeletedMedicine();


            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dgvDeletedMedicine.CurrentRow == null)
            {
                CustomMessageBox.ShowWarning("Mục lưu trữ đang trống");
                return;
            }
            var confirmResult = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn xóa vĩnh viễn thuốc này?");
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int index = dgvDeletedMedicine.CurrentRow.Index;
                    string maTheLoai = dgvDeletedMedicine.Rows[index].Cells[1].Value.ToString();
                    int state = medicineController.ForceDelete(maTheLoai);
                    if (state == Predefined.SUCCESS)
                    {
                        DeletedMedicine_Show();
                        refreshDeletedMedicine();
                        return;
                    }
                    if (state == Predefined.ID_NOT_EXIST)
                    {
                        CustomMessageBox.ShowError("Mã thể loại không tồn tại");
                    }
                    else
                    {
                        CustomMessageBox.ShowError("Xóa thất bại");
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}

