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
    public class SupplierDAO
    {
        XmlDocument supplierDoc = Config.getDoc("suppliers");

        public List<Supplier> GetAll()
        {
            List<Supplier> list = new List<Supplier>();
            try
            {
                XmlNodeList supplierNodes = supplierDoc.SelectNodes("/suppliers/supplier");
                foreach (XmlNode supplierNode in supplierNodes)
                {
                    string id = supplierNode.SelectSingleNode("supplier_id").InnerText;
                    string name = supplierNode.SelectSingleNode("supplier_name").InnerText;
                    string address = supplierNode.SelectSingleNode("supplier_address").InnerText;
                    string phone = supplierNode.SelectSingleNode("supplier_phone").InnerText;
                    string email = supplierNode.SelectSingleNode("supplier_email").InnerText;
                    string note = supplierNode.SelectSingleNode("supplier_note").InnerText;
                    bool status = bool.Parse(supplierNode.SelectSingleNode("supplier_status").InnerText);
                    string created = supplierNode.SelectSingleNode("supplier_created").InnerText;
                    string updated = supplierNode.SelectSingleNode("supplier_updated").InnerText;
                    string deleted = supplierNode.SelectSingleNode("supplier_deleted").InnerText;

                    Supplier supplier = new Supplier(id, name, phone, email, address, note, status, created, updated, deleted);
                    list.Add(supplier);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return list;
        }

        public Supplier GetById(string id)
        {
            Supplier supplier = null;
            try
            {
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                if (supplierNode != null)
                {
                    string deleted = supplierNode.SelectSingleNode("supplier_deleted").InnerText;
                    if (!deleted.Equals(""))
                    {
                        return supplier;
                    }
                    string name = supplierNode.SelectSingleNode("supplier_name").InnerText;
                    string address = supplierNode.SelectSingleNode("supplier_address").InnerText;
                    string phone = supplierNode.SelectSingleNode("supplier_phone").InnerText;
                    string email = supplierNode.SelectSingleNode("supplier_email").InnerText;
                    string note = supplierNode.SelectSingleNode("supplier_note").InnerText;
                    bool status = bool.Parse(supplierNode.SelectSingleNode("supplier_status").InnerText);
                    string created = supplierNode.SelectSingleNode("supplier_created").InnerText;
                    string updated = supplierNode.SelectSingleNode("supplier_updated").InnerText;

                    supplier = new Supplier(id, name, phone, email, address, note, status, created, updated, deleted);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return supplier;
        }

        public int Insert(Supplier supplier)
        {
            try
            {
                XmlNode supplierNode = supplierDoc.CreateElement("supplier");

                XmlNode idNode = supplierDoc.CreateElement("supplier_id");
                idNode.InnerText = supplier.id;
                supplierNode.AppendChild(idNode);

                XmlNode nameNode = supplierDoc.CreateElement("supplier_name");
                nameNode.InnerText = supplier.name;
                supplierNode.AppendChild(nameNode);

                XmlNode addressNode = supplierDoc.CreateElement("supplier_address");
                addressNode.InnerText = supplier.address;
                supplierNode.AppendChild(addressNode);


                XmlNode noteNode = supplierDoc.CreateElement("supplier_note");
                noteNode.InnerText = supplier.note;
                supplierNode.AppendChild(noteNode);


                XmlNode phoneNode = supplierDoc.CreateElement("supplier_phone");
                phoneNode.InnerText = supplier.phone;
                supplierNode.AppendChild(phoneNode);

                XmlNode emailNode = supplierDoc.CreateElement("supplier_email");
                emailNode.InnerText = supplier.email;
                supplierNode.AppendChild(emailNode);

                XmlNode statusNode = supplierDoc.CreateElement("supplier_status");
                statusNode.InnerText = supplier.status.ToString();
                supplierNode.AppendChild(statusNode);

                XmlNode createdNode = supplierDoc.CreateElement("supplier_created");
                createdNode.InnerText = supplier.created;
                supplierNode.AppendChild(createdNode);

                XmlNode updatedNode = supplierDoc.CreateElement("supplier_updated");
                updatedNode.InnerText = supplier.updated;
                supplierNode.AppendChild(updatedNode);

                XmlNode deletedNode = supplierDoc.CreateElement("supplier_deleted");
                deletedNode.InnerText = supplier.deleted;
                supplierNode.AppendChild(deletedNode);

                supplierDoc.SelectSingleNode("/suppliers").AppendChild(supplierNode);
                supplierDoc.Save(Config.getPath("suppliers"));
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        public int Update(Supplier supplier)
        {
            try
            {
                XmlNode suppliers = supplierDoc.SelectSingleNode("/suppliers");
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + supplier.id + "']");
                supplierNode.SelectSingleNode("supplier_name").InnerText = supplier.name;
                supplierNode.SelectSingleNode("supplier_address").InnerText = supplier.address;
                supplierNode.SelectSingleNode("supplier_phone").InnerText = supplier.phone;
                supplierNode.SelectSingleNode("supplier_email").InnerText = supplier.email;
                supplierNode.SelectSingleNode("supplier_status").InnerText = supplier.status.ToString();
                supplierNode.SelectSingleNode("supplier_updated").InnerText = supplier.updated;


                supplierDoc.Save(Config.getPath("suppliers"));
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        public int Delete(string id)
        {
            try
            {
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                supplierNode.SelectSingleNode("supplier_deleted").InnerText = CustomDateTime.GetNow();
                supplierDoc.Save(Config.getPath("suppliers"));
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        internal int Restore(string id)
        {
            try
            {
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                supplierNode.SelectSingleNode("supplier_deleted").InnerText = "";
                supplierDoc.Save(Config.getPath("suppliers"));
                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.FILE_NOT_FOUND;
            }
        }

        internal int ForceDelete(string id)
        {
            try
            {
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                supplierNode.ParentNode.RemoveChild(supplierNode);
                supplierDoc.Save(Config.getPath("suppliers"));
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




