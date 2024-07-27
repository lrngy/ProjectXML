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
    public class CategoryDAL
    {
        public List<CategoryDTO> GetAll()
        {
            //ReloadData();
            var list = new List<CategoryDTO>();
            try
            {
                var query = "SELECT * FROM categories";
                var dt = DB.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["category_id"].ToString();
                    var name = dr["category_name"].ToString();
                    var note = dr["category_note"].ToString();
                    var status = bool.Parse(dr["category_status"].ToString());


                    var created = dr["category_created"].ToString();
                    var updated = dr["category_updated"].ToString();
                    var deleted = dr["category_deleted"].ToString();


                    var category = new CategoryDTO(id, name, note, status, created, updated, deleted);
                    list.Add(category);
                }
            }
            catch (Exception)
            {
            }

            return list;
        }

        public CategoryDTO GetById(string id)
        {
            //ReloadData();
            CategoryDTO category = null;
            try
            {
                var query = $"SELECT * FROM categories WHERE category_id = ${id}";
                var dt = DB.ExecuteQuery(query);
                if (dt.Rows.Count != 0)
                {
                    var deleted = dt.Rows[0]["category_deleted"].ToString();
                    if (!deleted.Equals("")) return category;
                    var name = dt.Rows[0]["category_name"].ToString();
                    var note = dt.Rows[0]["category_note"].ToString();
                    var status = bool.Parse(dt.Rows[0]["category_status"].ToString());
                    var created = dt.Rows[0]["category_created"].ToString();
                    var updated = dt.Rows[0]["category_updated"].ToString();
                    category = new CategoryDTO(id, name, note, status, created, updated, deleted);
                }
            }
            catch (Exception)
            {
            }

            return category;
        }

        public bool CheckExistName(string name)
        {
            //ReloadData();
            var query = "SELECT * FROM categories WHERE category_name = @name";
            SqlParameter[] sqlParameters = { new SqlParameter("@name", name) };
            var dt = DB.ExecuteQuery(query, sqlParameters);
            if (dt.Rows.Count == 0) return false;
            var deleted = dt.Rows[0]["category_deleted"].ToString();
            return deleted.Equals("");
        }


        public int Insert(CategoryDTO category)
        {
            try
            {
                var query =
                    "INSERT INTO categories(category_name, category_note, category_status, category_created) VALUES (@name, @note, @status, @created)";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@name", category.name),
                    new SqlParameter("@note", category.note),
                    new SqlParameter("@status", category.status),
                    new SqlParameter("@created", category.created)
                };
                DB.ExecuteNonQuery(query, sqlParameters);
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        public int Update(CategoryDTO category)
        {
            try
            {
                var query =
                    $"UPDATE categories SET category_name = @name, category_note = @note, category_status = @status, category_updated = @updated WHERE category_id = @id";
                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@name", category.name),
                    new SqlParameter("@note", category.note),
                    new SqlParameter("@status", category.status),
                    new SqlParameter("@updated", category.updated),
                    new SqlParameter("@id", category.id)
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

        public int Delete(string maTheLoai)
        {
            try
            {
                var query =
                    $"UPDATE categories SET category_deleted = @deleted WHERE category_id = @id";
                SqlParameter[] sqlParameters = {
                    new SqlParameter("@id", maTheLoai),
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

        internal int Restore(string maTheLoai)
        {
            try
            {
                var query = "UPDATE categories SET category_deleted = null WHERE category_id = @id";
                SqlParameter[] sqlParameters = {
                    new SqlParameter("@id", maTheLoai)
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

        internal int ForceDelete(string maTheLoai)
        {
            try
            {
                var query = $"DELETE FROM categories WHERE category_id = @id";
                SqlParameter[] sqlParameters = {
                        new SqlParameter("@id", maTheLoai)
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

        internal int RestoreAll()
        {
            try
            {
                var query = "UPDATE categories SET category_deleted = null";
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