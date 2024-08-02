namespace QPharma.GUI.Dialog;

public partial class DeletedSupplierDialog : BaseForm
{
    private readonly Action<object, EventArgs> refreshSupplierDeletedForm;
    private readonly SupplierBUS supplierBus;

    public DeletedSupplierDialog(Action<object, EventArgs> refreshSupplierDeletedForm)
    {
        InitializeComponent();
        supplierBus = new SupplierBUS();
        this.refreshSupplierDeletedForm = refreshSupplierDeletedForm;
    }

    private void DeletedSupplierDialog_Load(object sender, EventArgs e)
    {
        GetAllAndShow();
    }

    private void GetAllAndShow()
    {
        var list = supplierBus.LoadData().Where(item => !item.deleted.Equals("")).ToList();
        ShowDeletedSupplier(list);
    }

    private void ShowDeletedSupplier(List<SupplierDTO> list)
    {
        try
        {
            dgvDeletedSupplier.Rows.Clear();
            BeginInvoke(() => { dgvDeletedSupplier.ClearSelection(); });
            for (var i = 0; i < list.Count; i++)
                dgvDeletedSupplier.Rows.Add(i + 1, list[i].id, list[i].name, list[i].phone, list[i].email, list[i].note,
                    list[i].status, list[i].created, list[i].updated, list[i].deleted);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void dgvDeletedSupplier_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex % 2 == 0)
            e.CellStyle.BackColor = Color.LightGray;
        else
            e.CellStyle.BackColor = Color.White;
    }

    private void btnForceDel_Click(object sender, EventArgs e)
    {
        try
        {
            var index = dgvDeletedSupplier.SelectedRows[0].Index;
            var confirm = CustomMessageBox.ShowQuestion(Resources.Are_you_sure_want_to_delete_this_supplier_);
            if (confirm == DialogResult.No) return;
            var supplierId = dgvDeletedSupplier.Rows[index].Cells[1].Value.ToString();
            var result = supplierBus.ForceDelete(supplierId);

            if (result == Predefined.SUCCESS)
            {
                GetAllAndShow();
                refreshSupplierDeletedForm(sender, e);
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

    private void btnRestore_Click(object sender, EventArgs e)
    {
        try
        {
            var index = dgvDeletedSupplier.SelectedRows[0].Index;
            var supplierId = dgvDeletedSupplier.Rows[index].Cells[1].Value.ToString();
            var result = supplierBus.Restore(supplierId);

            if (result == Predefined.SUCCESS)
            {
                GetAllAndShow();
                refreshSupplierDeletedForm(sender, e);
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

    private void btnRestoreAll_Click(object sender, EventArgs e)
    {
        try
        {
            var result = supplierBus.RestoreAll();

            if (result == Predefined.SUCCESS)
            {
                GetAllAndShow();
                refreshSupplierDeletedForm(sender, e);
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