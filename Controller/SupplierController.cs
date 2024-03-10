using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXML.DAO;
using ProjectXML.Model;
using ProjectXML.Util;


namespace ProjectXML.Controller
{
    public class SupplierController
    {
        public SupplierDAO supplierDAO { get; set; }
        public SupplierController()
        {
            supplierDAO = new SupplierDAO();
        }
        public List<Supplier> LoadData()
        {
            return supplierDAO.GetAll();
        }

        public int Insert(Supplier supplier)
        {
            if (supplierDAO.GetById(supplier.id) != null)
            {
                return Predefined.ID_EXIST;
            }
            return supplierDAO.Insert(supplier);
        }

        public int Update(Supplier supplier)
        {
            if (supplierDAO.GetById(supplier.id) == null)
            {
                return Predefined.ID_NOT_EXIST;
            }
            return supplierDAO.Update(supplier);
        }

        public int Delete(string maNCC)
        {
            if (supplierDAO.GetById(maNCC) == null)
            {
                return Predefined.ID_NOT_EXIST;
            }
            return supplierDAO.Delete(maNCC);
        }

        internal int Restore(string maNCC)
        {
            return supplierDAO.Restore(maNCC);
        }

        internal int ForceDelete(string maNCC)
        {
            return supplierDAO.ForceDelete(maNCC);
        }   
    }
}
