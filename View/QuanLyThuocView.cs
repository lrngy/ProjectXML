using ProjectXML.Controller;
using ProjectXML.Model;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectXML.View
{
    public partial class QuanLyThuocView : Form
    {

        User user;
        CategoryController categoryController = new CategoryController();
        public QuanLyThuocView(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        int rowSelected = 0;


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int tabIndex = tabControl1.SelectedIndex;
            switch (tabIndex)
            {
                case 0:
                    break;
                case 1:
                    TheLoai_Load();
                    break;
                case 2:
                    break;

            }

        }
        public void ClearInput()
        {
            tbMaTheLoai.Text = "";
            tbTenTheLoai.Text = "";
            tbGhiChuTheLoai.Text = "";
            cbTrangThaiTheLoai.SelectedIndex = 0;
        }

        private void TheLoai_Load()
        {
            int i = 0;
            ClearInput();
            dgvTheLoai.Rows.Clear();
            CategoryController categoryController = new CategoryController();
            List<Category> categoryList = categoryController.LoadData();
            foreach (Category category in categoryList)
            {
                if(!category.deleted.Equals(""))
                {
                    Debug.WriteLine("Deleted: " + category.deleted);
                    continue;
                }
                dgvTheLoai.Rows.Add(++i, category.id, category.name, category.note, category.status ? "Khả dụng" : "Không khả dụng", category.created, category.updated);
            }

            try
            {
                dgvTheLoai.Rows[rowSelected].Selected = true;
            } catch (Exception ex)
            {

            }
  

        }

        private void QuanLyThuocView_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            string maTheLoai = tbMaTheLoai.Text;
            string tenTheLoai = tbTenTheLoai.Text;
            string ghiChu = tbGhiChuTheLoai.Text;
            bool trangThai = cbTrangThaiTheLoai.SelectedIndex == 0 ? true : false;
            if (maTheLoai.Equals("") || tenTheLoai.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập mã thể loại");
                return;
            }

            if (tenTheLoai.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập tên thể loại");
                return;
            }
            Category category = new Category(maTheLoai, tenTheLoai, ghiChu, trangThai, CustomDateTime.GetNow(), "", "");
            int state = categoryController.Insert(category);

            if (state == Predefined.SUCCESS)
            {
                TheLoai_Load();
                return;
            }
            if (state == Predefined.ID_EXIST)
            {
                CustomMessageBox.ShowError("Mã thể loại đã tồn tại");
            }
            else
            {
                CustomMessageBox.ShowError("Thêm thất bại");
            }
        }

        private void btnSuaTheLoai_Click(object sender, EventArgs e)
        {
            string maTheLoai = tbMaTheLoai.Text;
            string tenTheLoai = tbTenTheLoai.Text;
            string ghiChu = tbGhiChuTheLoai.Text;
            bool trangThai = cbTrangThaiTheLoai.SelectedIndex == 0 ? true : false;
            string created = dgvTheLoai.Rows[rowSelected].Cells[5].Value.ToString();
            if (maTheLoai.Equals(""))
            {
                CustomMessageBox.ShowError("Vui lòng nhập mã thể loại");
                return;
            }

            Category category = new Category(maTheLoai, tenTheLoai, ghiChu, trangThai, created, CustomDateTime.GetNow(), "");
            int state = categoryController.Update(category);

            if (state == Predefined.SUCCESS)
            {
                TheLoai_Load();
                return;
            }

            if (state == Predefined.ID_NOT_EXIST)
            {
                CustomMessageBox.ShowError("Mã thể loại không tồn tại");
            }
            else
            {
                CustomMessageBox.ShowError("Sửa thất bại");
            }


        }

        private void dgvTheLoai_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {


        }

        private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int index = dgvTheLoai.CurrentRow.Index;
                tbMaTheLoai.Text = dgvTheLoai.Rows[index].Cells[1].Value.ToString();
                tbTenTheLoai.Text = dgvTheLoai.Rows[index].Cells[2].Value.ToString();
                tbGhiChuTheLoai.Text = dgvTheLoai.Rows[index].Cells[3].Value.ToString();
                cbTrangThaiTheLoai.SelectedIndex = dgvTheLoai.Rows[index].Cells[4].Value.ToString().Equals("Khả dụng") ? 0 : 1;
            }
            catch (Exception ex)
            {
                ClearInput();
            }
        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTheLoai_SelectionChanged(sender, e);
        }

        private void btnXoaTheLoai_Click(object sender, EventArgs e)
        {

            string maTheLoai = tbMaTheLoai.Text;
            if (maTheLoai.Equals(""))
            {
                CustomMessageBox.ShowError("Mã thể loại không hợp lệ");
                return;
            }
            int state = categoryController.Delete(maTheLoai);
            if (state == Predefined.SUCCESS)
            {
                TheLoai_Load();
                return;
            }
            else if (state == Predefined.ID_NOT_EXIST)
            {
                CustomMessageBox.ShowError("Mã thể loại không tồn tại");
            }
            else
            {
                CustomMessageBox.ShowError("Xóa thất bại");
            }
        }

        private void btnLuuTruTheLoai_Click(object sender, EventArgs e)
        {
            DeletedCategory deletedCategory = new DeletedCategory(categoryController);
            deletedCategory.refreshDeletedCategory += TheLoai_Load;
            deletedCategory.ShowDialog();
        }
    }
}


