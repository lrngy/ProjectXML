using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Linq;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma.GUI
{
    public partial class QuanLyTaiChinhGUI : BaseForm
    {
        private readonly XmlDocument docChi = Config.getDoc("pos_bills");
        private readonly XmlDocument docNhanVien = Config.getDoc("staffs");
        private readonly XmlDocument docThu = Config.getDoc("finance_bills");
        private readonly Dictionary<string, decimal> monthlyRevenueChi = new Dictionary<string, decimal>();
        private readonly Dictionary<string, decimal> monthlyRevenueThu = new Dictionary<string, decimal>();
        private readonly string pathChi = Config.getXMLPath("pos_bills");
        private readonly string pathThu = Config.getXMLPath("finance_bills");
        private DataTable dataTableThu, dataTableChi;

        private XmlElement finance_bills;
        private string maPhieuChiClick;

        private string maPhieuThuClick;
        private XmlElement pos_bills;


        public QuanLyTaiChinhGUI()
        {
            InitializeComponent();
            tbSoTienThu.KeyPress += tbSoTienThu_KeyPress;
            tbSoTienChi.KeyPress += tbSoTienChi_KeyPress;
        }

        private void QuanLyTaiChinhFrm_Load(object sender, EventArgs e)
        {
            HienThiThu(dGVThu);
            HienThiChi(dGVChi);
            HienThiChartThu();
            HienThiChartChi();
        }

        private void HienThiChartChi()
        {
            //monthlyRevenue = new Dictionary<string, decimal>();
            chartThongKeChi.ChartAreas[0].AxisX.Interval = 1;
            chartThongKeChi.ChartAreas[0].AxisX.Title = "Tháng - Năm";
            chartThongKeChi.ChartAreas[0].AxisY.Title = "Tiền trong tháng";
            chartThongKeChi.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            LoadDataFromXMLChi();
        }

        private void LoadDataFromXMLChi()
        {
            dataTableChi = new DataTable();
            dataTableChi.Columns.Add("pos_bill_id");
            dataTableChi.Columns.Add("pos_bill_time");
            dataTableChi.Columns.Add("pos_bill_receive", typeof(decimal));
            dataTableChi.Columns.Add("staff_id");
            dataTableChi.Columns.Add("pos_is_sell_bill");
            dataTableChi.Columns.Add("warehouse_bill_id");
            dataTableChi.Columns.Add("finance_bill_id");
            dataTableChi.Columns.Add("customer_id");

            var doc = XDocument.Load(pathChi);
            foreach (var element in doc.Descendants("pos_bill"))
            {
                var status = element.Element("pos_is_sell_bill").Value;
                if (status == "paid")
                    dataTableChi.Rows.Add(
                        element.Element("pos_bill_id").Value,
                        element.Element("pos_bill_time").Value,
                        decimal.Parse(element.Element("pos_bill_receive").Value), // Parse as decimal
                        element.Element("staff_id").Value,
                        element.Element("pos_is_sell_bill").Value,
                        element.Element("warehouse_bill_id").Value,
                        element.Element("finance_bill_id").Value,
                        element.Element("customer_id").Value
                    );
            }

            CalculateMonthlyRevenueChi();
            UpdateChartChi();
        }

        private void CalculateMonthlyRevenueChi()
        {
            foreach (DataRow row in dataTableChi.Rows)
            {
                var date = DateTime.ParseExact(row["pos_bill_time"].ToString(), "dd/MM/yyyy", null);
                var monthYear = date.ToString("MM/yyyy");

                if (!monthlyRevenueChi.ContainsKey(monthYear)) monthlyRevenueChi[monthYear] = 0;

                monthlyRevenueChi[monthYear] += Convert.ToDecimal(row["pos_bill_receive"]);
            }
        }

        private void UpdateChartChi()
        {
            chartThongKeChi.Series.Clear();
            var series = new Series
            {
                Name = "Tổng chi tháng",
                ChartType = SeriesChartType.Column
            };
            foreach (var entry in monthlyRevenueChi) series.Points.AddXY(entry.Key, entry.Value);
            chartThongKeChi.Series.Add(series);
        }


        private void HienThiChartThu()
        {
            //monthlyRevenue = new Dictionary<string, decimal>();
            chartThongKeThu.ChartAreas[0].AxisX.Interval = 1;
            chartThongKeThu.ChartAreas[0].AxisX.Title = "Tháng - Năm";
            chartThongKeThu.ChartAreas[0].AxisY.Title = "Tiền trong tháng";
            chartThongKeThu.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            LoadDataFromXMLThu();
        }

        private void LoadDataFromXMLThu()
        {
            dataTableThu = new DataTable();
            dataTableThu.Columns.Add("finance_bill_id");
            dataTableThu.Columns.Add("finance_bill_time");
            dataTableThu.Columns.Add("finance_bill_change", typeof(decimal));
            dataTableThu.Columns.Add("finance_is_spend_bill");
            dataTableThu.Columns.Add("fibnance_bill_content");
            dataTableThu.Columns.Add("staff_id");

            var doc = XDocument.Load(pathThu);
            foreach (var element in doc.Descendants("finance_bill"))
            {
                var status = element.Element("finance_is_spend_bill").Value;
                if (status == "paid")
                    dataTableThu.Rows.Add(
                        element.Element("finance_bill_id").Value,
                        element.Element("finance_bill_time").Value,
                        decimal.Parse(element.Element("finance_bill_change").Value),
                        element.Element("finance_is_spend_bill").Value,
                        element.Element("fibnance_bill_content").Value,
                        element.Element("staff_id").Value
                    );
            }

            CalculateMonthlyRevenueThu();
            UpdateChartThu();
        }

        private void CalculateMonthlyRevenueThu()
        {
            foreach (DataRow row in dataTableThu.Rows)
            {
                var date = DateTime.ParseExact(row["finance_bill_time"].ToString(), "dd/MM/yyyy", null);
                var monthYear = date.ToString("MM/yyyy");

                if (!monthlyRevenueThu.ContainsKey(monthYear)) monthlyRevenueThu[monthYear] = 0;

                monthlyRevenueThu[monthYear] += Convert.ToDecimal(row["finance_bill_change"]);
            }
        }

        private void UpdateChartThu()
        {
            chartThongKeThu.Series.Clear();
            var series = new Series
            {
                Name = "Lợi nhuận tháng",
                ChartType = SeriesChartType.Column
            };
            foreach (var entry in monthlyRevenueThu) series.Points.AddXY(entry.Key, entry.Value);
            chartThongKeThu.Series.Add(series);
        }

        private void HienThiThu(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Refresh();
            var finance_bills = docThu.SelectSingleNode("/finance_bills");
            var finance_bill = finance_bills.SelectNodes("/finance_bills/finance_bill");
            var sd = 0;
            foreach (XmlNode node in finance_bill)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = node.SelectSingleNode("finance_bill_id").InnerText;
                dgv.Rows[sd].Cells[1].Value = node.SelectSingleNode("finance_bill_time").InnerText;
                dgv.Rows[sd].Cells[2].Value = node.SelectSingleNode("finance_bill_change").InnerText;
                dgv.Rows[sd].Cells[3].Value = node.SelectSingleNode("finance_is_spend_bill").InnerText;
                dgv.Rows[sd].Cells[4].Value = node.SelectSingleNode("staff_id").InnerText;
                sd++;
            }
        }

        private void HienThiChi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Refresh();
            var pos_bills = docChi.SelectSingleNode("/pos_bills");
            var poss_bill_list = pos_bills.SelectNodes("/pos_bills/pos_bill");
            var st = 0;
            foreach (XmlNode xmlnode in poss_bill_list)
            {
                dgv.Rows.Add();
                dgv.Rows[st].Cells[0].Value = xmlnode.SelectSingleNode("pos_bill_id").InnerText;
                dgv.Rows[st].Cells[1].Value = xmlnode.SelectSingleNode("pos_bill_time").InnerText;
                dgv.Rows[st].Cells[2].Value = xmlnode.SelectSingleNode("pos_bill_receive").InnerText;
                dgv.Rows[st].Cells[3].Value = xmlnode.SelectSingleNode("pos_is_sell_bill").InnerText;
                dgv.Rows[st].Cells[4].Value = xmlnode.SelectSingleNode("staff_id").InnerText;
                st++;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnThu_Click(object sender, EventArgs e)
        {
            if (tbMaPThu.Text == "" || tbSoTienThu.Text == "" || tbChiTietThu.Text == "" || tbIDnvThu.Text == "")
            {
                MessageBox.Show(Resources.Please_enter_complete_info);
                return;
            }

            finance_bills = docThu.DocumentElement;
            var id = tbMaPThu.Text.Trim();
            var checkID = finance_bills.SelectSingleNode("/finance_bills/finance_bill[finance_bill_id='" + id + "']");

            if (checkID == null)
            {
                XmlNode finance_bill_node = docThu.CreateElement("finance_bill");

                var finance_bill_id = docThu.CreateElement("finance_bill_id");
                finance_bill_id.InnerText = tbMaPThu.Text.Trim();

                var finance_bill_time = docThu.CreateElement("finance_bill_time");
                var datestring = dateTPThu.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                finance_bill_time.InnerText = datestring;

                var finance_bill_change = docThu.CreateElement("finance_bill_change");
                finance_bill_change.InnerText = tbSoTienThu.Text.Trim();

                var finance_is_spend_bill = docThu.CreateElement("finance_is_spend_bill");
                if (rbtnDTTThu.Checked)
                    finance_is_spend_bill.InnerText = "paid";
                else finance_is_spend_bill.InnerText = "unpaid";

                var fibnance_bill_content = docThu.CreateElement("fibnance_bill_content");
                fibnance_bill_content.InnerText = tbChiTietThu.Text.Trim();

                var idNhanVien = tbIDnvThu.Text.Trim();
                var idNv_Check = docNhanVien.SelectSingleNode("/staffs/staff[staff_id='" + idNhanVien + "']");
                if (idNv_Check != null)
                {
                    var staff_id = docThu.CreateElement("staff_id");
                    staff_id.InnerText = tbIDnvThu.Text.Trim();
                    finance_bill_node.AppendChild(staff_id);
                }
                else
                {
                    MessageBox.Show("Nhân viên không tồn tại!!!");
                    return;
                }

                finance_bill_node.AppendChild(finance_bill_id);
                finance_bill_node.AppendChild(finance_bill_time);
                finance_bill_node.AppendChild(finance_bill_change);
                finance_bill_node.AppendChild(finance_is_spend_bill);
                finance_bill_node.AppendChild(fibnance_bill_content);

                finance_bills.AppendChild(finance_bill_node);
                docThu.Save(pathThu);
                MessageBox.Show("Thêm mới thành công");
                tbMaPThu.Text = "";
                tbSoTienThu.Text = "";
                tbChiTietThu.Text = "";
                tbIDnvThu.Text = "";
                HienThiThu(dGVThu);
            }

            if (checkID != null) MessageBox.Show("Mã phiếu thu đã tồn tại!!!");
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            dGVChi.Refresh();
            dGVThu.Refresh();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dGVChi.Refresh();
            dGVThu.Refresh();
        }

        private void dGVThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dGVThu.CurrentCell.RowIndex;
            if (row >= 0 && dGVThu.Rows[row].Cells[0].Value != null)
                maPhieuThuClick = dGVThu.Rows[row].Cells[0].Value.ToString().Trim();
        }

        private void dGVChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dGVChi.CurrentCell.RowIndex;
            if (row >= 0 && dGVChi.Rows[row].Cells[0].Value != null)
                maPhieuChiClick = dGVChi.Rows[row].Cells[0].Value.ToString().Trim();
        }

        private void tPThuChi_Click(object sender, EventArgs e)
        {
        }

        private void dGVThu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = dGVThu.CurrentCell.RowIndex;
                var maPhieuThu = dGVThu.Rows[row].Cells[0].Value.ToString().Trim();
                var formChiTietThu = new ChiTietThu();
                formChiTietThu.Show();
                formChiTietThu.ReturnItem(maPhieuThu);
                formChiTietThu.FormClosedEvent += (s, ev) => { HienThiThu(dGVThu); };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void dGVChi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = dGVChi.CurrentCell.RowIndex;
                var maPhieuChi = dGVChi.Rows[row].Cells[0].Value.ToString().Trim();
                var formChiTietChi = new ChiTietChi();
                formChiTietChi.Show();
                formChiTietChi.ReturnItem(maPhieuChi);
                formChiTietChi.FormClosedEvent += (s, ev) => { HienThiChi(dGVChi); };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            var dateLoc = dateTPLoc.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            var pos_bills = docChi.SelectSingleNode("/pos_bills");
            var poss_bill_list_after_filter =
                pos_bills.SelectNodes("/pos_bills/pos_bill[pos_bill_time='" + dateLoc + "']");
            var st = 0;
            dGVChi.Rows.Clear();
            dGVChi.Refresh();
            foreach (XmlNode xmlnode in poss_bill_list_after_filter)
            {
                dGVChi.Rows.Add();
                dGVChi.Rows[st].Cells[0].Value = xmlnode.SelectSingleNode("pos_bill_id").InnerText;
                dGVChi.Rows[st].Cells[1].Value = xmlnode.SelectSingleNode("pos_bill_time").InnerText;
                dGVChi.Rows[st].Cells[2].Value = xmlnode.SelectSingleNode("pos_bill_receive").InnerText;
                dGVChi.Rows[st].Cells[3].Value = xmlnode.SelectSingleNode("pos_is_sell_bill").InnerText;
                dGVChi.Rows[st].Cells[4].Value = xmlnode.SelectSingleNode("staff_id").InnerText;
                st++;
            }

            var finance_bills = docThu.SelectSingleNode("/finance_bills");
            var finance_bills_after_filter =
                finance_bills.SelectNodes("/finance_bills/finance_bill[finance_bill_time='" + dateLoc + "']");
            var sr = 0;
            dGVThu.Rows.Clear();
            dGVThu.Refresh();
            foreach (XmlNode xmlnode in finance_bills_after_filter)
            {
                dGVThu.Rows.Add();
                dGVThu.Rows[sr].Cells[0].Value = xmlnode.SelectSingleNode("finance_bill_id").InnerText;
                dGVThu.Rows[sr].Cells[1].Value = xmlnode.SelectSingleNode("finance_bill_time").InnerText;
                dGVThu.Rows[sr].Cells[2].Value = xmlnode.SelectSingleNode("finance_bill_change").InnerText;
                dGVThu.Rows[sr].Cells[3].Value = xmlnode.SelectSingleNode("finance_is_spend_bill").InnerText;
                dGVThu.Rows[sr].Cells[4].Value = xmlnode.SelectSingleNode("staff_id").InnerText;
                sr++;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Xóa!!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                if (maPhieuChiClick != null)
                {
                    var pos_bills = docChi.SelectSingleNode("/pos_bills");
                    var RemoveNode =
                        pos_bills.SelectSingleNode("/pos_bills/pos_bill[pos_bill_id='" + maPhieuChiClick + "']");
                    if (RemoveNode != null)
                    {
                        pos_bills.RemoveChild(RemoveNode);
                        docChi.Save(pathChi);
                        HienThiChi(dGVChi);
                    }
                }
                else if (maPhieuThuClick != null)
                {
                    var finance_bills = docThu.SelectSingleNode("/finance_bills");
                    var RemoveNode =
                        finance_bills.SelectSingleNode("/finance_bills/finance_bill[finance_bill_id='" +
                                                       maPhieuThuClick + "']");
                    if (RemoveNode != null)
                    {
                        finance_bills.RemoveChild(RemoveNode);
                        docThu.Save(pathThu);
                        HienThiThu(dGVThu);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn trường muốn xóa!!");
                }
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            HienThiThu(dGVThu);
            HienThiChi(dGVChi);
            HienThiChartThu();
            HienThiChartChi();
        }

        private void tbSoTienThu_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbSoTienThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void tbSoTienChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnChi_Click(object sender, EventArgs e)
        {
            if (tbMaPChi.Text == "" || tbSoTienChi.Text == "" || tbIDnvChi.Text == "" || tbIDKho.Text == "" ||
                tbMaPhieuThu.Text == "" || tbIDKh.Text == "")
            {
                MessageBox.Show(Resources.Please_enter_complete_info);
                return;
            }

            pos_bills = docChi.DocumentElement;
            XmlNode pos_bill = docChi.CreateElement("pos_bill");
            var pos_id = tbMaPChi.Text.Trim();
            var checkID = pos_bills.SelectSingleNode("/pos_bills/pos_bill[pos_bill_id='" + pos_id + "']");
            if (checkID == null)
            {
                var pos_bill_id = docChi.CreateElement("pos_bill_id");
                pos_bill_id.InnerText = tbMaPChi.Text.Trim();

                var pos_bill_time = docChi.CreateElement("pos_bill_time");
                var datestring = dateTPChi.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                pos_bill_time.InnerText = datestring;

                var pos_bill_receive = docChi.CreateElement("pos_bill_receive");
                pos_bill_receive.InnerText = tbSoTienChi.Text.Trim();

                var idNhanVien = tbIDnvChi.Text.Trim();
                var idNv_Check = docNhanVien.SelectSingleNode("/staffs/staff[staff_id='" + idNhanVien + "']");
                if (idNv_Check != null)
                {
                    var staff_id = docChi.CreateElement("staff_id");
                    staff_id.InnerText = tbIDnvChi.Text.Trim();
                    pos_bill.AppendChild(staff_id);
                }
                else
                {
                    MessageBox.Show("Nhân viên không tồn tại!!!");
                    return;
                }

                var pos_is_sell_bill = docChi.CreateElement("pos_is_sell_bill");
                if (rbtnDTTChi.Checked)
                    pos_is_sell_bill.InnerText = "paid";
                else pos_is_sell_bill.InnerText = "unpaid";

                var warehouse_bill_id = docChi.CreateElement("warehouse_bill_id");
                warehouse_bill_id.InnerText = tbIDKho.Text.Trim();

                var finance_bill_id = docChi.CreateElement("finance_bill_id");
                finance_bill_id.InnerText = tbMaPhieuThu.Text.Trim();

                var customer_id = docChi.CreateElement("customer_id");
                customer_id.InnerText = tbIDKh.Text.Trim();

                pos_bill.AppendChild(pos_bill_id);
                pos_bill.AppendChild(pos_bill_time);
                pos_bill.AppendChild(pos_bill_receive);
                pos_bill.AppendChild(pos_is_sell_bill);
                pos_bill.AppendChild(warehouse_bill_id);
                pos_bill.AppendChild(finance_bill_id);
                pos_bill.AppendChild(customer_id);

                pos_bills.AppendChild(pos_bill);
                docChi.Save(pathChi);
                MessageBox.Show("Thêm mới phiếu chi thành công");
                tbMaPChi.Text = "";
                tbSoTienChi.Text = "";
                tbIDnvChi.Text = "";
                tbIDKho.Text = "";
                tbMaPhieuThu.Text = "";
                tbIDKh.Text = "";
                HienThiChi(dGVChi);
            }

            if (checkID != null) MessageBox.Show("Đã tồn tại mã phiếu chi!!!");
        }
    }
}