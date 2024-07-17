using System.Collections.Generic;
using ProjectXML.DAL;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.BUS
{
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
            if (supplierDAL.GetById(supplier.id) != null) return Predefined.ID_EXIST;
            return supplierDAL.Insert(supplier);
        }

        public int Update(SupplierDTO supplier)
        {
            if (supplierDAL.GetById(supplier.id) == null) return Predefined.ID_NOT_EXIST;
            return supplierDAL.Update(supplier);
        }

        public int Delete(string maNCC)
        {
            if (supplierDAL.GetById(maNCC) == null) return Predefined.ID_NOT_EXIST;
            return supplierDAL.Delete(maNCC);
        }

        internal int Restore(string maNCC)
        {
            return supplierDAL.Restore(maNCC);
        }

        internal int ForceDelete(string maNCC)
        {
            return supplierDAL.ForceDelete(maNCC);
        }
    }
}