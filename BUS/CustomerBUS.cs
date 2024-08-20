namespace QPharma.BUS;

public class CustomerBUS
{
    private CustomerDAL customerDAL;
    public CustomerBUS()
    {
        customerDAL = new CustomerDAL();
    }

    public List<CustomerDTO> LoadData()
    {
        return customerDAL.LoadData();
    }
    public CustomerDTO GetById(string id)
    {
        return customerDAL.GetById(id);
    }
}