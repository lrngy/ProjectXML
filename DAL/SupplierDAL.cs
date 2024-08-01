using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml;
using QPharma.DTO;
using QPharma.Util;

namespace QPharma.DAL
{
    public class SupplierDAL
    {
        private XmlDocument supplierDoc;

        public List<SupplierDTO> GetAll()
        {
            var list = new List<SupplierDTO>();
            try
            {
                var query = "SELECT * FROM suppliers";
                var dt = DB.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["supplier_id"].ToString();
                    var name = dr["supplier_name"].ToString();
                    var phone = dr["supplier_phone"].ToString();
                    var email = dr["supplier_email"].ToString();
                    var note = dr["supplier_note"].ToString();
                    var status = bool.Parse(dr["supplier_status"].ToString());
                    var created = dr["supplier_created"].ToString();
                    var updateed = dr["supplier_updated"].ToString();
                    var deleted = dr["supplier_deleted"].ToString();


                    var supplier = new SupplierDTO(id, name, phone, email, note, status, created, updateed, deleted);
                    list.Add(supplier);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return list;
        }

        public SupplierDTO GetById(string id)
        {
            SupplierDTO supplier = null;
            try
            {
                var query = "SELECT * FROM suppliers WHERE supplier_id = @id";
                SqlParameter[] sqlParameters = { new SqlParameter("@id", id) };
                var dt = DB.ExecuteQuery(query, sqlParameters);
                if (dt.Rows.Count != 0)
                {
                    var name = dt.Rows[0]["supplier_name"].ToString();
                    var phone = dt.Rows[0]["supplier_phone"].ToString();
                    var email = dt.Rows[0]["supplier_email"].ToString();
                    var note = dt.Rows[0]["supplier_note"].ToString();
                    var status = bool.Parse(dt.Rows[0]["supplier_status"].ToString());
                    var created = dt.Rows[0]["supplier_created"].ToString();
                    var updated = dt.Rows[0]["supplier_updated"].ToString();
                    var deleted = dt.Rows[0]["supplier_deleted"].ToString();

                    supplier = new SupplierDTO(id, name, phone, email, note, status, created, updated, deleted);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return supplier;
        }

        public int Insert(SupplierDTO supplier)
        {
            try
            {
                var query = "INSERT INTO suppliers" +
                            "(supplier_id, supplier_name, supplier_note, supplier_phone, supplier_email, supplier_status, supplier_created)" +
                            "VALUES (@id, @name, @note, @phone, @email, @status, @created)";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", supplier.id),
                    new SqlParameter("@name", supplier.name),
                    new SqlParameter("@note", supplier.note),
                    new SqlParameter("@phone", supplier.phone),
                    new SqlParameter("@email", supplier.email),
                    new SqlParameter("@status", supplier.status),
                    new SqlParameter("@created", supplier.created)
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

        public int Update(SupplierDTO supplier)
        {
            try
            {
                var query =
                    "UPDATE suppliers SET supplier_name = @name, supplier_phone = @phone, supplier_email = @email, " +
                    "supplier_note = @note, supplier_status = @status, supplier_updated = @updated WHERE supplier_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", supplier.id),
                    new SqlParameter("@name", supplier.name),
                    new SqlParameter("@note", supplier.note),
                    new SqlParameter("@phone", supplier.phone),
                    new SqlParameter("@email", supplier.email),
                    new SqlParameter("@status", supplier.status),
                    new SqlParameter("@updated", supplier.updated)
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
                var query = "UPDATE suppliers SET supplier_deleted = @deleted WHERE supplier_id = @id";
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

        internal int Restore(string id)
        {
            try
            {
                var query = "UPDATE suppliers SET supplier_deleted = null WHERE supplier_id = @id";
                SqlParameter[] sqlParameter =
                {
                    new SqlParameter("@id", id)
                };
                DB.ExecuteNonQuery(query, sqlParameter);

                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        internal int ForceDelete(string id)
        {
            try
            {
                var query = "DELETE FROM suppliers WHERE supplier_id = @id";
                SqlParameter[] sqlParameter =
                {
                    new SqlParameter("@id", id)
                };
                DB.ExecuteNonQuery(query, sqlParameter);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        internal int RestoreAll()
        {
            try
            {
                var query = "UPDATE suppliers SET supplier_deleted = null where supplier_deleted is not null";
                DB.ExecuteNonQuery(query);

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