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
    public partial class ChiTietThu : Form
    {
        string path = Config.getXMLPath("finance_bills");
        XmlDocument xmlDocument;
        XmlElement finance_bills;
        public event EventHandler FormClosedEvent;
        public ChiTietThu()
        {
            InitializeComponent();
        }
        public void ReturnItem(string maPThu)
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            finance_bills = xmlDocument.DocumentElement;
            XmlNodeList finance_bill_list = finance_bills.SelectNodes("/finance_bills/finance_bill");
            foreach(XmlNode finance_bill_node in finance_bill_list)
            {
                string maPThuValue = finance_bill_node.SelectSingleNode("finance_bill_id").InnerText;    
                if(maPThu.Equals(maPThuValue))
                {
                   
                    tbMaPThu2.Text = maPThuValue;
                    tbMaPThu2.Enabled = false;
                    tbSoTienThu2.Text = finance_bill_node.SelectSingleNode("finance_bill_change").InnerText;
                    tbChiTietThu2.Text = finance_bill_node.SelectSingleNode("fibnance_bill_content").InnerText;
                    tbIDnvThu2.Text = finance_bill_node.SelectSingleNode("staff_id").InnerText;
                    string check = finance_bill_node.SelectSingleNode("finance_is_spend_bill").InnerText.Trim();
                    if(check.Equals("paid"))
                    {
                        rbtnDTTThu2.Checked = true;
                    } else rbtnCTTThu2.Checked = true;
                    dateTPThu2.Value = DateTime.ParseExact(finance_bill_node.SelectSingleNode("finance_bill_time").InnerText, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
            }
        }
        private void ChiTietThu_Load(object sender, EventArgs e)
        {
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (tbMaPThu2.Text == "" || tbSoTienThu2.Text == "" || tbChiTietThu2.Text == "" || tbIDnvThu2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }

            xmlDocument.Load(path);
            finance_bills = xmlDocument.DocumentElement;
            string maPThu = tbMaPThu2.Text.ToString().Trim();
            
            XmlNode finance_bill_node_new = xmlDocument.CreateElement("finance_bill");

            XmlElement finance_bill_id = xmlDocument.CreateElement("finance_bill_id");
            finance_bill_id.InnerText = tbMaPThu2.Text.Trim();

            XmlElement finance_bill_time = xmlDocument.CreateElement("finance_bill_time");
            var datestring = dateTPThu2.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            finance_bill_time.InnerText = datestring;

            XmlElement finance_bill_change = xmlDocument.CreateElement("finance_bill_change");
            finance_bill_change.InnerText = tbSoTienThu2.Text.Trim();

            XmlElement finance_is_spend_bill = xmlDocument.CreateElement("finance_is_spend_bill");
            if (rbtnDTTThu2.Checked)
            {
                finance_is_spend_bill.InnerText = "paid";
            }
            else finance_is_spend_bill.InnerText = "unpaid";

            XmlElement fibnance_bill_content = xmlDocument.CreateElement("fibnance_bill_content");
            fibnance_bill_content.InnerText = tbChiTietThu2.Text.Trim();

            XmlElement staff_id = xmlDocument.CreateElement("staff_id");
            staff_id.InnerText = tbIDnvThu2.Text.Trim();

            finance_bill_node_new.AppendChild(finance_bill_id);
            finance_bill_node_new.AppendChild(finance_bill_time);
            finance_bill_node_new.AppendChild(finance_bill_change);
            finance_bill_node_new.AppendChild(finance_is_spend_bill);
            finance_bill_node_new.AppendChild(fibnance_bill_content);
            finance_bill_node_new.AppendChild(staff_id);

            XmlNode finance_bill_node_old = finance_bills.SelectSingleNode("/finance_bills");
            XmlNodeList finance_bill_node_old_list = finance_bill_node_old.SelectNodes("/finance_bills/finance_bill");
            foreach (XmlNode node in finance_bill_node_old_list)
            {
                if (node.SelectSingleNode("finance_bill_id").InnerText.ToString().Equals(maPThu))
                {
                    finance_bills.ReplaceChild(finance_bill_node_new, node);
                    MessageBox.Show("Cập nhật thành công");
                }
            }
            xmlDocument.Save(path);
            this.Close();
        }

        private void ChiTietThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
