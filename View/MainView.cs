using ProjectXML.Model;
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
        User user {  get; set; }
        public MainView(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnQlyThuoc_Click(object sender, EventArgs e)
        {

        }
    }
}
