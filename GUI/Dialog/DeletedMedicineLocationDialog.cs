using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QPharma.BUS;
using QPharma.DTO;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma.GUI.Dialog
{
    public partial class DeletedMedicineLocationDialog : BaseForm
    {
        private readonly MedicineLocationBUS medicineLocationBUS;
        private readonly Action<object, EventArgs> refreshMedicineLocationDeletedForm;
        public DeletedMedicineLocationDialog(Action<object, EventArgs> refreshMedicineLocationDeletedForm)
        {
            InitializeComponent();
            medicineLocationBUS = new MedicineLocationBUS();
            this.refreshMedicineLocationDeletedForm = refreshMedicineLocationDeletedForm;
        }

        private void DeletedMedicineLocationDialog_Load(object sender, EventArgs e)
        {
            GetAllAndShowData();
        }

        private void GetAllAndShowData()
        {
            var list = medicineLocationBUS.LoadData().Where(item => !item.deleted.Equals("")).ToList();
            HienThiViTriThuocDaXoa(list);
        }

        private void HienThiViTriThuocDaXoa(List<MedicineLocationDTO> list)
        {
            try
            {
                dgvDeletedViTriThuoc.Rows.Clear();
                BeginInvoke(new Action(() => { dgvDeletedViTriThuoc.ClearSelection(); }));
                for (int i = 0; i < list.Count; i++)
                {
                    dgvDeletedViTriThuoc.Rows.Add(i + 1, list[i].id, list[i].name, list[i].note, list[i].status, list[i].created, list[i].updated, list[i].deleted);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


        }

        private void dgvDeletedViTriThuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
                e.CellStyle.BackColor = Color.LightGray;
            else
                e.CellStyle.BackColor = Color.White;
        }

        private void btnDelDeletedLocation_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dgvDeletedViTriThuoc.SelectedRows[0].Index;
                var maViTri = dgvDeletedViTriThuoc.Rows[index].Cells[1].Value.ToString();
                var confirm = CustomMessageBox.ShowQuestion(Resources.Are_you_sure_want_to_delete_this_medicine_location_);
                if (confirm == DialogResult.No)
                {
                    return;
                }
                var result = medicineLocationBUS.ForceDelete(maViTri);

                if (result == Predefined.SUCCESS)
                {
                    GetAllAndShowData();
                    refreshMedicineLocationDeletedForm(sender, e);
                }
                else
                {
                    CustomMessageBox.ShowError(Resources.Delete_failed);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void btnRestoreAllDeletedLocation_Click(object sender, EventArgs e)
        {
            try
            {
                var result = medicineLocationBUS.RestoreAll();

                if (result == Predefined.SUCCESS)
                {
                    GetAllAndShowData();
                    refreshMedicineLocationDeletedForm(sender, e);
                }
                else
                {
                    CustomMessageBox.ShowError(Resources.Restore_failed);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnRestoreDeletedLocation_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dgvDeletedViTriThuoc.SelectedRows[0].Index;
                var maViTri = dgvDeletedViTriThuoc.Rows[index].Cells[1].Value.ToString();
                var result = medicineLocationBUS.Restore(maViTri);

                if (result == Predefined.SUCCESS)
                {
                    GetAllAndShowData();
                    refreshMedicineLocationDeletedForm(sender, e);
                }
                else
                {
                    CustomMessageBox.ShowError(Resources.Restore_failed);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
