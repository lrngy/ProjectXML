using System.Collections;

namespace QPharma.DAL;

public class StatDAL
{
    public List<(string doanhthu, string loinhuan)> TatCaDoanhThuLoiNhuan()
    {
        List<(string doanhthu, string loinhuan)> list = new();

        try
        {
            var query = "SELECT " +
                        "SUM(bd.bill_detail_quantity * bd.bill_detail_price) AS total_revenue, " +
                        "SUM(bd.bill_detail_quantity * (bd.bill_detail_price - m.medicine_price_in)) AS total_profit " +
                        "FROM bill_details bd " +
                        "INNER JOIN medicines m ON bd.medicine_id = m.medicine_id " +
                        "INNER JOIN bills b ON bd.bill_id = b.bill_id " +
                        "WHERE b.bill_status = 1";
            var dt = DB.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                string total_revenue = dr["total_revenue"].ToString();
                string total_profit = dr["total_profit"].ToString();
                list.Add((total_revenue, total_profit));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }


        return list;
    }

    public List<(string ngay, string doanhthu, string loinhuan)> DoanhThuNgay()
    {
        List<(string ngay, string doanhthu, string loinhuan)> list = new();

        try
        {
            var query =
                "SELECT CAST(b.bill_created AS DATE) AS date, SUM(bd.bill_detail_quantity * bd.bill_detail_price) AS daily_revenue, SUM(bd.bill_detail_quantity * (bd.bill_detail_price - m.medicine_price_in)) AS daily_profit FROM bill_details bd INNER JOIN medicines m ON bd.medicine_id = m.medicine_id INNER JOIN bills b ON bd.bill_id = b.bill_id WHERE b.bill_status = 1 GROUP BY CAST(b.bill_created AS DATE) ORDER BY CAST(b.bill_created AS DATE);";
            var dt = DB.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                string date = dr["date"].ToString();
                string daily_revenue = dr["daily_revenue"].ToString();
                string daily_profit = dr["daily_profit"].ToString();
                list.Add((date, daily_revenue, daily_profit));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return list;
    }


    public List<(string nam, string thang, string doanhthu, string loinhuan)> DoanhThuThang()
    {
        List<(string nam, string thang, string doanhthu, string loinhuan)> list = new();

        try
        {
            var query = "SELECT YEAR(b.bill_created) AS year,MONTH(b.bill_created) AS month,SUM(bd.bill_detail_quantity * bd.bill_detail_price) AS monthly_revenue,SUM(bd.bill_detail_quantity * (bd.bill_detail_price - m.medicine_price_in)) AS monthly_profit FROM bill_details bd INNER JOIN medicines m ON bd.medicine_id = m.medicine_id INNER JOIN bills b ON bd.bill_id = b.bill_id WHERE b.bill_status = 1 GROUP BY YEAR(b.bill_created), MONTH(b.bill_created) ORDER BY YEAR(b.bill_created), MONTH(b.bill_created);";
            var dt = DB.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                string year = dr["year"].ToString();
                string month = dr["month"].ToString();
                string monthly_revenue = dr["monthly_revenue"].ToString();
                string monthly_profit = dr["monthly_profit"].ToString();
                list.Add((year, month, monthly_revenue, monthly_profit));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return list;
    }

    public List<(string mathuoc, string tenthuoc, string gianhap, string giaban, string soluong, string doanhthu, string loinhuan)> DoanhThuThuoc()
    {
        List<(string mathuoc, string tenthuoc, string gianhap, string giaban, string soluong, string doanhthu, string loinhuan)> list = new();

        try
        {
            var query = "SELECT m.medicine_id, m.medicine_name, m.medicine_price_in, m.medicine_price_out,SUM(bd.bill_detail_quantity) AS total_quantity_sold,SUM(bd.bill_detail_quantity * bd.bill_detail_price) AS total_revenue,SUM(bd.bill_detail_quantity * (bd.bill_detail_price - m.medicine_price_in)) AS total_profit FROM bill_details bd INNER JOIN medicines m ON bd.medicine_id = m.medicine_id INNER JOIN bills b ON bd.bill_id = b.bill_id WHERE b.bill_status = 1 GROUP BY m.medicine_id, m.medicine_name, m.medicine_price_in, m.medicine_price_out";
            var dt = DB.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                string mathuoc = dr["medicine_id"].ToString();
                string tenthuoc = dr["medicine_name"].ToString();
                string gianhap = dr["medicine_price_in"].ToString();
                string giaban = dr["medicine_price_out"].ToString();
                string soluong = dr["total_quantity_sold"].ToString();
                string doanhthu = dr["total_revenue"].ToString();
                string loinhuan = dr["total_profit"].ToString();
                list.Add((mathuoc, tenthuoc, gianhap, giaban, soluong, doanhthu, loinhuan));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return list;
    }
}
