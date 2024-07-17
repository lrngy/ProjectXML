using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.DAL
{
    public class CategoryDAL
    {
        private XmlDocument categoryDoc;

        internal void ReloadData()
        {
            categoryDoc = Config.getDoc("categories");
        }

        public List<CategoryDTO> GetAll()
        {
            ReloadData();
            var list = new List<CategoryDTO>();
            try
            {
                string query = "SELECT * FROM categories";
                DataTable dt = DB.ExecuteQuery(query);
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
            ReloadData();
            CategoryDTO category = null;
            try
            {
                string query = $"SELECT * FROM categories WHERE category_id = ${id}";
                DataTable dt = DB.ExecuteQuery(query);
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

        public bool CheckExist(string id)
        {
            ReloadData();
            string query = $"SELECT * FROM categories WHERE category_id = ${id}";
            DataTable dt = DB.ExecuteQuery(query);
            if (dt.Rows.Count == 0) return false;
            var deleted = dt.Rows[0]["category_deleted"].ToString();
            return deleted.Equals("");
            }
        

        public int Insert(CategoryDTO category)
        {
            ReloadData();
            try
            {
                //XmlNode categoryNode = categoryDoc.CreateElement("category");

                //XmlNode idNode = categoryDoc.CreateElement("category_id");
                //idNode.InnerText = category.id;
                //categoryNode.AppendChild(idNode);

                //XmlNode nameNode = categoryDoc.CreateElement("category_name");
                //nameNode.InnerText = category.name;
                //categoryNode.AppendChild(nameNode);

                //XmlNode noteNode = categoryDoc.CreateElement("category_note");
                //noteNode.InnerText = category.note;
                //categoryNode.AppendChild(noteNode);

                //XmlNode statusNode = categoryDoc.CreateElement("category_status");
                //statusNode.InnerText = category.status.ToString();
                //categoryNode.AppendChild(statusNode);

                //XmlNode createdNode = categoryDoc.CreateElement("category_created");
                //createdNode.InnerText = category.created;
                //categoryNode.AppendChild(createdNode);

                //XmlNode updatedNode = categoryDoc.CreateElement("category_updated");
                //updatedNode.InnerText = category.updated;
                //categoryNode.AppendChild(updatedNode);

                //XmlNode deletedNode = categoryDoc.CreateElement("category_deleted");
                //deletedNode.InnerText = category.deleted;
                //categoryNode.AppendChild(deletedNode);

                //categoryDoc.SelectSingleNode("/categories").AppendChild(categoryNode);
                //categoryDoc.Save(Config.getXMLPath("categories"));

                string query = $"INSERT INTO categories VALUES ('{category.id}', '{category.name}', '{category.note}', {category.status}, '{category.created}', '{category.updated}', '{category.deleted}')";
                DB.ExecuteNonQuery(query);


                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        public int Update(CategoryDTO category)
        {
            ReloadData();
            try
            {
                //var categories = categoryDoc.SelectSingleNode("/categories");
                //var categoryNode =
                //    categoryDoc.SelectSingleNode("/categories/category[category_id='" + category.id + "']");
                //categoryNode.SelectSingleNode("category_name").InnerText = category.name;
                //categoryNode.SelectSingleNode("category_note").InnerText = category.note;
                //categoryNode.SelectSingleNode("category_status").InnerText = category.status.ToString();
                //categoryNode.SelectSingleNode("category_updated").InnerText = category.updated;
                //categoryDoc.Save(Config.getXMLPath("categories"));

                string query = $"UPDATE categories SET category_name = '{category.name}', category_note = '{category.note}', category_status = {category.status}, category_updated = '{category.updated}' WHERE category_id = '{category.id}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        public int Delete(string maTheLoai)
        {
            ReloadData();
            try
            {
                //var categoryNode =
                //    categoryDoc.SelectSingleNode("/categories/category[category_id='" + maTheLoai + "']");
                //categoryNode.SelectSingleNode("category_deleted").InnerText = CustomDateTime.GetNow();
                //categoryDoc.Save(Config.getXMLPath("categories"));

                string query = $"UPDATE categories SET category_deleted = '{CustomDateTime.GetNow()}' WHERE category_id = '{maTheLoai}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        internal int Restore(string maTheLoai)
        {
            ReloadData();
            try
            {
                //var categoryNode =
                //    categoryDoc.SelectSingleNode("/categories/category[category_id='" + maTheLoai + "']");
                //categoryNode.SelectSingleNode("category_deleted").InnerText = "";
                //categoryDoc.Save(Config.getXMLPath("categories"));

                string query = $"UPDATE categories SET category_deleted = '' WHERE category_id = '{maTheLoai}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        internal int ForceDelete(string maTheLoai)
        {
            ReloadData();
            try
            {
                //var categoryNode =
                //    categoryDoc.SelectSingleNode("/categories/category[category_id='" + maTheLoai + "']");
                //categoryNode.ParentNode.RemoveChild(categoryNode);
                //categoryDoc.Save(Config.getXMLPath("categories"));

                string query = $"DELETE FROM categories WHERE category_id = '{maTheLoai}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
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
                //var categoryNodes = categoryDoc.SelectNodes("/categories/category");
                //foreach (XmlNode categoryNode in categoryNodes)
                //    categoryNode.SelectSingleNode("category_deleted").InnerText = "";
                //categoryDoc.Save(Config.getXMLPath("categories"));

                string query = $"UPDATE categories SET category_deleted = ''";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }
    }
}