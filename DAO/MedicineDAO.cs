using ProjectXML.Model;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectXML.DAO
{
    public class MedicineDAO
    {
        XmlDocument medicineDoc;
        SupplierDAO supplierDAO;
        CategoryDAO categoryDAO;


        public MedicineDAO()
        {
            supplierDAO = new SupplierDAO();
            categoryDAO = new CategoryDAO();
        }
        public MedicineDAO(CategoryDAO categoryDAO, SupplierDAO supplierDAO)
        {
            this.supplierDAO = supplierDAO;
            this.categoryDAO = categoryDAO;
        }
        public void ReloadData()
        {
            medicineDoc = Config.getDoc("medicines");
        }
        public List<Medicine> GetAll()
        {
            ReloadData();
            List<Medicine> list = new List<Medicine>();
            try
            {
                XmlNodeList medicineNodes = medicineDoc.SelectNodes("/medicines/medicine");
                foreach (XmlNode medicineNode in medicineNodes)
                {
                    string id = medicineNode.SelectSingleNode("medicine_id").InnerText;
                    string name = medicineNode.SelectSingleNode("medicine_name").InnerText;
                    string expire = medicineNode.SelectSingleNode("medicine_expire_date").InnerText;
                    string unit = medicineNode.SelectSingleNode("medicine_unit").InnerText;
                    double price = double.Parse(medicineNode.SelectSingleNode("medicine_price").InnerText);
                    int quantity = int.Parse(medicineNode.SelectSingleNode("medicine_quantity").InnerText);
                    string image = medicineNode.SelectSingleNode("medicine_image").InnerText;
                    string description = medicineNode.SelectSingleNode("medicine_description").InnerText;
                    string supplierId = medicineNode.SelectSingleNode("supplier_id").InnerText;
                    string created = medicineNode.SelectSingleNode("medicine_created").InnerText;
                    string updated = medicineNode.SelectSingleNode("medicine_updated").InnerText;
                    string deleted = medicineNode.SelectSingleNode("medicine_deleted").InnerText;
                    string categoryId = medicineNode.SelectSingleNode("category_id").InnerText;

                    Supplier supplier = supplierDAO.GetById(supplierId);
                    Category category = categoryDAO.GetById(categoryId);

                    Medicine medicine = new Medicine(id, name, expire, unit, price, quantity, image, description, supplier, created, updated, deleted, category);
                    list.Add(medicine);
                }


            }
            catch (Exception)
            {

            }
            return list;
        }

        internal Medicine GetById(string id)
        {
            ReloadData();
            Medicine medicine = null;
            try
            {
                XmlNode medicineNode = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']");
                if (medicineNode != null)
                {
                    string name = medicineNode.SelectSingleNode("medicine_name").InnerText;
                    string expire = medicineNode.SelectSingleNode("medicine_expire_date").InnerText;
                    string unit = medicineNode.SelectSingleNode("medicine_unit").InnerText;
                    double price = double.Parse(medicineNode.SelectSingleNode("medicine_price").InnerText);
                    int quantity = int.Parse(medicineNode.SelectSingleNode("medicine_quantity").InnerText);
                    string image = medicineNode.SelectSingleNode("medicine_image").InnerText;
                    string description = medicineNode.SelectSingleNode("medicine_description").InnerText;
                    string supplierId = medicineNode.SelectSingleNode("supplier_id").InnerText;
                    string created = medicineNode.SelectSingleNode("medicine_created").InnerText;
                    string updated = medicineNode.SelectSingleNode("medicine_updated").InnerText;
                    string deleted = medicineNode.SelectSingleNode("medicine_deleted").InnerText;
                    string categoryId = medicineNode.SelectSingleNode("category_id").InnerText;

                    Supplier supplier = supplierDAO.GetById(supplierId);
                    Category category = categoryDAO.GetById(categoryId);

                    medicine = new Medicine(id, name, expire, unit, price, quantity, image, description, supplier, created, updated, deleted, category);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return medicine;
        }

        public int Update(Medicine medicine)
        {
            ReloadData();
            try
            {
                XmlNode medicineNode = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + medicine.id + "']");
                if (medicineNode != null)
                {
                    medicineNode.SelectSingleNode("medicine_name").InnerText = medicine.name;
                    medicineNode.SelectSingleNode("medicine_expire_date").InnerText = medicine.expireDate;
                    medicineNode.SelectSingleNode("medicine_unit").InnerText = medicine.unit;
                    medicineNode.SelectSingleNode("medicine_price").InnerText = medicine.price.ToString();
                    medicineNode.SelectSingleNode("medicine_quantity").InnerText = medicine.quantity.ToString();
                    medicineNode.SelectSingleNode("medicine_image").InnerText = medicine.image;
                    medicineNode.SelectSingleNode("medicine_description").InnerText = medicine.description;
                    medicineNode.SelectSingleNode("supplier_id").InnerText = medicine.supplier.id;
                    medicineNode.SelectSingleNode("medicine_updated").InnerText = CustomDateTime.GetNow();
                    medicineNode.SelectSingleNode("category_id").InnerText = medicine.category.id;

                    medicineDoc.Save(Config.getXMLPath("medicines"));
                    return Predefined.SUCCESS;
                }
                return Predefined.ID_NOT_EXIST;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }


        internal int Insert(Medicine newMedicine)
        {
            ReloadData();
            try
            {
                XmlNode medicineNode = medicineDoc.CreateElement("medicine");

                XmlNode idNode = medicineDoc.CreateElement("medicine_id");
                idNode.InnerText = newMedicine.id;
                medicineNode.AppendChild(idNode);

                XmlNode nameNode = medicineDoc.CreateElement("medicine_name");
                nameNode.InnerText = newMedicine.name;
                medicineNode.AppendChild(nameNode);

                XmlNode expireNode = medicineDoc.CreateElement("medicine_expire_date");
                expireNode.InnerText = newMedicine.expireDate;
                medicineNode.AppendChild(expireNode);

                XmlNode unitNode = medicineDoc.CreateElement("medicine_unit");
                unitNode.InnerText = newMedicine.unit;
                medicineNode.AppendChild(unitNode);

                XmlNode priceNode = medicineDoc.CreateElement("medicine_price");
                priceNode.InnerText = newMedicine.price.ToString();
                medicineNode.AppendChild(priceNode);

                XmlNode quantityNode = medicineDoc.CreateElement("medicine_quantity");
                quantityNode.InnerText = newMedicine.quantity.ToString();
                medicineNode.AppendChild(quantityNode);

                XmlNode imageNode = medicineDoc.CreateElement("medicine_image");
                imageNode.InnerText = newMedicine.image;
                medicineNode.AppendChild(imageNode);

                XmlNode descriptionNode = medicineDoc.CreateElement("medicine_description");
                descriptionNode.InnerText = newMedicine.description;
                medicineNode.AppendChild(descriptionNode);

                XmlNode supplierIdNode = medicineDoc.CreateElement("supplier_id");
                supplierIdNode.InnerText = newMedicine.supplier.id;
                medicineNode.AppendChild(supplierIdNode);

                XmlNode createdNode = medicineDoc.CreateElement("medicine_created");
                createdNode.InnerText = newMedicine.created;
                medicineNode.AppendChild(createdNode);

                XmlNode updatedNode = medicineDoc.CreateElement("medicine_updated");
                updatedNode.InnerText = newMedicine.updated;
                medicineNode.AppendChild(updatedNode);

                XmlNode deletedNode = medicineDoc.CreateElement("medicine_deleted");
                deletedNode.InnerText = newMedicine.deleted;
                medicineNode.AppendChild(deletedNode);

                XmlNode categoryIdNode = medicineDoc.CreateElement("category_id");
                categoryIdNode.InnerText = newMedicine.category.id;
                medicineNode.AppendChild(categoryIdNode);

                medicineDoc.SelectSingleNode("/medicines").AppendChild(medicineNode);
                medicineDoc.Save(Config.getXMLPath("medicines"));
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }
        public int Restore(string id)
        {
            ReloadData();
            try
            {
                XmlNode medicineNode = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']");
                if (medicineNode != null)
                {
                    medicineNode.SelectSingleNode("medicine_deleted").InnerText = "";
                    medicineDoc.Save(Config.getXMLPath("medicines"));
                    return Predefined.SUCCESS;
                }
                return Predefined.ID_NOT_EXIST;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        public int Delete(string id)
        {
            ReloadData();
            try
            {
                XmlNode medicineNode = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']");
                if (medicineNode != null)
                {
                    medicineNode.SelectSingleNode("medicine_deleted").InnerText = CustomDateTime.GetNow();
                    medicineDoc.Save(Config.getXMLPath("medicines"));
                    return Predefined.SUCCESS;
                }
                return Predefined.ID_NOT_EXIST;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }
        public int ForceDelete(string id)
        {
            ReloadData();
            try
            {
                XmlNode medicineNode = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']");
                if (medicineNode != null)
                {
                    medicineDoc.SelectSingleNode("/medicines").RemoveChild(medicineNode);
                    medicineDoc.Save(Config.getXMLPath("medicines"));
                    return Predefined.SUCCESS;
                }
                return Predefined.ID_NOT_EXIST;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        internal int RestoreAll()
        {
            ReloadData();
            try
            {
                XmlNodeList medicineNodes = medicineDoc.SelectNodes("/medicines/medicine");
                foreach (XmlNode medicineNode in medicineNodes)
                {
                    medicineNode.SelectSingleNode("medicine_deleted").InnerText = "";
                }
                medicineDoc.Save(Config.getXMLPath("medicines"));
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        internal int ChangeImage(string id, string targetPath)
        {
            ReloadData();
            try
            {
            XmlNode node = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']/medicine_image");

            node.InnerText = targetPath;
            medicineDoc.Save(Config.getXMLPath("medicines"));
            return Predefined.SUCCESS;

            } catch (XmlException)
            {
                return Predefined.FILE_NOT_FOUND;
            }


        }

        internal int RemoveImage(string medicineId)
        {
            ReloadData();
            try
            {
                XmlNode node = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + medicineId + "']/medicine_image");
                node.InnerText = "";
                medicineDoc.Save(Config.getXMLPath("medicines"));
                return Predefined.SUCCESS;
            }
            catch (XmlException)
            {
                return Predefined.FILE_NOT_FOUND;
            }
        }
    }
}

