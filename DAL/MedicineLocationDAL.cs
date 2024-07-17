﻿using ProjectXML.DTO;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.DAL
{
    internal class MedicineLocationDAL
    {
        public List<MedicineLocationDTO> GetAll()
        {
            var list = new List<MedicineLocationDTO>();
            try
            {
                DataTable dt = DB.ExecuteQuery("SELECT * FROM medicine_locations");
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["medicine_location_id"].ToString();
                    var name = dr["medicine_location_name"].ToString();
                    var note = dr["medicine_location_note"].ToString();
                    var status = bool.Parse(dr["medicine_location_status"].ToString());
                    var created = dr["medicine_location_created"].ToString();
                    var updated = dr["medicine_location_updated"].ToString();
                    var deleted = dr["medicine_location_deleted"].ToString();

                    var medicineLocation = new MedicineLocationDTO(id, name, note, status, created, updated, deleted);
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
                string query = "SELECT * FROM medicine_locations WHERE medicine_location_id = " + id;
                DataTable dt = DB.ExecuteQuery("SELECT * FROM medicine_locations WHERE medicine_location_id = " + id);
                if (dt.Rows.Count != 0)
                {
                    var name = dt.Rows[0]["medicine_location_name"].ToString();
                    var note = dt.Rows[0]["medicine_location_note"].ToString();
                    var status = bool.Parse(dt.Rows[0]["medicine_location_status"].ToString());
                    var created = dt.Rows[0]["medicine_location_created"].ToString();
                    var updated = dt.Rows[0]["medicine_location_updated"].ToString();
                    var deleted = dt.Rows[0]["medicine_location_deleted"].ToString();

                    medicineLocationDTO = new MedicineLocationDTO(id, name, note, status, created, updated, deleted);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return medicineLocationDTO;
        }

        public bool Insert(MedicineLocationDTO medicineLocationDTO)
        {
            try
            {
                string query = "INSERT INTO medicine_locations (medicine_location_name, medicine_location_note, medicine_location_status, medicine_location_created, medicine_location_updated, medicine_location_deleted) VALUES ('" + medicineLocationDTO.name + "', '" + medicineLocationDTO.note + "', " + medicineLocationDTO.status + ", '" + medicineLocationDTO.created + "', '" + medicineLocationDTO.updated + "', '" + medicineLocationDTO.deleted + "')";
                DB.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public int Update(MedicineLocationDTO medicineLocationDTO)
        {
            try
            {
                string query = "UPDATE medicine_locations SET medicine_location_name = '" + medicineLocationDTO.name + "', medicine_location_note = '" + medicineLocationDTO.note + "', medicine_location_status = " + medicineLocationDTO.status + ", medicine_location_created = '" + medicineLocationDTO.created + "', medicine_location_updated = '" + medicineLocationDTO.updated + "', medicine_location_deleted = '" + medicineLocationDTO.deleted + "' WHERE medicine_location_id = " + medicineLocationDTO.id;
                DB.ExecuteNonQuery(query);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        public int Delete(string id)
        {
            try
            {
                string query = "UPDATE medicine_locations SET medicine_location_deleted = '" + CustomDateTime.GetNow() + "' WHERE medicine_location_id = " + id;
                DB.ExecuteNonQuery(query);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        public int RestoreAll()
        {
            try
            {
                string query = "UPDATE medicine_locations SET medicine_location_deleted = ''";
                DB.ExecuteNonQuery(query);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }

        }

        public int ForceDelete(string id)
        {
            try
            {
                string query = "DELETE FROM medicine_locations WHERE medicine_location_id = " + id;
                DB.ExecuteNonQuery(query);
                return Predefined.SUCCESS;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }
    }
}



