using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml;
using QPharma.BUS;
using QPharma.DTO;
using QPharma.Util;

namespace QPharma.DAL
{
    public class MedicineDAL
    {
        private readonly CategoryDAL categoryDAL;
        private readonly SupplierDAL supplierDAL;
        private readonly MedicineLocationDAL medicineLocationDAL;
        private XmlDocument medicineDoc;

        public MedicineDAL()
        {
            supplierDAL = new SupplierDAL();
            categoryDAL = new CategoryDAL();
            medicineLocationDAL = new MedicineLocationDAL();
        }


        public List<MedicineDTO> GetAll()
        {
            var medicines = new List<MedicineDTO>();
            try
            {
                var query = "select * from medicines";
                var dt = DB.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["medicine_id"].ToString();
                    var name = dr["medicine_name"].ToString();
                    var quantity = int.Parse(dr["medicine_quantity"].ToString());
                    var price_out = double.Parse(dr["medicine_price_out"].ToString());
                    var categoryId = dr["category_id"].ToString();
                    var medicine_type = dr["medicine_type"].ToString() == "1";
                    var unit = dr["medicine_unit"].ToString();
                    var mfgDate = dr["medicine_mfg"].ToString();
                    var expireDate = dr["medicine_expire_date"].ToString();
                    var supplierId = dr["supplier_id"].ToString();
                    var price_in = double.Parse(dr["medicine_price_in"].ToString());
                    var location = dr["medicine_location_id"].ToString();
                    var description = dr["medicine_description"].ToString();
                    var created = dr["medicine_created"].ToString();
                    var updated = dr["medicine_updated"].ToString();
                    var deleted = dr["medicine_deleted"].ToString();
                    var image = dr["medicine_image"].ToString();

                    var supplier = supplierDAL.GetById(supplierId);
                    var category = categoryDAL.GetById(categoryId);
                    var medicineLocation = medicineLocationDAL.GetById(location);

                    var medicine = new MedicineDTO(id, name, quantity, price_out, category, medicine_type, unit, mfgDate, expireDate, supplier, price_in, medicineLocation, description,
                        created, updated, deleted, image);
                    medicines.Add(medicine);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return medicines;
        }

        public MedicineDTO GetById(string id)
        {
            MedicineDTO medicine = null;
            try
            {
                var query = "select * from medicines where medicine_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", id)
                };
                var dt = DB.ExecuteQuery(query, sqlParameters);
                if (dt.Rows.Count != 0)
                {
                    var dr = dt.Rows[0];
                    var name = dr["medicine_name"].ToString();
                    var quantity = int.Parse(dr["medicine_quantity"].ToString());
                    var price_out = double.Parse(dr["medicine_price_out"].ToString());
                    var categoryId = dr["category_id"].ToString();
                    var medicine_type = dr["medicine_type"].ToString() == "1";
                    var unit = dr["medicine_unit"].ToString();
                    var mfgDate = dr["medicine_mfg"].ToString();
                    var expireDate = dr["medicine_expire_date"].ToString();
                    var supplierId = dr["supplier_id"].ToString();
                    var price_in = double.Parse(dr["medicine_price_in"].ToString());
                    var location = dr["medicine_location_id"].ToString();
                    var description = dr["medicine_description"].ToString();
                    var created = dr["medicine_created"].ToString();
                    var updated = dr["medicine_updated"].ToString();
                    var deleted = dr["medicine_deleted"].ToString();
                    var image = dr["medicine_image"].ToString();

                    var supplier = supplierDAL.GetById(supplierId);
                    var category = categoryDAL.GetById(categoryId);
                    var medicineLocation = medicineLocationDAL.GetById(location);

                    medicine = new MedicineDTO(id, name, quantity,
                        price_out, category, medicine_type,
                        unit, mfgDate, expireDate,
                        supplier, price_in, medicineLocation,
                        description, created, updated, deleted, image);

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
            try
            {
                var query = "UPDATE medicines " +
                            "SET medicine_name = @name, " +
                            "medicine_mfg = @mfg, " +
                            "medicine_expire_date = @expire," +
                            "medicine_unit = @unit," +
                            "medicine_price_in = @priceIn, " +
                            "medicine_price_out = @priceOut," +
                            "medicine_quantity = @quantity," +
                            "medicine_type = @type," +
                            "medicine_image = @image, " +
                            "medicine_description = @description," +
                            "medicine_updated = @updated," +
                            "supplier_id = @supplier," +
                            "category_id = @category," +
                            "medicine_location_id = @location WHERE medicine_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", medicine.id),
                    new SqlParameter("@name", medicine.name),
                    new SqlParameter("@mfg", medicine.mfgDate),
                    new SqlParameter("@expire", medicine.expireDate),
                    new SqlParameter("@unit", medicine.unit),
                    new SqlParameter("@priceIn", medicine.price_in),
                    new SqlParameter("@priceOut", medicine.price_out),
                    new SqlParameter("@quantity", medicine.quantity),
                    new SqlParameter("@type", medicine.type),
                    new SqlParameter("@image", medicine.image),
                    new SqlParameter("@description", medicine.description),
                    new SqlParameter("@updated", medicine.updated),
                    new SqlParameter("@supplier", medicine.supplier.id),
                    new SqlParameter("@category", medicine.category.id),
                    new SqlParameter("@location", medicine.location.id)
                };
                DB.ExecuteNonQuery(query, sqlParameters);
                return Predefined.SUCCESS;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return Predefined.ERROR;
            }
        }


