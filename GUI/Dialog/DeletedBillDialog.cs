using QPharma.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QPharma.GUI.Dialog
{
    public partial class DeletedBillDialog : BaseForm
    {
        private BillBUS billBUS;
        public delegate void RefreshBillForm();
        public RefreshBillForm refreshBillForm;
        private int numRecord = 0;
        public DeletedBillDialog()
        {
            InitializeComponent();
            billBUS = new BillBUS();
        }
        private void DeletedBillDialog_Load(object sender, EventArgs e)
        {
            var result = billBUS.LoadData(99999999, 1, false);
            var listFiltered = result.listBills;
            HienThiHoaDon(listFiltered, listFiltered.Count);
        }

        private void HienThiHoaDon(List<BillDTO> list, int numRecord)
        {
            this.numRecord = numRecord;
            dgvDeletedBill.Rows.Clear();

            BeginInvoke(() => { dgvDeletedBill.ClearSelection(); });

            lbSoDong.Text = $"Tổng cộng {numRecord} dòng";
            for (var i = 0; i < list.Count; i++)
            {

                dgvDeletedBill.Rows.Add(
                    list[i].Id,
                    list[i].Status ? Resources.Paid : Resources.Awaiting_payment,
                    list[i].Created,
                    list[i].Customer?.Name,
                    Currency.FormatCurrency(list[i].Total.ToString()),
                    list[i].Staff?.name,
                    list[i].Deleted
                );

                if (list[i].Status)
                {
                    dgvDeletedBill.Rows[dgvDeletedBill.RowCount - 1].Cells[1].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    dgvDeletedBill.Rows[dgvDeletedBill.RowCount - 1].Cells[1].Style.BackColor = Color.BurlyWood;
                }
            }
        }

        private void btnRestoreAllBill_Click(object sender, EventArgs e)
        {
            if (numRecord == 0)
            {
                CustomMessageBox.ShowWarning("Không có hoá đơn nào để khôi phục");
                return;
            }
            try
            {
                var result = CustomMessageBox.ShowQuestion("Bạn có muốn khôi phục tất cả hoá đơn không?");
                if (result != DialogResult.Yes)
                {
                    return;
                }

                var state = billBUS.RestoreAll();
                if (state == Predefined.SUCCESS)
                {
                    CustomMessageBox.ShowSuccess("Khôi phục tất cả hoá đơn thành công");
                    refreshBillForm();
                    DeletedBillDialog_Load(sender, e);
                }
                else
                {
                    CustomMessageBox.ShowError("Có lỗi xảy ra khi khôi phục tất cả hoá đơn");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (dgvDeletedBill.SelectedRows.Count == 0)
            {
                CustomMessageBox.ShowWarning("Vui lòng chọn hoá đơn cần khôi phục");
                return;
            }
            try
            {
                var result = CustomMessageBox.ShowQuestion("Bạn có muốn khôi phục hoá đơn này không?");
                if (result != DialogResult.Yes)
                {
                    return;
                }

                var id = dgvDeletedBill.SelectedRows[0].Cells[0].Value.ToString();
                var state = billBUS.Restore(id);
                if (state == Predefined.SUCCESS)
                {
                    CustomMessageBox.ShowSuccess("Khôi phục hoá đơn thành công");
                    refreshBillForm();
                    DeletedBillDialog_Load(sender, e);
                }
                else
                {
                    CustomMessageBox.ShowError("Có lỗi xảy ra khi khôi phục hoá đơn");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDeletedBill.SelectedRows.Count == 0)
            {
                CustomMessageBox.ShowWarning("Vui lòng chọn hoá đơn cần xóa");
                return;
            }
            try
            {
                var result = CustomMessageBox.ShowQuestion("Bạn có muốn xóa hoá đơn này không?");
                if (result != DialogResult.Yes)
                {
                    return;
                }

                var id = dgvDeletedBill.SelectedRows[0].Cells[0].Value.ToString();
                var state = billBUS.ForceDelete(id);
                if (state == Predefined.SUCCESS)
                {
                    CustomMessageBox.ShowSuccess("Xóa hoá đơn thành công");
                    refreshBillForm();
                    DeletedBillDialog_Load(sender, e);
                }
                else
                {
                    CustomMessageBox.ShowError("Có lỗi xảy ra khi xóa hoá đơn");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (numRecord == 0)
            {
                CustomMessageBox.ShowWarning("Không có hoá đơn nào để xóa");
                return;
            }
            try
            {
                var result = CustomMessageBox.ShowQuestion("Bạn có muốn xóa tất cả hoá đơn không?");
                if (result != DialogResult.Yes)
                {
                    return;
                }

                var state = billBUS.ForceDeleteAll();
                if (state == Predefined.SUCCESS)
                {
                    CustomMessageBox.ShowSuccess("Xóa tất cả hoá đơn thành công");
                    refreshBillForm();
                    DeletedBillDialog_Load(sender, e);
                }
                else
                {
                    CustomMessageBox.ShowError("Có lỗi xảy ra khi xóa tất cả hoá đơn");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }
    }
}
