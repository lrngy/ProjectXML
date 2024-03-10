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

namespace ProjectXML.View.Dialog
{
    public partial class FilterByRangeDialog : Form
    {
        public MedicineController medicineController;
        public delegate void OnClickFilter(List<Medicine> list);
        public OnClickFilter onClick;

        public FilterByRangeDialog(MedicineController medicineController)
        {
            InitializeComponent();
            this.medicineController = medicineController;
        }

        private void EnableControls(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = true;
            }
        }

        private void DisableControls(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = false;
            }
        }

        public List<Medicine> FilterByPrice(List<Medicine> medicineList)
        {
            string from = tbGiaBD.Text;
            string to = tbGiaKT.Text;
            if (from.Equals("") || to.Equals(""))
            {
                CustomMessageBox.ShowWarning("Vui lòng nhập đầy đủ thông tin");
                return null;
            }
            double priceFrom = 0, priceTo = 0;
            if (!double.TryParse(from, out priceFrom) || !double.TryParse(to, out priceTo))
            {
                CustomMessageBox.ShowWarning("Vui lòng nhập giá hợp lệ");
                return null;
            }
            if (priceFrom < 0 || priceTo < 0)
            {
                CustomMessageBox.ShowWarning("Giá không thể âm");
                return null;
            }
            if (priceFrom > priceTo)
            {
                CustomMessageBox.ShowWarning("Giá bắt đầu phải nhỏ hơn giá kết thúc");
                return null;
            }
            return medicineList.Where(medicine => medicine.price >= priceFrom && medicine.price <= priceTo).ToList();


        }

        public List<Medicine> FilterByImportDate(List<Medicine> medicineList)
        {
            DateTime from = dtpNhapBD.Value;
            DateTime to = dtpNhapKT.Value;
            if (from.Date.CompareTo(to.Date) > 0)
            {
                CustomMessageBox.ShowWarning("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
                return null;
            }
            return medicineList.Where(medicine =>
            {
                DateTime createdDate;
                if (!DateTime.TryParseExact(medicine.created, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture,
System.Globalization.DateTimeStyles.None, out createdDate))
                {
                    return false;
                }
                return createdDate.Date.CompareTo(from.Date) >= 0 && createdDate.Date.CompareTo(to.Date) <= 0;
            }
            ).ToList();

        }


        public List<Medicine> FilterByExpireDate(List<Medicine> medicineList)
        {
            DateTime from = dtpHanBD.Value;
            DateTime to = dtpHanKT.Value;

            if (from.Date.CompareTo(to.Date) > 0)
            {
                CustomMessageBox.ShowWarning("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
                return null;
            }
            return medicineList.Where(medicine =>
            {
                DateTime expireDate;
                if (!DateTime.TryParseExact(medicine.expireDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None, out expireDate))
                {
                    return false;
                }
                return expireDate.Date.CompareTo(from.Date) >= 0 && expireDate.Date.CompareTo(to.Date) <= 0;
            }
            ).ToList();

        }
        public List<Medicine> FilterByQuantity(List<Medicine> medicineList)
        {
            string from = tbSLBD.Text;
            string to = tbSLKT.Text;
            if (from.Equals("") || to.Equals(""))
            {
                CustomMessageBox.ShowWarning("Vui lòng nhập đầy đủ thông tin");
                return null;
            }
            int quantityFrom = 0, quantityTo = 0;
            if (!int.TryParse(from, out quantityFrom) || !int.TryParse(to, out quantityTo))
            {
                CustomMessageBox.ShowWarning("Vui lòng nhập số");
                return null;
            }
            if (quantityFrom < 0 || quantityTo < 0)
            {
                CustomMessageBox.ShowWarning("Số lượng không thể âm");
                return null;
            }
            if (quantityFrom > quantityTo)
            {
                CustomMessageBox.ShowWarning("Số lượng bắt đầu phải nhỏ hơn số lượng kết thúc");
                return null;
            }
            return medicineList.Where(medicine => medicine.quantity >= quantityFrom && medicine.quantity <= quantityTo).ToList();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Medicine> medicineList = medicineController.LoadData();
            if (ckbGia.Checked)
            {
                medicineList = FilterByPrice(medicineList);
            }

            if (ckbSL.Checked)
            {
                medicineList = FilterByQuantity(medicineList);
            }
            if (ckbNgayNhap.Checked)
            {
                medicineList = FilterByImportDate(medicineList);
            }
            if (ckbNgayHetHan.Checked)
            {
                medicineList = FilterByExpireDate(medicineList);
            }

            if(medicineList == null)
            {
                return;
            }

            onClick(medicineList);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            onClick(null);
            this.Dispose();
        }


        private void ckbGia_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckbGia.Checked)
            {
                EnableControls(tbGiaBD, tbGiaKT);

            }
            else
            {
                DisableControls(tbGiaBD, tbGiaKT);
            }

        }

        private void ckbSL_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSL.Checked)
            {
                EnableControls(tbSLBD, tbSLKT);
            }
            else
            {
                DisableControls(tbSLBD, tbSLKT);
            }

        }

        private void ckbNgayNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNgayNhap.Checked)
            {
                EnableControls(dtpNhapBD, dtpNhapKT);
            }
            else
            {
                DisableControls(dtpNhapBD, dtpNhapKT);
            }

        }

        private void ckbNgayHetHan_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNgayHetHan.Checked)
            {
                EnableControls(dtpHanBD, dtpHanKT);
            }
            else
            {
                DisableControls(dtpHanBD, dtpHanKT);
            }

        }
    }
}
