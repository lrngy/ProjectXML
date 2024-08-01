using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using QPharma.GUI;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma
{
    public partial class ChiTietChi : BaseForm
    {
        private readonly string path = Config.getXMLPath("pos_bills");
        private XmlElement pos_bills;
        private XmlDocument xmlDocument;

        public ChiTietChi()
        {
            InitializeComponent();
            tbSoTienChi.KeyPress += tbSoTienChi_KeyPress;
        }

        public event EventHandler FormClosedEvent;

        public void ReturnItem(string maPChi)
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            pos_bills = xmlDocument.DocumentElement;
            var pos_bill_list = pos_bills.SelectNodes("/pos_bills/pos_bill");
            foreach (XmlNode pos_bill_node in pos_bill_list)
            {
                var maPChiValue = pos_bill_node.SelectSingleNode("pos_bill_id").InnerText;
                if (maPChi.Equals(maPChiValue))
                {
                    tbMaPChi.Text = maPChiValue;
                    tbMaPChi.Enabled = false;
                    tbSoTienChi.Text = pos_bill_node.SelectSingleNode("pos_bill_receive").InnerText;
                    tbMaPhieuThu.Text = pos_bill_node.SelectSingleNode("finance_bill_id").InnerText;
                    tbIDKh.Text = pos_bill_node.SelectSingleNode("customer_id").InnerText;
                    tbIDKho.Text = pos_bill_node.SelectSingleNode("warehouse_bill_id").InnerText;
                    tbIDnvChi.Text = pos_bill_node.SelectSingleNode("staff_id").InnerText;
                    tbIDnvChi.Enabled = false;
                    var check = pos_bill_node.SelectSingleNode("pos_is_sell_bill").InnerText.Trim();
                    if (check.Equals("paid"))
                        rbtnDTTChi.Checked = true;
                    else rbtnCTTChi.Checked = true;
                    dateTPChi.Value = DateTime.ParseExact(pos_bill_node.SelectSingleNode("pos_bill_time").InnerText,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
        }

        private void ChiTietChi_Load(object sender, EventArgs e)
        {
        }

        private void btnChi_Click(object sender, EventArgs e)
        {
            if (tbMaPChi.Text == "" || tbSoTienChi.Text == "" || tbIDKh.Text == "" || tbIDnvChi.Text == "" ||
                tbIDKho.Text == "") MessageBox.Show(Resources.Please_enter_complete_info);

            xmlDocument.Load(path);
            pos_bills = xmlDocument.DocumentElement;
            var maPChi = tbMaPChi.Text.Trim();

            XmlNode pos_bill_node_new = xmlDocument.CreateElement("pos_bill");

            var pos_bill_id = xmlDocument.CreateElement("pos_bill_id");
            pos_bill_id.InnerText = tbMaPChi.Text.Trim();

            var pos_bill_time = xmlDocument.CreateElement("pos_bill_time");
            var datestring = dateTPChi.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            pos_bill_time.InnerText = datestring;

            var pos_bill_receive = xmlDocument.CreateElement("pos_bill_receive");
            pos_bill_receive.InnerText = tbSoTienChi.Text.Trim();

            var finance_bill_id = xmlDocument.CreateElement("finance_bill_id");
            finance_bill_id.InnerText = tbMaPhieuThu.Text.Trim();

            var pos_is_sell_bill = xmlDocument.CreateElement("pos_is_sell_bill");
            if (rbtnDTTChi.Checked)
                pos_is_sell_bill.InnerText = "paid";
            else pos_is_sell_bill.InnerText = "unpaid";

            var customer_id = xmlDocument.CreateElement("customer_id");
            customer_id.InnerText = tbIDKh.Text.Trim();

            var staff_id = xmlDocument.CreateElement("staff_id");
            staff_id.InnerText = tbIDnvChi.Text.Trim();

            var warehouse_bill_id = xmlDocument.CreateElement("warehouse_bill_id");
            warehouse_bill_id.InnerText = tbIDKho.Text.Trim();

            pos_bill_node_new.AppendChild(pos_bill_id);
            pos_bill_node_new.AppendChild(pos_bill_time);
            pos_bill_node_new.AppendChild(pos_bill_receive);
            pos_bill_node_new.AppendChild(finance_bill_id);
            pos_bill_node_new.AppendChild(pos_is_sell_bill);
            pos_bill_node_new.AppendChild(customer_id);
            pos_bill_node_new.AppendChild(staff_id);
            pos_bill_node_new.AppendChild(warehouse_bill_id);

            var pos_bill_node_old = pos_bills.SelectSingleNode("/pos_bills");
            var pos_bill_node_old_list = pos_bill_node_old.SelectNodes("/pos_bills/pos_bill");
            foreach (XmlNode node in pos_bill_node_old_list)
                if (node.SelectSingleNode("pos_bill_id").InnerText.Equals(maPChi))
                {
                    pos_bills.ReplaceChild(pos_bill_node_new, node);
                    MessageBox.Show("Cập nhật thành công");
                }

            xmlDocument.Save(path);
            Close();
        }

        private void ChiTietChi_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void tbSoTienChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}