namespace QPharma.DAL;

public class BillDetailDAL
{
    public List<BillDetailDTO> GetById(string id)
    {
        List<BillDetailDTO> billDetail = null;
        try
        {
            string query = "SELECT * FROM bill_details WHERE bill_id = @id";
            SqlParameter[] sqlParameters = { new SqlParameter("@id", id) };
            var dt = DB.ExecuteQuery(query, sqlParameters);
            billDetail = new List<BillDetailDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                var medicine = new MedicineDAL().GetById(dr["medicine_id"].ToString());
                var quantity = int.Parse(dr["bill_detail_quantity"].ToString());
                var price = int.Parse(dr["bill_detail_price"].ToString());
                billDetail.Add(new BillDetailDTO(medicine, quantity, price));
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return billDetail;
    }
}
