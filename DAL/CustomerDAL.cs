namespace QPharma.DAL;

public class CustomerDAL
{
    public CustomerDTO GetById(string id)
    {
        CustomerDTO customer = null;
        try
        {
            string query = "SELECT top 1 * FROM customers WHERE customer_id = @id";
            SqlParameter[] sqlParameters = { new SqlParameter("@id", id) };
            var dt = DB.ExecuteQuery(query, sqlParameters);
            if (dt.Rows.Count != 0)
            {
                var name = dt.Rows[0]["customer_name"].ToString();
                var phone = dt.Rows[0]["customer_phone"].ToString();
                var address = dt.Rows[0]["customer_address"].ToString();
                var note = dt.Rows[0]["customer_note"].ToString();
                var status = bool.Parse(dt.Rows[0]["customer_status"].ToString());
                var created = !string.IsNullOrEmpty(dt.Rows[0]["customer_created"].ToString()) ? DateTime.Parse(dt.Rows[0]["customer_created"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var updated = !string.IsNullOrEmpty(dt.Rows[0]["customer_updated"].ToString()) ? DateTime.Parse(dt.Rows[0]["customer_updated"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var deleted = !string.IsNullOrEmpty(dt.Rows[0]["customer_deleted"].ToString()) ? DateTime.Parse(dt.Rows[0]["customer_deleted"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";

                customer = new CustomerDTO(id, name, phone, address, note, status, created, updated, deleted);
            }

        } catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return customer;
    }
}