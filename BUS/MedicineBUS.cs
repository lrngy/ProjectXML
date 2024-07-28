﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using QPharma.DAL;
using QPharma.DTO;
using QPharma.Util;

namespace QPharma.BUS
{
    public class MedicineBUS
    {
        public MedicineBUS()
        {
            categoryController = new CategoryBUS();
            supplierController = new SupplierBUS();
            medicineDAL = new MedicineDAL(categoryController.categoryDAL, supplierController.supplierDAL);
        }

        private MedicineDAL medicineDAL { get; }
        private CategoryBUS categoryController { get; }
        private SupplierBUS supplierController { get; }

        public List<MedicineDTO> LoadData()
        {
            return medicineDAL.GetAll();
        }

        public int Insert(MedicineDTO newMedicine)
        {
            if (medicineDAL.GetById(newMedicine.id) != null) return Predefined.ID_EXIST;
            return medicineDAL.Insert(newMedicine);
        }

        public int Update(MedicineDTO medicine)
        {
            if (medicineDAL.GetById(medicine.id) == null) return Predefined.ID_NOT_EXIST;
            return medicineDAL.Update(medicine);
        }

        public int Delete(string id)
        {
            if (medicineDAL.GetById(id) == null) return Predefined.ID_NOT_EXIST;
            return medicineDAL.Delete(id);
        }

        public int Restore(string id)
        {
            return medicineDAL.Restore(id);
        }

        public int ForceDelete(string id)
        {
            return medicineDAL.ForceDelete(id);
        }

        public int RestoreAll()
        {
            return medicineDAL.RestoreAll();
        }

        public int ChangeImage(string id)
        {
            if (medicineDAL.GetById(id) == null) return Predefined.ID_NOT_EXIST;
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*",
                Title = "Chọn ảnh thuốc"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var sourcePath = openFileDialog.FileName;
                var targetDirectory = Config.getImagePath();
                var targetPath = Path.Combine(targetDirectory, $"{id}.jpg");

                try
                {
                    if (!Directory.Exists(targetDirectory)) Directory.CreateDirectory(targetDirectory);
                    //if (File.Exists(targetPath))
                    //{
                    //    File.Delete(targetPath);
                    //}
                    File.Copy(sourcePath, targetPath, true);

                    return medicineDAL.ChangeImage(id, targetPath);
                }
                catch (IOException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                }
            }

            return Predefined.ERROR;
        }

        internal int RemoveImage(string id)
        {
            if (medicineDAL.GetById(id) == null) return Predefined.ID_NOT_EXIST;

            var targetDirectory = Config.getImagePath();
            var targetPath = Path.Combine(targetDirectory, $"{id}.jpg");
            if (File.Exists(targetPath)) File.Delete(targetPath);
            return medicineDAL.RemoveImage(id);
        }
    }
}