namespace QPharma.BUS;

public class CustomerBUS
{
    private CustomerDAL customerDAL;
    public CustomerBUS()
    {
        customerDAL = new CustomerDAL();
    }
    public CustomerDTO GetById(string id)
    {
        return customerDAL.GetById(id);
    }
}