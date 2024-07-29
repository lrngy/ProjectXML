using System.Collections.Generic;
using QPharma.DAL;
using QPharma.DTO;
using QPharma.Util;

namespace QPharma.BUS
{
    public class MedicineLocationBUS
    {
        public MedicineLocationBUS()
        {
            medicineLocationDAL = new MedicineLocationDAL();
        }

        private MedicineLocationDAL medicineLocationDAL { get; }

        public List<MedicineLocationDTO> LoadData()
        {
            return medicineLocationDAL.GetAll();
        }

        public int Insert(MedicineLocationDTO medicineLocation)
        {
            if (medicineLocationDAL.CheckExistName(medicineLocation.name)) return Predefined.ID_EXIST;
            return medicineLocationDAL.Insert(medicineLocation);
        }
        public int Update(MedicineLocationDTO medicineLocation)
        {
            if (medicineLocationDAL.GetById(medicineLocation.id) == null) return Predefined.ID_NOT_EXIST;
            return medicineLocationDAL.Update(medicineLocation);
        }

        public int Delete(string maViTri)
        {
            return medicineLocationDAL.Delete(maViTri);
        }

        public int Restore(string maViTri)
        {
            return medicineLocationDAL.Restore(maViTri);
        }

        public int RestoreAll()
        {
            return medicineLocationDAL.RestoreAll();
        }

        public int ForceDelete(string maViTri)
        {
            return medicineLocationDAL.ForceDelete(maViTri);
        }
    }
}