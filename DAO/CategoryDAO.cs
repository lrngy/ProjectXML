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
    public class CategoryDAO
    {
        XmlDocument categoryDoc;

        internal void ReloadData()
        {
            categoryDoc = Config.getDoc("categories");
        }
        public List<Category> GetAll()
        {

            ReloadData();
            List<Category> list = new List<Category>();
            try
            {
                XmlNodeList categoryNodes = categoryDoc.SelectNodes("/categories/category");
                foreach (XmlNode categoryNode in categoryNodes)
                {
                    string id = categoryNode.SelectSingleNode("category_id").InnerText;
                    string name = categoryNode.SelectSingleNode("category_name").InnerText;
                    string note = categoryNode.SelectSingleNode("category_note").InnerText;
                    bool status = bool.Parse(categoryNode.SelectSingleNode("category_status").InnerText);


                    string created = categoryNode.SelectSingleNode("category_created").InnerText;
                    string updated = categoryNode.SelectSingleNode("category_updated").InnerText;
                    string deleted = categoryNode.SelectSingleNode("category_deleted").InnerText;


                    Category category = new Category(id, name, note, status, created, updated, deleted);
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
                XmlNode categoryNode = categoryDoc.SelectSingleNode("/categories/category[category_id='" + id + "']");
                if (categoryNode != null)
                {
                    string deleted = categoryNode.SelectSingleNode("category_deleted").InnerText;
                    if (!deleted.Equals(""))
                    {
                        return category;
                    }
                    string name = categoryNode.SelectSingleNode("category_name").InnerText;
                    string note = categoryNode.SelectSingleNode("category_note").InnerText;
                    bool status = bool.Parse(categoryNode.SelectSingleNode("category_status").InnerText);
                    string created = categoryNode.SelectSingleNode("category_created").InnerText;
                    string updated = categoryNode.SelectSingleNode("category_updated").InnerText;
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
            XmlNode categoryNode = categoryDoc.SelectSingleNode("/categories/category[category_id='" + id + "']");
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
                XmlNode categories = categoryDoc.SelectSingleNode("/categories");
                XmlNode categoryNode = categoryDoc.SelectSingleNode("/categories/category[category_id='" + category.id + "']");
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
                XmlNode categoryNode = categoryDoc.SelectSingleNode("/categories/category[category_id='" + maTheLoai + "']");
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
                XmlNode categoryNode = categoryDoc.SelectSingleNode("/categories/category[category_id='" + maTheLoai + "']");
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
                XmlNode categoryNode = categoryDoc.SelectSingleNode("/categories/category[category_id='" + maTheLoai + "']");
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
                XmlNodeList categoryNodes = categoryDoc.SelectNodes("/categories/category");
                foreach (XmlNode categoryNode in categoryNodes)
                {
                    categoryNode.SelectSingleNode("category_deleted").InnerText = "";
                }
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
