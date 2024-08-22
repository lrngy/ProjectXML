namespace QPharma.DAL;

public class BillDetailDAL
{
    public List<(MedicineDTO medicine, decimal quantity, decimal price)> GetById(string id)
    {
        List<(MedicineDTO medicine, decimal quantity, decimal price)> billDetailList = new();
        try
        {
            string query = "SELECT * FROM bill_details WHERE bill_id = @id";
            SqlParameter[] sqlParameters = { new SqlParameter("@id", id) };
            var dt = DB.ExecuteQuery(query, sqlParameters);
            foreach (DataRow dr in dt.Rows)
            {
                var medicine = new MedicineDAL().GetById(dr["medicine_id"].ToString());
                var quantity = decimal.Parse(dr["bill_detail_quantity"].ToString());
                var price = decimal.Parse(dr["bill_detail_price"].ToString());
                billDetailList.Add((medicine, quantity, price));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return billDetailList;
    }
}
