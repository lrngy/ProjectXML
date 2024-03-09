using ProjectXML.Controller;
using ProjectXML.DAO;
using ProjectXML.Model;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;

public class MedicineController
{
    public MedicineDAO medicineDAO { get; set; }
    public CategoryController categoryController { get; set; }
    public SupplierController supplierController { get; set; }

    public MedicineController()
    {
        categoryController = new CategoryController();
        supplierController = new SupplierController();
        medicineDAO = new MedicineDAO(categoryController.categoryDAO, supplierController.supplierDAO);
    }
    public List<Medicine> LoadData()
    {
        return medicineDAO.GetAll();
    }

    internal int Insert(Medicine newMedicine)
    {
        if (medicineDAO.GetById(newMedicine.id) != null)
        {
            return Predefined.ID_EXIST;
        }
        return medicineDAO.Insert(newMedicine);
    }

    public int Update(Medicine medicine)
    {
        if (medicineDAO.GetById(medicine.id) == null)
        {
            return Predefined.ID_NOT_EXIST;
        }
        return medicineDAO.Update(medicine);
    }

    public int Delete(string id)
    {
        if (medicineDAO.GetById(id) == null)
        {
            return Predefined.ID_NOT_EXIST;
        }
        return medicineDAO.Delete(id);
    }

    internal int Restore(string id)
    {
        return medicineDAO.Restore(id);
    }

    internal int ForceDelete(string id)
    {
        return medicineDAO.ForceDelete(id);
    }

    internal int RestoreAll()
    {
        return medicineDAO.RestoreAll();
    }
    public int ChangeImage(string id)
    {
        if (medicineDAO.GetById(id) == null)
        {
            return Predefined.ID_NOT_EXIST;
        }
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*",
            Title = "Chọn ảnh thuốc"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string sourcePath = openFileDialog.FileName;
            string targetDirectory = Config.getImagePath();
            string targetPath = Path.Combine(targetDirectory, $"{id}.jpg");

            try
            {
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                //if (File.Exists(targetPath))
                //{
                //    File.Delete(targetPath);
                //}
                File.Copy(sourcePath, targetPath, true);

                return medicineDAO.ChangeImage(id, targetPath);

            }
            catch (IOException ex)
            {
             
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
            }
        }
        return Predefined.FILE_NOT_FOUND;
    }

    internal int RemoveImage(string id)
    {
        if (medicineDAO.GetById(id) == null)
        {
            return Predefined.ID_NOT_EXIST;
        }
    
        string targetDirectory = Config.getImagePath();
        string targetPath = Path.Combine(targetDirectory, $"{id}.jpg");
        if (File.Exists(targetPath))
        {
            File.Delete(targetPath);
        }
        return medicineDAO.RemoveImage(id);
    }
}