        public int Insert(MedicineDTO newMedicine)
        {
            try
            {
                var query = "INSERT INTO medicines (" +
                            "medicine_id, " +
                            "medicine_name," +
                            "medicine_mfg," +
                            "medicine_expire_date, " +
                            "medicine_unit, " +
                            "medicine_price_in, " +
                            "medicine_price_out, " +
                            "medicine_quantity," +
                            "medicine_type, " +
                            "medicine_description," +
                            "medicine_created," +
                            "supplier_id, " +
                            "category_id," +
                            "medicine_location_id" +
                            ")" +
                            "VALUES(" +
                            "@id," +
                            "@name," +
                            "@mfg," +
                            "@expire," +
                            "@unit," +
                            "@priceIn," +
                            "@priceOut," +
                            "@quantity," +
                            "@type," +
                            "@description," +
                            "@created," +
                            "@supplier," +
                            "@category," +
                            "@location" +
                            ")";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", newMedicine.id),
                    new SqlParameter("@name", newMedicine.name),
                    new SqlParameter("@mfg", newMedicine.mfgDate),
                    new SqlParameter("@expire", newMedicine.expireDate),
                    new SqlParameter("@unit", newMedicine.unit),
                    new SqlParameter("@priceIn", newMedicine.price_in),
                    new SqlParameter("@priceOut", newMedicine.price_out),
                    new SqlParameter("@quantity", newMedicine.quantity),
                    new SqlParameter("@type", newMedicine.type),
                    new SqlParameter("@description", newMedicine.description),
                    new SqlParameter("@created", newMedicine.created),
                    new SqlParameter("@supplier", newMedicine.supplier.id),
                    new SqlParameter("@category", newMedicine.category.id),
                    new SqlParameter("@location", newMedicine.location.id)
                };
                DB.ExecuteNonQuery(query, sqlParameters);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        public int Restore(string id)
        {
            try
            {
                var query = "update medicines set medicine_deleted = null where medicine_id = @id";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };
                DB.ExecuteNonQuery(query, sqlParameters);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        public int Delete(string id)
        {
            try
            {
                var query = "update medicines set medicine_deleted = @deleted where medicine_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", id),
                    new SqlParameter("@deleted", CustomDateTime.GetNow())
                };
                DB.ExecuteNonQuery(query, sqlParameters);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        public int ForceDelete(string id)
        {
            try
            {
                var query = "delete from medicines where medicine_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", id)
                };
                DB.ExecuteNonQuery(query, sqlParameters);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        public int RestoreAll()
        {
            try
            {
                var query = "update medicines set medicine_deleted = null where medicine_deleted is not null";
                DB.ExecuteNonQuery(query);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        public int ChangeImage(string id, string targetPath)
        {
            try
            {
                var query = "update medicines set medicine_image = @path where medicine_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", id),
                    new SqlParameter("@path", targetPath)
                };
                DB.ExecuteNonQuery(query, sqlParameters);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        public int RemoveImage(string id)
        {
            try
            {
                var query = "update medicines set medicine_image = null where medicine_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", id)
                };
                DB.ExecuteNonQuery(query, sqlParameters);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }
    }
}