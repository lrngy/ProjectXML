﻿namespace QPharma.BUS;

public class MedicineBUS
{
    public MedicineBUS()
    {
        medicineDAL = new MedicineDAL();
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
        MedicineDTO existingMedicine = medicineDAL.GetById(newMedicine.id);

        if (existingMedicine == null)
        {
            return medicineDAL.Insert(newMedicine);
        }

        if (!string.IsNullOrEmpty(existingMedicine.deleted))
        {
            return Predefined.ID_EXIST_IN_ARCHIVE;
        }

        return Predefined.ID_EXIST;
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
            var targetDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                 Config.Instance.ConfigureFile.LocalResource,
                 Config.Instance.ConfigureFile.ImageFolderName);

            //var targetDirectory = Config.getImagePath();
            var targetPath = Path.Combine(targetDirectory, $"{id}.jpg");

            try
            {
                if (!Directory.Exists(targetDirectory)) Directory.CreateDirectory(targetDirectory);
                File.Copy(sourcePath, targetPath, true);

                return medicineDAL.ChangeImage(id, targetPath);
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        return Predefined.ERROR;
    }

    internal int RemoveImage(string id)
    {
        if (medicineDAL.GetById(id) == null) return Predefined.ID_NOT_EXIST;

        var targetDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
             Config.Instance.ConfigureFile.LocalResource,
             Config.Instance.ConfigureFile.ImageFolderName);
        var targetPath = Path.Combine(targetDirectory, $"{id}.jpg");
        if (File.Exists(targetPath)) File.Delete(targetPath);
        return medicineDAL.RemoveImage(id);
    }
}