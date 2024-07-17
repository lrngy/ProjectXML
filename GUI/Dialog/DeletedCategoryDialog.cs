using System;
using System.Windows.Forms;
using ProjectXML.BUS;
using ProjectXML.Util;

namespace ProjectXML.GUI.Dialog
{
    public partial class DeletedCategoryDialog : Form
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
                    CustomMessageBox.ShowError("Mã thể loại không tồn tại");
                else
                    CustomMessageBox.ShowError("Khôi phục thất bại");
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn xóa vĩnh viễn thể loại này?");
            if (confirmResult == DialogResult.Yes)
                try
                {
                    var index = dgvDeletedTheLoai.CurrentRow.Index;
                    var maTheLoai = dgvDeletedTheLoai.Rows[index].Cells[1].Value.ToString();
                    var state = categoryController.ForceDelete(maTheLoai);
                    if (state == Predefined.SUCCESS)
                    {
                        DeletedCategory_Show();
                        refreshDeletedCategory();
                        return;
                    }

                    if (state == Predefined.ID_NOT_EXIST)
                        CustomMessageBox.ShowError("Mã thể loại không tồn tại");
                    else
                        CustomMessageBox.ShowError("Xóa thất bại");
                }
                catch (Exception)
                {
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var state = categoryController.RestoreAll();
                if (state == Predefined.FILE_NOT_FOUND)
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