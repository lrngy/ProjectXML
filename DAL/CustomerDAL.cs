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

    public List<CustomerDTO> LoadData()
    {
        List<CustomerDTO> customers = new List<CustomerDTO>();
        try
        {
            string query = "SELECT * FROM customers";
            var dt = DB.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                var id = dr["customer_id"].ToString();
                var name = dr["customer_name"].ToString();
                var phone = dr["customer_phone"].ToString();
                var address = dr["customer_address"].ToString();
                var note = dr["customer_note"].ToString();
                var status = bool.Parse(dr["customer_status"].ToString());
                var created = !string.IsNullOrEmpty(dr["customer_created"].ToString()) ? DateTime.Parse(dr["customer_created"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var updated = !string.IsNullOrEmpty(dr["customer_updated"].ToString()) ? DateTime.Parse(dr["customer_updated"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var deleted = !string.IsNullOrEmpty(dr["customer_deleted"].ToString()) ? DateTime.Parse(dr["customer_deleted"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";

                customers.Add(new CustomerDTO(id, name, phone, address, note, status, created, updated, deleted));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return customers;
    }

    public CustomerDTO GetByLastCustomer()
    {
        CustomerDTO customer = null;
        try
        {
            string query = "SELECT top 1 * FROM customers order by customer_created desc";
            var dt = DB.ExecuteQuery(query);
            if (dt.Rows.Count != 0)
            {
                var id = dt.Rows[0]["customer_id"].ToString();
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

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return customer;
    }

    public int Insert(CustomerDTO customer)
    {
        try
        {
            string query = "INSERT INTO customers (customer_name, customer_phone, customer_address, customer_note, customer_status, customer_created) VALUES (@name, @phone, @address, @note, @status, getdate())";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@name", customer.Name),
                new SqlParameter("@phone", (object)customer.Phone ?? DBNull.Value),
                new SqlParameter("@address", (object)customer.Address ?? DBNull.Value),
                new SqlParameter("@note", (object) customer.Note ?? DBNull.Value),
                new SqlParameter("@status", customer.Status),
            };
            DB.ExecuteNonQuery(query, sqlParameters);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return Predefined.ERROR;
    }

    public int Delete(string customerId)
    {
        try
        {
            string query = "UPDATE customers SET customer_deleted = getdate() WHERE customer_id = @id";
            SqlParameter[] sqlParameters = { new SqlParameter("@id", customerId) };
            DB.ExecuteNonQuery(query, sqlParameters);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return Predefined.ERROR;
    }
}