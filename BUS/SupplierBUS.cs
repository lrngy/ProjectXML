namespace QPharma.BUS;

public class SupplierBUS
{
    public SupplierBUS()
    {
        supplierDAL = new SupplierDAL();
    }

    public SupplierDAL supplierDAL { get; set; }

    public List<SupplierDTO> LoadData()
    {
        return supplierDAL.GetAll();
    }

    public int Insert(SupplierDTO supplier)
    {
        var supp = supplierDAL.GetById(supplier.id);
        if (supp == null) return supplierDAL.Insert(supplier);
        if(!string.IsNullOrEmpty(supp.deleted)) return Predefined.ID_EXIST_IN_ARCHIVE;
        return Predefined.ID_EXIST;
    }

    public int Update(SupplierDTO supplier)
    {
        if (supplierDAL.GetById(supplier.id) == null) return Predefined.ID_NOT_EXIST;
        return supplierDAL.Update(supplier);
    }

    public int Delete(string id)
    {
        if (supplierDAL.GetById(id) == null) return Predefined.ID_NOT_EXIST;
        return supplierDAL.Delete(id);
    }

    public int Restore(string id)
    {
        if (supplierDAL.GetById(id) == null) return Predefined.ID_NOT_EXIST;
        return supplierDAL.Restore(id);
    }

    public int RestoreAll()
    {
        return supplierDAL.RestoreAll();
    }

    public int ForceDelete(string id)
    {
        if (supplierDAL.GetById(id) == null) return Predefined.ID_NOT_EXIST;
        return supplierDAL.ForceDelete(id);

    }
}