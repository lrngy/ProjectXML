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
        XmlDocument supplierDoc;
        public void ReloadData()
        {
            supplierDoc = Config.getDoc("suppliers");
        }

        public List<Supplier> GetAll()
        {
            ReloadData();
       
            List<Supplier> list = new List<Supplier>();
            try
            {
                XmlNodeList supplierNodes = supplierDoc.SelectNodes("/suppliers/supplier");
                foreach (XmlNode supplierNode in supplierNodes)
                {
                    string id = supplierNode.SelectSingleNode("supplier_id").InnerText;
                    string name = supplierNode.SelectSingleNode("supplier_name").InnerText;
                    string phone = supplierNode.SelectSingleNode("supplier_phone").InnerText;
                    string email = supplierNode.SelectSingleNode("supplier_email").InnerText;
                    string note = supplierNode.SelectSingleNode("supplier_note").InnerText;
                    bool status = bool.Parse(supplierNode.SelectSingleNode("supplier_status").InnerText);

                    Supplier supplier = new Supplier(id, name, phone, email, note, status);
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
            ReloadData();
            Supplier supplier = null;
            try
            {
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                if (supplierNode != null)
                {
                    string name = supplierNode.SelectSingleNode("supplier_name").InnerText;
                    string phone = supplierNode.SelectSingleNode("supplier_phone").InnerText;
                    string email = supplierNode.SelectSingleNode("supplier_email").InnerText;
                    string note = supplierNode.SelectSingleNode("supplier_note").InnerText;
                    bool status = bool.Parse(supplierNode.SelectSingleNode("supplier_status").InnerText);

                    supplier = new Supplier(id, name, phone, email, note, status);
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
            ReloadData();
            try
            {
                XmlNode supplierNode = supplierDoc.CreateElement("supplier");

                XmlNode idNode = supplierDoc.CreateElement("supplier_id");
                idNode.InnerText = supplier.id;
                supplierNode.AppendChild(idNode);

                XmlNode nameNode = supplierDoc.CreateElement("supplier_name");
                nameNode.InnerText = supplier.name;
                supplierNode.AppendChild(nameNode);


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


                supplierDoc.SelectSingleNode("/suppliers").AppendChild(supplierNode);
                supplierDoc.Save(Config.getXMLPath("suppliers"));
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
            ReloadData();
            try
            {
                XmlNode suppliers = supplierDoc.SelectSingleNode("/suppliers");
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + supplier.id + "']");
                supplierNode.SelectSingleNode("supplier_name").InnerText = supplier.name;
                supplierNode.SelectSingleNode("supplier_phone").InnerText = supplier.phone;
                supplierNode.SelectSingleNode("supplier_email").InnerText = supplier.email;
                supplierNode.SelectSingleNode("supplier_status").InnerText = supplier.status.ToString();


                supplierDoc.Save(Config.getXMLPath("suppliers"));
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
            ReloadData();
            try
            {
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                supplierNode.SelectSingleNode("supplier_deleted").InnerText = CustomDateTime.GetNow();
                supplierDoc.Save(Config.getXMLPath("suppliers"));
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
            ReloadData();
            try
            {
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                supplierNode.SelectSingleNode("supplier_deleted").InnerText = "";
                supplierDoc.Save(Config.getXMLPath("suppliers"));
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
            ReloadData();
            try
            {
                XmlNode supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                supplierNode.ParentNode.RemoveChild(supplierNode);
                supplierDoc.Save(Config.getXMLPath("suppliers"));
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




