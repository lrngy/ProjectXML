using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ProjectXML.DAL;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.BUS
{
    public class MedicineBUS
    {
        public MedicineBUS()
        {
            categoryController = new CategoryBUS();
            supplierController = new SupplierBUS();
            medicineDAL = new MedicineDAL(categoryController.categoryDAL, supplierController.supplierDAL);
        }

        public MedicineDAL medicineDAL { get; set; }
        public CategoryBUS categoryController { get; set; }
        public SupplierBUS supplierController { get; set; }

        public List<MedicineDTO> LoadData()
        {
            return medicineDAL.GetAll();
        }

        internal int Insert(MedicineDTO newMedicine)
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

        internal int Restore(string id)
        {
            return medicineDAL.Restore(id);
        }

        internal int ForceDelete(string id)
        {
            return medicineDAL.ForceDelete(id);
        }

        internal int RestoreAll()
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

            return Predefined.FILE_NOT_FOUND;
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