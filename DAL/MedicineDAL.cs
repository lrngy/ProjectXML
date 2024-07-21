using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.DAL
{
    public class MedicineDAL
    {
        private readonly CategoryDAL categoryDAL;
        private XmlDocument medicineDoc;
        private readonly SupplierDAL supplierDAL;

        public MedicineDAL()
        {
            supplierDAL = new SupplierDAL();
            categoryDAL = new CategoryDAL();
        }

        public MedicineDAL(CategoryDAL categoryDAL, SupplierDAL supplierDAL)
        {
            this.supplierDAL = supplierDAL;
            this.categoryDAL = categoryDAL;
        }

        public void ReloadData()
        {
            medicineDoc = Config.getDoc("medicines");
        }

        public List<MedicineDTO> GetAll()
        {
            ReloadData();
            List<MedicineDTO> medicines = new List<MedicineDTO>();
            try
            {
                string query = "select * from medicines";
               DataTable dt = DB.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["medicine_id"].ToString();
                    string name = dr["medicine_name"].ToString();
                    string expire = dr["medicine_expire_date"].ToString();
                    string unit = dr["medicine_unit"].ToString();
                    double price_in = double.Parse(dr["medicine_price_in"].ToString());
                    double price_out = double.Parse(dr["medicine_price_out"].ToString());
                    int quantity = int.Parse(dr["medicine_quantity"].ToString());
                    string image = dr["medicine_image"].ToString();
                    string description = dr["medicine_description"].ToString();
                    string supplierId = dr["supplier_id"].ToString();
                    string created = dr["medicine_created"].ToString();
                    string updated = dr["medicine_updated"].ToString();
                    string deleted = dr["medicine_deleted"].ToString();
                    string categoryId = dr["category_id"].ToString();
                    string medicine_location = dr["medicine_location_id"].ToString();
                    bool medicine_type = dr["medicine_type"].ToString() == "1";
                    

                    SupplierDTO supplier = supplierDAL.GetById(supplierId);
                    CategoryDTO category = categoryDAL.GetById(categoryId);
                    MedicineLocationDTO medicineLocation = new MedicineLocationDTO();
                    MedicineDTO medicine = new MedicineDTO(id, name, expire, unit, price_in, price_out, quantity, medicine_type, image, description,  created, updated, deleted, supplier,category, medicineLocation);
                    medicines.Add(medicine);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return medicines;
        }

        internal MedicineDTO GetById(string id)
        {
            ReloadData();
            MedicineDTO medicine = null;
            try
            {
                string query = "select * from medicines where medicine_id = " + id;
                DataTable dt = DB.ExecuteQuery(query);
                //var medicineNode = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']");
                if (dt.Rows.Count != 0)
                {
                    var name = dt.Rows[0]["medicine_name"].ToString();
                    var expire = dt.Rows[0]["medicine_expire_date"].ToString();
                    var unit = dt.Rows[0]["medicine_unit"].ToString();
                    var price = double.Parse(dt.Rows[0]["medicine_price"].ToString());
                    var quantity = int.Parse(dt.Rows[0]["medicine_quantity"].ToString());
                    var image = dt.Rows[0]["medicine_image"].ToString();
                    var description = dt.Rows[0]["medicine_description"].ToString();
                    var supplierId = dt.Rows[0]["supplier_id"].ToString();
                    var created = dt.Rows[0]["medicine_created"].ToString();
                    var updated = dt.Rows[0]["medicine_updated"].ToString();
                    var deleted = dt.Rows[0]["medicine_deleted"].ToString();
                    var categoryId = dt.Rows[0]["category_id"].ToString();


                    var supplier = supplierDAL.GetById(supplierId);
                    var category = categoryDAL.GetById(categoryId);

                    medicine = new MedicineDTO(id, name, expire, unit, price, quantity, image, description,
                        created, updated, deleted, supplier,category);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return medicine;
        }

        public int Update(MedicineDTO medicine)
        {
            ReloadData();
            try
            {
                var medicineNode =
                    medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + medicine.id + "']");
                if (medicineNode != null)
                {
                    medicineNode.SelectSingleNode("medicine_name").InnerText = medicine.name;
                    medicineNode.SelectSingleNode("medicine_expire_date").InnerText = medicine.expireDate;
                    medicineNode.SelectSingleNode("medicine_unit").InnerText = medicine.unit;
                    medicineNode.SelectSingleNode("medicine_price").InnerText = medicine.price_out.ToString();
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
                return Predefined.ERROR;
            }
        }


        internal int Insert(MedicineDTO newMedicine)
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
                priceNode.InnerText = newMedicine.price_out.ToString();
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
                return Predefined.ERROR;
            }
        }

        public int Restore(string id)
        {
            ReloadData();
            try
            {
                var medicineNode = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']");
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
                return Predefined.ERROR;
            }
        }

        public int Delete(string id)
        {
            ReloadData();
            try
            {
                var medicineNode = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']");
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
                return Predefined.ERROR;
            }
        }

        public int ForceDelete(string id)
        {
            ReloadData();
            try
            {
                var medicineNode = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']");
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
                return Predefined.ERROR;
            }
        }

        internal int RestoreAll()
        {
            ReloadData();
            try
            {
                var medicineNodes = medicineDoc.SelectNodes("/medicines/medicine");
                foreach (XmlNode medicineNode in medicineNodes)
                    medicineNode.SelectSingleNode("medicine_deleted").InnerText = "";
                medicineDoc.Save(Config.getXMLPath("medicines"));
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        internal int ChangeImage(string id, string targetPath)
        {
            ReloadData();
            try
            {
                var node = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + id + "']/medicine_image");

                node.InnerText = targetPath;
                medicineDoc.Save(Config.getXMLPath("medicines"));
                return Predefined.SUCCESS;
            }
            catch (XmlException)
            {
                return Predefined.ERROR;
            }
        }

        internal int RemoveImage(string medicineId)
        {
            ReloadData();
            try
            {
                var node = medicineDoc.SelectSingleNode("/medicines/medicine[medicine_id='" + medicineId +
                                                        "']/medicine_image");
                node.InnerText = "";
                medicineDoc.Save(Config.getXMLPath("medicines"));
                return Predefined.SUCCESS;
            }
            catch (XmlException)
            {
                return Predefined.ERROR;
            }
        }
    }
}