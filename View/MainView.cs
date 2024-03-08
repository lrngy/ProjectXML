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
    public partial class MainView : Form
    {
        User user;
        QuanLyThuocView quanLyThuocView;
        public MainView(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnQlyThuoc_Click(object sender, EventArgs e)
        {
            if (user.staff.isSeller)
            {
                CustomMessageBox.ShowError("Bạn không có quyền truy cập chức năng này");
                return;
            }
            Show(ref quanLyThuocView, () => new QuanLyThuocView(user));
        }

        private void Show<T> (ref T form, Func<T> NewInstance) where T: Form
        {
            if (form == null || form.IsDisposed)
            {
                form = NewInstance();
                form.FormClosed += (s, args) => this.WindowState = FormWindowState.Normal;
            }
            form.Show();
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
