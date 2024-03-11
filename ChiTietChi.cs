using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProjectXML
{
    public partial class ChiTietChi : Form
    {
        string path = Config.getXMLPath("pos_bills");
        XmlDocument xmlDocument;
        XmlElement pos_bills;
        public event EventHandler FormClosedEvent;
        public ChiTietChi()
        {
            InitializeComponent();
        }
        public void ReturnItem(string maPChi)
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            pos_bills = xmlDocument.DocumentElement;
            XmlNodeList pos_bill_list = pos_bills.SelectNodes("/pos_bills/pos_bill");
            foreach (XmlNode pos_bill_node in pos_bill_list)
            {
                string maPChiValue = pos_bill_node.SelectSingleNode("pos_bill_id").InnerText;
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
                    string check = pos_bill_node.SelectSingleNode("pos_is_sell_bill").InnerText.Trim();
                    if (check.Equals("paid"))
                    {
                        rbtnDTTChi.Checked = true;
                    }
                    else rbtnCTTChi.Checked = true;
                    dateTPChi.Value = DateTime.ParseExact(pos_bill_node.SelectSingleNode("pos_bill_time").InnerText, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
        }
        private void ChiTietChi_Load(object sender, EventArgs e)
        {
        }
        private void btnChi_Click(object sender, EventArgs e)
        {
            if (tbMaPChi.Text == "" || tbSoTienChi.Text == "" || tbIDKh.Text == "" || tbIDnvChi.Text == "" || tbIDKho.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }

            xmlDocument.Load(path);
            pos_bills = xmlDocument.DocumentElement;
            string maPChi = tbMaPChi.Text.ToString().Trim();

            XmlNode pos_bill_node_new = xmlDocument.CreateElement("pos_bill");

            XmlElement pos_bill_id = xmlDocument.CreateElement("pos_bill_id");
            pos_bill_id.InnerText = tbMaPChi.Text.Trim();

            XmlElement pos_bill_time = xmlDocument.CreateElement("pos_bill_time");
            var datestring = dateTPChi.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            pos_bill_time.InnerText = datestring;

            XmlElement pos_bill_receive = xmlDocument.CreateElement("pos_bill_receive");
            pos_bill_receive.InnerText = tbSoTienChi.Text.Trim();

            XmlElement finance_bill_id = xmlDocument.CreateElement("finance_bill_id");
            finance_bill_id.InnerText = tbMaPhieuThu.Text.Trim();

            XmlElement pos_is_sell_bill = xmlDocument.CreateElement("pos_is_sell_bill");
            if (rbtnDTTChi.Checked)
            {
                pos_is_sell_bill.InnerText = "paid";
            }
            else pos_is_sell_bill.InnerText = "unpaid";

            XmlElement customer_id = xmlDocument.CreateElement("customer_id");
            customer_id.InnerText = tbIDKh.Text.Trim();

            XmlElement staff_id = xmlDocument.CreateElement("staff_id");
            staff_id.InnerText = tbIDnvChi.Text.Trim();

            XmlElement warehouse_bill_id = xmlDocument.CreateElement("warehouse_bill_id");
            warehouse_bill_id.InnerText = tbIDKho.Text.Trim();

            pos_bill_node_new.AppendChild(pos_bill_id);
            pos_bill_node_new.AppendChild(pos_bill_time);
            pos_bill_node_new.AppendChild(pos_bill_receive);
            pos_bill_node_new.AppendChild(finance_bill_id);
            pos_bill_node_new.AppendChild(pos_is_sell_bill);
            pos_bill_node_new.AppendChild(customer_id);
            pos_bill_node_new.AppendChild(staff_id);
            pos_bill_node_new.AppendChild(warehouse_bill_id);

            XmlNode pos_bill_node_old = pos_bills.SelectSingleNode("/pos_bills");
            XmlNodeList pos_bill_node_old_list = pos_bill_node_old.SelectNodes("/pos_bills/pos_bill");
            foreach (XmlNode node in pos_bill_node_old_list)
            {
                if (node.SelectSingleNode("pos_bill_id").InnerText.ToString().Equals(maPChi))
                {
                    pos_bills.ReplaceChild(pos_bill_node_new, node);
                    MessageBox.Show("Cập nhật thành công");
                }
            }
            xmlDocument.Save(path);
            this.Close();
  
          }

        private void ChiTietChi_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
