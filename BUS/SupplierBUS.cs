﻿using System.Collections.Generic;
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

        public int ForceDelete(string id)
        {
            if (supplierDAL.GetById(id) == null) return Predefined.ID_NOT_EXIST;
            return supplierDAL.ForceDelete(id);
        }

        public int RestoreAll(string id)
        {
            if (supplierDAL.GetById(id) == null) return Predefined.ID_NOT_EXIST;
            return supplierDAL.RestoreAll(id);
        }
    }
}