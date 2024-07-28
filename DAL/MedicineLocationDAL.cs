using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using QPharma.DTO;
using QPharma.Util;

namespace QPharma.DAL
{
    internal class MedicineLocationDAL
    {
        public List<MedicineLocationDTO> GetAll()
        {
            var list = new List<MedicineLocationDTO>();
            try
            {
                var dt = DB.ExecuteQuery("SELECT * FROM medicine_locations");
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["medicine_location_id"].ToString();
                    var name = dr["medicine_location_name"].ToString();
                    var note = dr["medicine_location_note"].ToString();
                    var status = bool.Parse(dr["medicine_location_status"].ToString());
                    var created = dr["medicine_location_created"].ToString();
                    var updated = dr["medicine_location_updated"].ToString();
                    var deleted = dr["medicine_location_deleted"].ToString();

                    var medicineLocation = new MedicineLocationDTO(name, note, status, created, updated, deleted, id);
                    list.Add(medicineLocation);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return list;
        }

        public MedicineLocationDTO GetById(string id)
        {
            MedicineLocationDTO medicineLocationDTO = null;
            try
            {
                var query = "SELECT * FROM medicine_locations WHERE medicine_location_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@id", id)
                };
                var dt = DB.ExecuteQuery(query, sqlParameters);
                if (dt.Rows.Count != 0)
                {
                    var name = dt.Rows[0]["medicine_location_name"].ToString();
                    var note = dt.Rows[0]["medicine_location_note"].ToString();
                    var status = bool.Parse(dt.Rows[0]["medicine_location_status"].ToString());
                    var created = dt.Rows[0]["medicine_location_created"].ToString();
                    var updated = dt.Rows[0]["medicine_location_updated"].ToString();
                    var deleted = dt.Rows[0]["medicine_location_deleted"].ToString();
                    medicineLocationDTO = new MedicineLocationDTO(name, note, status, created, updated, deleted, id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return medicineLocationDTO;
        }

        public int Insert(MedicineLocationDTO medicineLocationDTO)
        {
            try
            {
                //var query =
                //    "INSERT INTO medicine_locations (medicine_location_name, medicine_location_note, medicine_location_status, medicine_location_created, medicine_location_updated, medicine_location_deleted) VALUES ('" +
                //    medicineLocationDTO.name + "', '" + medicineLocationDTO.note + "', " + medicineLocationDTO.status +
                //    ", '" + medicineLocationDTO.created + "', '" + medicineLocationDTO.updated + "', '" +
                //    medicineLocationDTO.deleted + "')";

                var query = "insert into medicine_locations" +
                            " (medicine_location_name, medicine_location_note, " +
                            "medicine_location_status, medicine_location_created) values " +
                            "(@name, @note, @status, @created)";
                SqlParameter[] sqlParameters =
                {

                    new SqlParameter("@name", medicineLocationDTO.name),
                    new SqlParameter("@note", medicineLocationDTO.note),
                    new SqlParameter("@status", medicineLocationDTO.status),
                    new SqlParameter("@created", medicineLocationDTO.created)
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


        public int Update(MedicineLocationDTO medicineLocationDTO)
        {
            try
            {
                var query = "update medicine_locations set " +
                            "medicine_location_name = @name, " +
                            "medicine_location_note = @note, " +
                            "medicine_location_status = @status, " +
                            "medicine_location_updated = @updated " +
                            "where medicine_location_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@name", medicineLocationDTO.name),
                    new SqlParameter("@note", medicineLocationDTO.note),
                    new SqlParameter("@status", medicineLocationDTO.status),
                    new SqlParameter("@updated", medicineLocationDTO.updated),
                    new SqlParameter("@id", medicineLocationDTO.id)
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
                //var query = "UPDATE medicine_locations SET medicine_location_deleted = '" + CustomDateTime.GetNow() +
                //            "' WHERE medicine_location_id = " + id;
                var query = "update medicine_locations set medicine_location_deleted = @deleted where medicine_location_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@deleted", CustomDateTime.GetNow()),
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
                var query = "UPDATE medicine_locations SET medicine_location_deleted = null";
                DB.ExecuteNonQuery(query);
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
                var query = "DELETE FROM medicine_locations WHERE medicine_location_id = @id";
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

        public bool CheckExistName(string medicineLocationName)
        {
            try
            {
                var query = "SELECT * FROM medicine_locations WHERE medicine_location_name = @name";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@name", medicineLocationName)
                };
                var dt = DB.ExecuteQuery(query, sqlParameters);
                return dt.Rows.Count != 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;

            }
        }
    }
}