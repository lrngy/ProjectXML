using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QPharma.GUI
{

    public partial class BanThuocGUI : BaseForm
    {
        class CalculatorMoney(string id, decimal quantity, decimal price)
        {
            internal string id = id;
            internal decimal quantity = quantity;
            internal decimal price = price;
            internal decimal total = quantity * price;
        }
        private enum BillState
        {
            Default = 0,
            Waiting = 1,
            Paid = 2
        }

        private bool isValidMoney = true;
        private bool isValidQuantity = true;
        private BillState billState = BillState.Default;
        private UserDTO user;
        private MedicineBUS medicineBUS = new();
        private CustomerBUS customerBUS = new();
        private BillBUS billBUS = new();
        private List<CalculatorMoney> calculateMoneyList = new();
        private List<MedicineDTO> medicineList;
        private List<MedicineDTO> medicineBillList;
        private BillDTO billDTO;
        public delegate void UpdateHandler();
        public UpdateHandler updateBill;
        public BanThuocGUI(UserDTO user, UpdateHandler updateBill)
        {
            InitializeComponent();
            this.updateBill = updateBill;
            this.user = user;
            medicineList = medicineBUS.LoadData();
            medicineBillList = new List<MedicineDTO>();
            billDTO = new();
        }

        public BanThuocGUI(UserDTO user, BillDTO bill, UpdateHandler updateBill)
        {
            InitializeComponent();
            this.updateBill = updateBill;
            this.user = user;
            billDTO = bill;
            medicineBillList = bill.BillDetails.Select(detail => detail.medicine).ToList();
            bill.BillDetails.ForEach(detail => calculateMoneyList.Add(new CalculatorMoney(detail.medicine.id, detail.quantity, detail.price)));
            //medicineBillList.ForEach(medicine => calculateMoneyList.Add(new CalculatorMoney(medicine?.id, medicine.quantity, (decimal)medicine.price_out)));
            medicineList = medicineBUS.LoadData().Where(medicine => medicineBillList.All(medicineBill => medicine?.id != medicineBill?.id))
                .ToList();
            billState = bill.Status ? BillState.Paid : BillState.Waiting;
        }

        private void BanHangGUI_Load(object sender, EventArgs e)
        {
            UpdateAll();
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            var customerList = customerBUS.LoadData().Where(customer => string.IsNullOrEmpty(customer.Deleted)).ToList();
            foreach (var customer in customerList)
            {
                cbbKhachHang.Items.Add($"{customer?.Id}-{customer?.Name}");
            }
        }

        private void UpdateAll()
        {
            LoadMedicineList();
            LoadMedicineBillList();
            lbSoTien.Text = Currency.FormatCurrency(calculateMoneyList.Sum(c => c.total).ToString());
            numKhachDua_ValueChanged(null, null);
            updateBill();
            if (billState == BillState.Default)
            {
                btnCancel.Enabled = false;
                btnSave.Enabled = true;
                btnThanhToan.Enabled = true;
                dgvMedicineBill.ReadOnly = false;
                return;
            }

            if (billState == BillState.Waiting)
            {
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
                btnThanhToan.Enabled = true;
                dgvMedicineBill.ReadOnly = false;
            }


            if (billState == BillState.Paid)
            {
                btnCancel.Enabled = true;
                btnSave.Enabled = false;
                btnThanhToan.Enabled = false;
                dgvMedicineBill.ReadOnly = true;
            }
            numKhachDua.Text = billDTO.CustomerPaid.ToString();
            cbbKhachHang.Text = $"{billDTO.Customer.Id}-{billDTO.Customer.Name}";
            tbBacSi.Text = billDTO.DoctorPrescribed;
            lbTrangThai.Text = $"Trạng thái: {(billDTO.Status ? "Đã thanh toán" : "Đang chờ")}";
            lbTrangThai.BackColor = billDTO.Status ? Color.LightGreen : Color.BurlyWood;
            DateTime datetime = DateTime.ParseExact(billDTO.Created, "dd/MM/yyyy HH:mm:ss", null);
            lbDate.Text = $"{CustomDateTime.GetFormattedDate(datetime.ToString("dd/MM/yyyy"), "{0}, {1}/{2}/{3}")}, {datetime.ToString("HH:mm")}";
            lbHeading.Text = $"Hoá đơn: {billDTO.Id}";

        }
        private void LoadMedicineList()
        {
            dgvMedicine.Rows.Clear();
            int i = 0;
            foreach (var medicine in medicineList)
            {
                if (!string.IsNullOrEmpty(medicine.deleted) || medicine.quantity < 1)
                {
                    continue;
                }
                dgvMedicine.Rows.Add(++i, medicine?.id, medicine?.name, medicine.category?.name, medicine?.quantity, medicine?.unit, Currency.FormatCurrency(medicine?.price_out.ToString()));
            }
        }

        private void LoadMedicineBillList()
        {
            dgvMedicineBill.Rows.Clear();
            int i = 0;
            foreach (var medicineBill in medicineBillList)
            {
                var calculatorMoney = calculateMoneyList.FirstOrDefault(c => c.id.Equals(medicineBill.id));
                dgvMedicineBill.Rows.Add(++i, medicineBill?.id, medicineBill?.name, calculatorMoney?.quantity, medicineBill?.unit, Currency.FormatCurrency(calculatorMoney?.price.ToString()), Currency.FormatCurrency(calculatorMoney?.total.ToString()), "x");
                var oldQuantity = (billState == BillState.Waiting) ? billDTO.BillDetails.FirstOrDefault(billDetail => billDetail.medicine.id.Equals(medicineBill.id)).quantity : 0;
                var currentQuantity = decimal.Parse(dgvMedicineBill.Rows[i - 1].Cells[4].Value.ToString());
                if (currentQuantity > medicineBill.quantity + oldQuantity)
                {
                    dgvMedicineBill.Rows[i - 1].Cells[3].ErrorText = $"Vượt quá số lượng trong kho - Tối đa <= {medicineBill.quantity}";
                    isValidQuantity = false;
                }
            }
        }


        private void btnAddToSellBill_Click(object sender, EventArgs e)
        {
            if (dgvMedicine.SelectedRows.Count == 0)
                return;
            try
            {
                var id = dgvMedicine.SelectedRows[0].Cells[1].Value.ToString();
                var medicine = medicineList.FirstOrDefault(m => m.id.Equals(id));
                if (medicine != null)
                {
                    medicineList.Remove(medicine);
                    medicineBillList.Add(medicine);
                    calculateMoneyList.Add(new CalculatorMoney(medicine.id, 1, (decimal)medicine.price_out));
                    UpdateAll();
                }
                LoadMedicineBillList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void DgvMedicineBillCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvMedicineBill.Columns[7].Index && e.RowIndex >= 0 && billState != BillState.Paid)
                {
                    string id = dgvMedicineBill.Rows[e.RowIndex].Cells[1].Value.ToString();
                    var medicine = medicineBillList.FirstOrDefault(m => m.id.Equals(id));
                    if (medicine is null)
                        return;

                    medicineBillList.Remove(medicine);

                    var calculator = calculateMoneyList.FirstOrDefault(c => c.id.Equals(id));
                    if (billState == BillState.Waiting)
                    {
                        medicine.quantity += calculator.quantity;
                    }
                    calculateMoneyList.Remove(calculator);
                    medicineList.Add(medicine);
                    UpdateAll();
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void dgvMedicineBill_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvMedicineBill.Columns[3].Index)
            {
                try
                {
                    medicineBillList = medicineBUS.LoadData().Where(medicine => medicineBillList.Any(item => medicine.id.Equals(item.id))).ToList();
                    var medicineId = dgvMedicineBill.Rows[e.RowIndex].Cells[1].Value.ToString();
                    var calculatorMoney = calculateMoneyList.FirstOrDefault(c => c.id.Equals(medicineId));

                    if (calculatorMoney is null)
                    {
                        return;
                    }
                    var oldQuantity = (billState == BillState.Waiting) ? billDTO.BillDetails.FirstOrDefault(billDetail => billDetail.medicine.id.Equals(medicineId)).quantity : 0;
                    calculatorMoney.quantity =
                        decimal.Parse(dgvMedicineBill.Rows[e.RowIndex].Cells[3].Value.ToString());
                    var medicineBill = medicineBillList.FirstOrDefault(m => m.id.Equals(medicineId));

                    if (medicineBill is null)
                    {
                        return;
                    }

                    if (calculatorMoney.quantity > medicineBill.quantity + oldQuantity)
                    {
                        isValidQuantity = false;
                        dgvMedicineBill.Rows[e.RowIndex].Cells[3].ErrorText = $"Vượt quá số lượng trong kho - Tối đa <= {medicineBill.quantity}";
                        calculatorMoney.total = 0;
                        dgvMedicineBill.Rows[e.RowIndex].Cells[6].Value = Currency.FormatCurrency(calculatorMoney.total.ToString());
                        lbSoTien.Text = Currency.FormatCurrency(calculateMoneyList.Sum(c => c.total).ToString());
                        numKhachDua_ValueChanged(null, null);
                        return;
                    }

                    if (calculatorMoney.quantity < 1)
                    {
                        calculatorMoney.quantity = 1;
                        dgvMedicineBill.Rows[e.RowIndex].Cells[3].Value = 1;
                    }

                    isValidQuantity = true;
                    dgvMedicineBill.Rows[e.RowIndex].Cells[3].ErrorText = string.Empty;
                    calculatorMoney.total = calculatorMoney.quantity * calculatorMoney.price;
                    dgvMedicineBill.Rows[e.RowIndex].Cells[6].Value = Currency.FormatCurrency(calculatorMoney.total.ToString());
                    lbSoTien.Text = Currency.FormatCurrency(calculateMoneyList.Sum(c => c.total).ToString());
                    numKhachDua_ValueChanged(null, null);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private void ShowValidateError(Control control, string message)
        {
            errorProvider1.SetError(control, message);
            toolTip1.SetToolTip(control, message);
            toolTip1.Show(message, control, 0, control.Height, 2000);
        }

        private void numKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void numKhachDua_MouseClick(object sender, MouseEventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            numericUpDown.Select(0, numericUpDown.Text.Length);
        }

        private void numKhachDua_ValueChanged(object sender, EventArgs e)
        {
            decimal khachDua = numKhachDua.Value;
            decimal tongTien = calculateMoneyList.Sum(c => c.total);
            decimal tienTraLai = khachDua - tongTien;

            if (tienTraLai < 0)
            {
                isValidMoney = false;
                string conThieu = $"Khách còn thiếu {Currency.FormatCurrency(Math.Abs(tienTraLai).ToString())}";
                lbTienTraLai.Text = conThieu;
                ShowValidateError(numKhachDua, conThieu);
                ShowValidateError(lbTienTraLai, conThieu);
                return;
            }

            isValidMoney = true;
            lbTienTraLai.Text = Currency.FormatCurrency(tienTraLai.ToString());
            ShowValidateError(numKhachDua, "");
            ShowValidateError(lbTienTraLai, "");

            if (tongTien == 0)
            {
                lbTienTraLai.Text = "0";
            }
        }


        private bool GetBillValue()
        {
            bool isValid = true;
            if (dgvMedicineBill.RowCount == 0)
            {
                CustomMessageBox.ShowWarning("Chưa có thuốc nào trong hoá đơn");
                return false;
            }

            if (string.IsNullOrEmpty(cbbKhachHang.Text))
            {
                ShowValidateError(cbbKhachHang, "Vui lòng nhập tên khách hàng");
                isValid = false;
            }
            else
                ShowValidateError(cbbKhachHang, "");

            if (!isValidQuantity)
            {
                ShowValidateError(lbHeading, "Vui lòng kiểm tra lại số lượng mặt hàng hợp lệ");
                isValid = false;
            }
            else
                ShowValidateError(lbHeading, "");


            if (!isValidMoney)
            {
                isValid = false;
            }

            if (!isValid) return false;

            billDTO.BillDetails = new();
            List<(MedicineDTO medicine, decimal quantity, decimal price)> billDetails = new();
            foreach (DataGridViewRow dr in dgvMedicineBill.Rows)
            {
                var medicineId = dr.Cells[1].Value.ToString();
                MedicineDTO medicine = medicineBillList.FirstOrDefault(m => m.id.Equals(medicineId));
                var quantity = decimal.Parse(dr.Cells[3].Value.ToString());
                var price = decimal.Parse(Currency.ParseCurrency(dr.Cells[5].Value.ToString()));
                billDetails.Add((medicine, quantity, price));
            }
            billDTO.BillDetails = billDetails;
            billDTO.Total = calculateMoneyList.Sum(c => c.total);
            billDTO.CustomerPaid = numKhachDua.Value;
            billDTO.Note = tbGhiChu.Text;
            var customerId = cbbKhachHang.Text.Split('-')[0];

            var tryParseCustomerId = int.TryParse(customerId, out var resParse);
            CustomerDTO customer = null;

            if (tryParseCustomerId)
            {
                customer = customerBUS.GetById(customerId);
            }

            if (customer is null)
            {
                customer = new(cbbKhachHang.Text, true);
            }
            billDTO.Customer = customer;
            billDTO.Staff = StaffDAL.GetByUsername(user.username);
            billDTO.DoctorPrescribed = tbBacSi.Text;
            billDTO.Created = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!GetBillValue()) return;

            var result = billBUS.SaveBill(ref billDTO);
            if (result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess("Lưu hoá đơn thành công");
                billState = BillState.Waiting;
                UpdateAll();
            }
            else
            {
                CustomMessageBox.ShowError("Lưu hoá đơn thất bại");
            }

        }

        private void BanHangGUI_Activated(object sender, EventArgs e)
        {
            medicineBillList = medicineBUS.LoadData().Where(medicine => medicineBillList.Any(item => medicine.id.Equals(item.id))).ToList();
            UpdateAll();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!GetBillValue()) return;


            billDTO.Status = true;
            var result = billBUS.SaveBill(ref billDTO);
            if (result == Predefined.SUCCESS)
            {
                CustomMessageBox.ShowSuccess("Thanh toán hoá đơn thành công");
                billState = BillState.Paid;
                UpdateAll();
            }
            else
            {
                CustomMessageBox.ShowError("Thanh toán hoá đơn thất bại");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogRes = CustomMessageBox.ShowQuestion(
                    "Thao tác này sẽ huỷ bỏ hoá đơn và hoàn lại số lượng thuốc. Bạn có muốn tiếp tục không ?");
                if (dialogRes == DialogResult.No) return;
                var result = billBUS.RevertSellBill(billDTO.Id);
                if (result == Predefined.SUCCESS)
                {
                    CustomMessageBox.ShowSuccess("Huỷ bỏ hoá đơn thành công");
                    Dispose();

                }
                else
                {
                    CustomMessageBox.ShowError("Huỷ bỏ hoá đơn thất bại");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void btnToiThieu_Click(object sender, EventArgs e)
        {
            numKhachDua.Value = calculateMoneyList.Sum(c => c.total);
        }
    }
}
