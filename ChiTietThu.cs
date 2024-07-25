using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;
using QPharma.GUI;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma
{
    public partial class ChiTietThu : BaseForm
    {
        private readonly string path = Config.getXMLPath("finance_bills");
        private XmlElement finance_bills;
        private XmlDocument xmlDocument;

        public ChiTietThu()
        {
            InitializeComponent();
            tbSoTienThu2.KeyPress += tbSoTienThu2_KeyPress;
        }

        public event EventHandler FormClosedEvent;

        public void ReturnItem(string maPThu)
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            finance_bills = xmlDocument.DocumentElement;
            var finance_bill_list = finance_bills.SelectNodes("/finance_bills/finance_bill");
            foreach (XmlNode finance_bill_node in finance_bill_list)
            {
                var maPThuValue = finance_bill_node.SelectSingleNode("finance_bill_id").InnerText;
                if (maPThu.Equals(maPThuValue))
                {
                    tbMaPThu2.Text = maPThuValue;
                    tbMaPThu2.Enabled = false;
                    tbSoTienThu2.Text = finance_bill_node.SelectSingleNode("finance_bill_change").InnerText;
                    tbChiTietThu2.Text = finance_bill_node.SelectSingleNode("fibnance_bill_content").InnerText;
                    tbIDnvThu2.Text = finance_bill_node.SelectSingleNode("staff_id").InnerText;
                    tbIDnvThu2.Enabled = false;
                    var check = finance_bill_node.SelectSingleNode("finance_is_spend_bill").InnerText.Trim();
                    if (check.Equals("paid"))
                        rbtnDTTThu2.Checked = true;
                    else rbtnCTTThu2.Checked = true;
                    dateTPThu2.Value =
                        DateTime.ParseExact(finance_bill_node.SelectSingleNode("finance_bill_time").InnerText,
                            "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
        }

        private void ChiTietThu_Load(object sender, EventArgs e)
        {
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (tbMaPThu2.Text == "" || tbSoTienThu2.Text == "" || tbChiTietThu2.Text == "" || tbIDnvThu2.Text == "")
                MessageBox.Show(Resources.Please_enter_complete_info);

            xmlDocument.Load(path);
            finance_bills = xmlDocument.DocumentElement;
            var maPThu = tbMaPThu2.Text.Trim();

            XmlNode finance_bill_node_new = xmlDocument.CreateElement("finance_bill");

            var finance_bill_id = xmlDocument.CreateElement("finance_bill_id");
            finance_bill_id.InnerText = tbMaPThu2.Text.Trim();

            var finance_bill_time = xmlDocument.CreateElement("finance_bill_time");
            var datestring = dateTPThu2.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            finance_bill_time.InnerText = datestring;

            var finance_bill_change = xmlDocument.CreateElement("finance_bill_change");
            finance_bill_change.InnerText = tbSoTienThu2.Text.Trim();

            var finance_is_spend_bill = xmlDocument.CreateElement("finance_is_spend_bill");
            if (rbtnDTTThu2.Checked)
                finance_is_spend_bill.InnerText = "paid";
            else finance_is_spend_bill.InnerText = "unpaid";

            var fibnance_bill_content = xmlDocument.CreateElement("fibnance_bill_content");
            fibnance_bill_content.InnerText = tbChiTietThu2.Text.Trim();

            var staff_id = xmlDocument.CreateElement("staff_id");
            staff_id.InnerText = tbIDnvThu2.Text.Trim();

            finance_bill_node_new.AppendChild(finance_bill_id);
            finance_bill_node_new.AppendChild(finance_bill_time);
            finance_bill_node_new.AppendChild(finance_bill_change);
            finance_bill_node_new.AppendChild(finance_is_spend_bill);
            finance_bill_node_new.AppendChild(fibnance_bill_content);
            finance_bill_node_new.AppendChild(staff_id);

            var finance_bill_node_old = finance_bills.SelectSingleNode("/finance_bills");
            var finance_bill_node_old_list = finance_bill_node_old.SelectNodes("/finance_bills/finance_bill");
            foreach (XmlNode node in finance_bill_node_old_list)
                if (node.SelectSingleNode("finance_bill_id").InnerText.Equals(maPThu))
                {
                    finance_bills.ReplaceChild(finance_bill_node_new, node);
                    MessageBox.Show("Cập nhật thành công");
                }

            xmlDocument.Save(path);
            Close();
        }

        private void ChiTietThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void tbSoTienThu2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}