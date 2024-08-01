using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using QPharma.DAL;
using QPharma.DTO;
using QPharma.Util;

namespace QPharma.BUS
{
    public class MedicineLocationBUS
    {
        private MedicineLocationDAL medicineLocationDAL { get; set; }

        public MedicineLocationBUS()
        {
            medicineLocationDAL = new MedicineLocationDAL();
        }

        public List<MedicineLocationDTO> LoadData()
        {
            return medicineLocationDAL.GetAll();
        }


    }
}