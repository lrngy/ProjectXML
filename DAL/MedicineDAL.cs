﻿namespace QPharma.DAL;

public class MedicineDAL
{
    private readonly CategoryDAL categoryDAL;
    private readonly MedicineLocationDAL medicineLocationDAL;
    private readonly SupplierDAL supplierDAL;
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
                var quantity = decimal.Parse(dr["medicine_quantity"].ToString());
                var price_out = decimal.Parse(dr["medicine_price_out"].ToString());
                var categoryId = dr["category_id"].ToString();
                var medicine_type = dr["medicine_type"].ToString() == "1";
                var unit = dr["medicine_unit"].ToString();
                var mfgDate = DateTime.Parse(dr["medicine_mfg"].ToString()).ToString("dd/MM/yyyy");
                var expireDate = DateTime.Parse(dr["medicine_expire_date"].ToString()).ToString("dd/MM/yyyy");
                var supplierId = dr["supplier_id"].ToString();
                var price_in = decimal.Parse(dr["medicine_price_in"].ToString());
                var location = dr["medicine_location_id"].ToString();
                var description = dr["medicine_description"].ToString();
                var created = !string.IsNullOrEmpty(dr["medicine_created"].ToString()) ? DateTime.Parse(dr["medicine_created"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var updated = !string.IsNullOrEmpty(dr["medicine_updated"].ToString()) ? DateTime.Parse(dr["medicine_updated"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var deleted = !string.IsNullOrEmpty(dr["medicine_deleted"].ToString()) ? DateTime.Parse(dr["medicine_deleted"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var image = dr["medicine_image"].ToString();

                var supplier = supplierDAL.GetById(supplierId);
                var category = categoryDAL.GetById(categoryId);
                var medicineLocation = medicineLocationDAL.GetById(location);

                if (supplier != null && !string.IsNullOrEmpty(supplier.deleted)) supplier = null;
                if (category != null && !string.IsNullOrEmpty(category.deleted)) category = null;
                if (medicineLocation != null && !string.IsNullOrEmpty(medicineLocation.deleted))
                    medicineLocation = null;


                var medicine = new MedicineDTO(id, name, quantity, price_out, category, medicine_type, unit, mfgDate,
                    expireDate, supplier, price_in, medicineLocation, description,
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
                new("@id", id)
            };
            var dt = DB.ExecuteQuery(query, sqlParameters);
            if (dt.Rows.Count != 0)
            {
                var dr = dt.Rows[0];
                var name = dr["medicine_name"].ToString();
                var quantity = decimal.Parse(dr["medicine_quantity"].ToString());
                var price_out = decimal.Parse(dr["medicine_price_out"].ToString());
                var categoryId = dr["category_id"].ToString();
                var medicine_type = dr["medicine_type"].ToString() == "1";
                var unit = dr["medicine_unit"].ToString();
                var mfgDate = DateTime.Parse(dr["medicine_mfg"].ToString()).ToString("dd/MM/yyyy");
                var expireDate = DateTime.Parse(dr["medicine_expire_date"].ToString()).ToString("dd/MM/yyyy");
                var supplierId = dr["supplier_id"].ToString();
                var price_in = decimal.Parse(dr["medicine_price_in"].ToString());
                var location = dr["medicine_location_id"].ToString();
                var description = dr["medicine_description"].ToString();
                var created = !string.IsNullOrEmpty(dr["medicine_created"].ToString()) ? DateTime.Parse(dr["medicine_created"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var updated = !string.IsNullOrEmpty(dr["medicine_updated"].ToString()) ? DateTime.Parse(dr["medicine_updated"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var deleted = !string.IsNullOrEmpty(dr["medicine_deleted"].ToString()) ? DateTime.Parse(dr["medicine_deleted"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
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
                new("@id", medicine.id),
                new("@name", medicine.name),
                new("@mfg", medicine.mfgDate),
                new("@expire", medicine.expDate),
                new("@unit", medicine.unit),
                new("@priceIn", medicine.price_in),
                new("@priceOut", medicine.price_out),
                new("@quantity", medicine.quantity),
                new("@type", medicine.type),
                new("@image", medicine.imagePath),
                new("@description", medicine.description),
                new("@updated", medicine.updated),
                new("@supplier", medicine.supplier == null ? DBNull.Value : medicine.supplier.id),
                new("@category", medicine.category == null ? DBNull.Value : medicine.category.id),
                new("@location", medicine.location == null ? DBNull.Value : medicine.location.id)
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


    public int Insert(MedicineDTO medicine)
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
                new("@id", medicine.id),
                new("@name", medicine.name),
                new("@mfg", medicine.mfgDate),
                new("@expire", medicine.expDate),
                new("@unit", medicine.unit),
                new("@priceIn", medicine.price_in),
                new("@priceOut", medicine.price_out),
                new("@quantity", medicine.quantity),
                new("@type", medicine.type),
                new("@description", medicine.description),
                new("@created", medicine.created),
                new("@supplier", medicine.supplier == null ? DBNull.Value : medicine.supplier.id),
                new("@category", medicine.category == null ? DBNull.Value : medicine.category.id),
                new("@location", medicine.location == null ? DBNull.Value : medicine.location.id)
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
            SqlParameter[] sqlParameters =
            {
                new("@id", id)
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
                new("@id", id),
                new("@deleted", CustomDateTime.GetNow())
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
            var query = new Dictionary<string, SqlParameter[]>
            {

                {
                    "delete from suppliers_history where medicine_id = @id",
                    [
                        new ("@id", id)
                    ]

                },
                {
                    "delete from bill_details where medicine_id = @id",
                    [
                        new ("@id", id)
                    ]
                },
                {
                    "delete from medicines where medicine_id = @id",
                    [
                        new ("@id", id)
                    ]
                },
            };
            DB.ExecuteTransaction(query);
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
                new("@id", id),
                new("@path", targetPath)
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
                new("@id", id)
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