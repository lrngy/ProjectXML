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
    public partial class DeletedCategoryDialog : Form
    {
        CategoryController categoryController;
        public delegate void RefreshDeletedCategory();
        public RefreshDeletedCategory refreshDeletedCategory;
        public DeletedCategoryDialog(CategoryController categoryController)
        {
            InitializeComponent();
            this.categoryController = categoryController;
        }

        public void DeletedCategory_Show()
        {
            dgvDeletedTheLoai.Rows.Clear();
            int i = 0;
            CategoryController categoryController = new CategoryController();
            List<Category> categoryList = categoryController.LoadData();
            foreach (Category category in categoryList)
            {
                if (category.deleted.Equals(""))
                {
                    continue;
                }
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
              
            } catch (Exception ex)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvDeletedTheLoai.CurrentRow.Index;
                string maTheLoai = dgvDeletedTheLoai.Rows[index].Cells[1].Value.ToString();
                int state = categoryController.Restore(maTheLoai);
                if (state == Predefined.SUCCESS)
                {
                    DeletedCategory_Show();
                    refreshDeletedCategory();
                    return;
                }
                if (state == Predefined.ID_NOT_EXIST)
                {
                    CustomMessageBox.ShowError("Mã thể loại không tồn tại");
                }
                else
                {
                    CustomMessageBox.ShowError("Khôi phục thất bại");
                }

            } catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = CustomMessageBox.ShowQuestion("Bạn có chắc chắn muốn xóa vĩnh viễn thể loại này?");
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int index = dgvDeletedTheLoai.CurrentRow.Index;
                    string maTheLoai = dgvDeletedTheLoai.Rows[index].Cells[1].Value.ToString();
                    int state = categoryController.ForceDelete(maTheLoai);
                    if (state == Predefined.SUCCESS)
                    {
                        DeletedCategory_Show();
                        refreshDeletedCategory();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int state = categoryController.RestoreAll();
                if (state == Predefined.FILE_NOT_FOUND)
                {
                    CustomMessageBox.ShowError("Khôi phục thất bại");
                    return;
                }
                    DeletedCategory_Show();
                    refreshDeletedCategory();


            }
            catch (Exception ex)
            {
            }
        }
    }
}
