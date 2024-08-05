namespace QPharma.GUI.Dialog;

public partial class DeletedMedicineDialog : BaseForm
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
        var medicineList = medicineController.LoadData().Where(item => !item.deleted.Equals("")).ToList();
        foreach (var medicine in medicineList)
            dgvDeletedMedicine.Rows.Add(
                ++i, medicine.id, medicine.name, medicine.quantity, medicine.price_out,
                medicine.category == null ? Resources.Unknown : $"{medicine.category.id}-{medicine.category.name}",
                medicine.type ? Resources.Prescription_drug : Resources.Unprescription_drug,
                medicine.unit, medicine.mfgDate, medicine.expDate,
                medicine.supplier == null ? Resources.Unknown : $"{medicine.supplier.id}-{medicine.supplier.name}",
                medicine.price_in,
                medicine.location == null ? Resources.Unknown : $"{medicine.location.id} - {medicine.location.name}",
                medicine.description,
                medicine.created,
                medicine.updated,
                medicine.deleted);
    }

    private void DeletedMedicine_Load(object sender, EventArgs e)
    {
        DeletedMedicine_Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            var index = dgvDeletedMedicine.SelectedRows[0].Index;
            var maThuoc = dgvDeletedMedicine.Rows[index].Cells[1].Value.ToString();
            var state = medicineController.Restore(maThuoc);
            if (state == Predefined.SUCCESS)
            {
                DeletedMedicine_Show();
                refreshDeletedMedicine();
                CustomMessageBox.ShowSuccess(string.Format(Resources.Restore_medicine_id_successfully, maThuoc));
                return;
            }

            if (state == Predefined.ID_NOT_EXIST)
                CustomMessageBox.ShowError(Resources.Medicine_ID_is_not_exist);
            else
                CustomMessageBox.ShowError(Resources.Restore_failed);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        try
        {
            var state = medicineController.RestoreAll();
            if (state == Predefined.ERROR)
            {
                CustomMessageBox.ShowError(Resources.Restore_failed);
                return;
            }

            DeletedMedicine_Show();
            refreshDeletedMedicine();
            CustomMessageBox.ShowSuccess(Resources.Restore_all_medicines_successfully);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            var index = dgvDeletedMedicine.SelectedRows[0].Index;
            var maThuoc = dgvDeletedMedicine.Rows[index].Cells[1].Value.ToString();
            var confirmResult =
                CustomMessageBox.ShowQuestion(Resources.Are_you_sure_you_want_to_permanently_remove_this_medication_);
            if (confirmResult == DialogResult.No) return;
            var state = medicineController.ForceDelete(maThuoc);
            if (state == Predefined.SUCCESS)
            {
                DeletedMedicine_Show();
                refreshDeletedMedicine();
                CustomMessageBox.ShowSuccess(string.Format(Resources.Delete_medicine_id_successfully, maThuoc));
                return;
            }

            if (state == Predefined.ID_NOT_EXIST)
                CustomMessageBox.ShowError(Resources.Category_ID_does_not_exist);
            else
                CustomMessageBox.ShowError(Resources.Delete_failed);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception);
        }
    }

    private void dgvDeletedMedicine_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex % 2 == 0)
            e.CellStyle.BackColor = Color.LightGray;
        else
            e.CellStyle.BackColor = Color.White;
    }
}