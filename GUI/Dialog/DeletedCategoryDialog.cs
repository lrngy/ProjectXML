using System;
using System.Diagnostics;
using System.Windows.Forms;
using QPharma.BUS;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma.GUI.Dialog
{
    public partial class DeletedCategoryDialog : BaseForm
    {
        public delegate void RefreshDeletedCategory();

        private readonly CategoryBUS categoryController;
        public RefreshDeletedCategory refreshDeletedCategory;

        public DeletedCategoryDialog(CategoryBUS categoryController)
        {
            InitializeComponent();
            this.categoryController = categoryController;
        }

        public void DeletedCategory_Show()
        {
            dgvDeletedTheLoai.Rows.Clear();
            var i = 0;
            var categoryController = new CategoryBUS();
            var categoryList = categoryController.LoadData();

            foreach (var category in categoryList)
            {
                if (category.deleted.Equals("")) continue;
                dgvDeletedTheLoai.Rows.Add(++i, category.id, category.name, category.deleted);
            }
        }

        private void DeletedCategory_Load(object sender, EventArgs e)
        {
            DeletedCategory_Show();
        }

        private void dgvDeletedTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dgvDeletedTheLoai.CurrentRow.Index;
                var maTheLoai = dgvDeletedTheLoai.Rows[index].Cells[1].Value.ToString();
                var state = categoryController.Restore(maTheLoai);
                if (state == Predefined.SUCCESS)
                {
                    DeletedCategory_Show();
                    refreshDeletedCategory();
                    return;
                }

                if (state == Predefined.ID_NOT_EXIST)
                    CustomMessageBox.ShowError(Resources.Category_ID_does_not_exist);
                else
                    CustomMessageBox.ShowError("Khôi phục thất bại");
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var maTheLoai = dgvDeletedTheLoai.SelectedRows[0].Cells[1].Value.ToString();
                var confirmResult = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn xóa vĩnh viễn thể loại này?");
                if (confirmResult == DialogResult.Yes)
                {
                    var state = categoryController.ForceDelete(maTheLoai);
                    if (state == Predefined.SUCCESS)
                    {
                        DeletedCategory_Show();
                        refreshDeletedCategory();
                        return;
                    }

                    if (state == Predefined.ID_NOT_EXIST)
                        CustomMessageBox.ShowError(Resources.Category_ID_does_not_exist);
                    else
                        CustomMessageBox.ShowError(Resources.Delete_failed);
                }
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
                var state = categoryController.RestoreAll();
                if (state == Predefined.ERROR)
                {
                    CustomMessageBox.ShowError("Khôi phục thất bại");
                    return;
                }

                DeletedCategory_Show();
                refreshDeletedCategory();
            }
            catch (Exception)
            {
            }
        }
    }
}