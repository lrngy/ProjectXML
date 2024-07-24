using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ProjectXML.BUS;
using ProjectXML.DTO;
using ProjectXML.Properties;
using ProjectXML.Util;

namespace ProjectXML.GUI.Dialog
{
    public partial class FilterByRangeDialog : Form
    {
        public delegate void OnClickFilter(List<MedicineDTO> list);

        public MedicineBUS medicineController;
        public OnClickFilter onClick;

        public FilterByRangeDialog(MedicineBUS medicineController)
        {
            InitializeComponent();
            this.medicineController = medicineController;
        }

        private void EnableControls(params Control[] controls)
        {
            foreach (var control in controls) control.Enabled = true;
        }

        private void DisableControls(params Control[] controls)
        {
            foreach (var control in controls) control.Enabled = false;
        }

        public List<MedicineDTO> FilterByPrice(List<MedicineDTO> medicineList)
        {
            var from = tbGiaBD.Text;
            var to = tbGiaKT.Text;
            if (from.Equals("") || to.Equals(""))
            {
                CustomMessageBox.ShowWarning(Resources.PleaseEnterCompleteInfo);
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

            return medicineList.Where(medicine => medicine.price_out >= priceFrom && medicine.price_out <= priceTo)
                .ToList();
        }

        public List<MedicineDTO> FilterByImportDate(List<MedicineDTO> medicineList)
        {
            var from = dtpNhapBD.Value;
            var to = dtpNhapKT.Value;
            if (from.Date.CompareTo(to.Date) > 0)
            {
                CustomMessageBox.ShowWarning("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
                return null;
            }

            return medicineList.Where(medicine =>
                {
                    DateTime createdDate;
                    if (!DateTime.TryParseExact(medicine.created, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out createdDate))
                        return false;
                    return createdDate.Date.CompareTo(from.Date) >= 0 && createdDate.Date.CompareTo(to.Date) <= 0;
                }
            ).ToList();
        }


        public List<MedicineDTO> FilterByExpireDate(List<MedicineDTO> medicineList)
        {
            var from = dtpHanBD.Value;
            var to = dtpHanKT.Value;

            if (from.Date.CompareTo(to.Date) > 0)
            {
                CustomMessageBox.ShowWarning("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
                return null;
            }

            return medicineList.Where(medicine =>
                {
                    DateTime expireDate;
                    if (!DateTime.TryParseExact(medicine.expireDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out expireDate))
                        return false;
                    return expireDate.Date.CompareTo(from.Date) >= 0 && expireDate.Date.CompareTo(to.Date) <= 0;
                }
            ).ToList();
        }

        public List<MedicineDTO> FilterByQuantity(List<MedicineDTO> medicineList)
        {
            var from = tbSLBD.Text;
            var to = tbSLKT.Text;
            if (from.Equals("") || to.Equals(""))
            {
                CustomMessageBox.ShowWarning(Resources.PleaseEnterCompleteInfo);
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

            return medicineList.Where(medicine => medicine.quantity >= quantityFrom && medicine.quantity <= quantityTo)
                .ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var medicineList = medicineController.LoadData();
            if (ckbGia.Checked) medicineList = FilterByPrice(medicineList);

            if (ckbSL.Checked) medicineList = FilterByQuantity(medicineList);
            if (ckbNgayNhap.Checked) medicineList = FilterByImportDate(medicineList);
            if (ckbNgayHetHan.Checked) medicineList = FilterByExpireDate(medicineList);

            if (medicineList == null) return;

            onClick(medicineList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onClick(null);
            Dispose();
        }


        private void ckbGia_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckbGia.Checked)
                EnableControls(tbGiaBD, tbGiaKT);
            else
                DisableControls(tbGiaBD, tbGiaKT);
        }

        private void ckbSL_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSL.Checked)
                EnableControls(tbSLBD, tbSLKT);
            else
                DisableControls(tbSLBD, tbSLKT);
        }

        private void ckbNgayNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNgayNhap.Checked)
                EnableControls(dtpNhapBD, dtpNhapKT);
            else
                DisableControls(dtpNhapBD, dtpNhapKT);
        }

        private void ckbNgayHetHan_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNgayHetHan.Checked)
                EnableControls(dtpHanBD, dtpHanKT);
            else
                DisableControls(dtpHanBD, dtpHanKT);
        }
    }
}