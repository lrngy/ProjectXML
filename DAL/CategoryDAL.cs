using System;
using System.Collections.Generic;
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

        public List<Category> GetAll()
        {
            ReloadData();
            var list = new List<Category>();
            try
            {
                var categoryNodes = categoryDoc.SelectNodes("/categories/category");
                foreach (XmlNode categoryNode in categoryNodes)
                {
                    var id = categoryNode.SelectSingleNode("category_id").InnerText;
                    var name = categoryNode.SelectSingleNode("category_name").InnerText;
                    var note = categoryNode.SelectSingleNode("category_note").InnerText;
                    var status = bool.Parse(categoryNode.SelectSingleNode("category_status").InnerText);


                    var created = categoryNode.SelectSingleNode("category_created").InnerText;
                    var updated = categoryNode.SelectSingleNode("category_updated").InnerText;
                    var deleted = categoryNode.SelectSingleNode("category_deleted").InnerText;


                    var category = new Category(id, name, note, status, created, updated, deleted);
                    list.Add(category);
                }
            }
            catch (Exception)
            {
            }

            return list;
        }

        public Category GetById(string id)
        {
            ReloadData();
            Category category = null;
            try
            {
                var categoryNode = categoryDoc.SelectSingleNode("/categories/category[category_id='" + id + "']");
                if (categoryNode != null)
                {
                    var deleted = categoryNode.SelectSingleNode("category_deleted").InnerText;
                    if (!deleted.Equals("")) return category;
                    var name = categoryNode.SelectSingleNode("category_name").InnerText;
                    var note = categoryNode.SelectSingleNode("category_note").InnerText;
                    var status = bool.Parse(categoryNode.SelectSingleNode("category_status").InnerText);
                    var created = categoryNode.SelectSingleNode("category_created").InnerText;
                    var updated = categoryNode.SelectSingleNode("category_updated").InnerText;
                    category = new Category(id, name, note, status, created, updated, deleted);
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
            var categoryNode = categoryDoc.SelectSingleNode("/categories/category[category_id='" + id + "']");
            return categoryNode != null;
        }

        public int Insert(Category category)
        {
            ReloadData();
            try
            {
                XmlNode categoryNode = categoryDoc.CreateElement("category");

                XmlNode idNode = categoryDoc.CreateElement("category_id");
                idNode.InnerText = category.id;
                categoryNode.AppendChild(idNode);

                XmlNode nameNode = categoryDoc.CreateElement("category_name");
                nameNode.InnerText = category.name;
                categoryNode.AppendChild(nameNode);

                XmlNode noteNode = categoryDoc.CreateElement("category_note");
                noteNode.InnerText = category.note;
                categoryNode.AppendChild(noteNode);

                XmlNode statusNode = categoryDoc.CreateElement("category_status");
                statusNode.InnerText = category.status.ToString();
                categoryNode.AppendChild(statusNode);

                XmlNode createdNode = categoryDoc.CreateElement("category_created");
                createdNode.InnerText = category.created;
                categoryNode.AppendChild(createdNode);

                XmlNode updatedNode = categoryDoc.CreateElement("category_updated");
                updatedNode.InnerText = category.updated;
                categoryNode.AppendChild(updatedNode);

                XmlNode deletedNode = categoryDoc.CreateElement("category_deleted");
                deletedNode.InnerText = category.deleted;
                categoryNode.AppendChild(deletedNode);

                categoryDoc.SelectSingleNode("/categories").AppendChild(categoryNode);
                categoryDoc.Save(Config.getXMLPath("categories"));
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        public int Update(Category category)
        {
            ReloadData();
            try
            {
                var categories = categoryDoc.SelectSingleNode("/categories");
                var categoryNode =
                    categoryDoc.SelectSingleNode("/categories/category[category_id='" + category.id + "']");
                categoryNode.SelectSingleNode("category_name").InnerText = category.name;
                categoryNode.SelectSingleNode("category_note").InnerText = category.note;
                categoryNode.SelectSingleNode("category_status").InnerText = category.status.ToString();
                categoryNode.SelectSingleNode("category_updated").InnerText = category.updated;
                categoryDoc.Save(Config.getXMLPath("categories"));
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
                var categoryNode =
                    categoryDoc.SelectSingleNode("/categories/category[category_id='" + maTheLoai + "']");
                categoryNode.SelectSingleNode("category_deleted").InnerText = CustomDateTime.GetNow();
                categoryDoc.Save(Config.getXMLPath("categories"));
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
                var categoryNode =
                    categoryDoc.SelectSingleNode("/categories/category[category_id='" + maTheLoai + "']");
                categoryNode.SelectSingleNode("category_deleted").InnerText = "";
                categoryDoc.Save(Config.getXMLPath("categories"));
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
                var categoryNode =
                    categoryDoc.SelectSingleNode("/categories/category[category_id='" + maTheLoai + "']");
                categoryNode.ParentNode.RemoveChild(categoryNode);
                categoryDoc.Save(Config.getXMLPath("categories"));
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
                var categoryNodes = categoryDoc.SelectNodes("/categories/category");
                foreach (XmlNode categoryNode in categoryNodes)
                    categoryNode.SelectSingleNode("category_deleted").InnerText = "";
                categoryDoc.Save(Config.getXMLPath("categories"));
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