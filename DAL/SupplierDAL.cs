using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.DAL
{
    public class SupplierDAL
    {
        private XmlDocument supplierDoc;

        public void ReloadData()
        {
            supplierDoc = Config.getDoc("suppliers");
        }

        public List<SupplierDTO> GetAll()
        {
            ReloadData();

            var list = new List<SupplierDTO>();
            try
            {
                string query = "SELECT * FROM suppliers";
                DataTable dt = DB.ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    var id = dr["supplier_id"].ToString();
                    var name = dr["supplier_name"].ToString();
                    var phone = dr["supplier_phone"].ToString();
                    var email = dr["supplier_email"].ToString();
                    var note = dr["supplier_note"].ToString();
                    var status = bool.Parse(dr["supplier_status"].ToString());

                    var supplier = new SupplierDTO(id, name, phone, email, note, status);
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
            ReloadData();
            SupplierDTO supplier = null;
            try
            {
                string query = "SELECT * FROM suppliers WHERE supplier_id = " + id;
                DataTable dt = DB.ExecuteQuery("SELECT * FROM suppliers WHERE supplier_id = " + id);
                if (dt.Rows.Count != 0)
                {
                    //var name = supplierNode.SelectSingleNode("supplier_name").InnerText;
                    //var phone = supplierNode.SelectSingleNode("supplier_phone").InnerText;
                    //var email = supplierNode.SelectSingleNode("supplier_email").InnerText;
                    //var note = supplierNode.SelectSingleNode("supplier_note").InnerText;
                    //var status = bool.Parse(supplierNode.SelectSingleNode("supplier_status").InnerText);

                    var name = dt.Rows[0]["supplier_name"].ToString();
                    var phone = dt.Rows[0]["supplier_phone"].ToString();
                    var email = dt.Rows[0]["supplier_email"].ToString();
                    var note = dt.Rows[0]["supplier_note"].ToString();
                    var status = bool.Parse(dt.Rows[0]["supplier_status"].ToString());


                    supplier = new SupplierDTO(id, name, phone, email, note, status);
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
            ReloadData();
            try
            {
                //XmlNode supplierNode = supplierDoc.CreateElement("supplier");

                //XmlNode idNode = supplierDoc.CreateElement("supplier_id");
                //idNode.InnerText = supplier.id;
                //supplierNode.AppendChild(idNode);

                //XmlNode nameNode = supplierDoc.CreateElement("supplier_name");
                //nameNode.InnerText = supplier.name;
                //supplierNode.AppendChild(nameNode);


                //XmlNode noteNode = supplierDoc.CreateElement("supplier_note");
                //noteNode.InnerText = supplier.note;
                //supplierNode.AppendChild(noteNode);


                //XmlNode phoneNode = supplierDoc.CreateElement("supplier_phone");
                //phoneNode.InnerText = supplier.phone;
                //supplierNode.AppendChild(phoneNode);

                //XmlNode emailNode = supplierDoc.CreateElement("supplier_email");
                //emailNode.InnerText = supplier.email;
                //supplierNode.AppendChild(emailNode);

                //XmlNode statusNode = supplierDoc.CreateElement("supplier_status");
                //statusNode.InnerText = supplier.status.ToString();
                //supplierNode.AppendChild(statusNode);


                //supplierDoc.SelectSingleNode("/suppliers").AppendChild(supplierNode);
                //supplierDoc.Save(Config.getXMLPath("suppliers"));

                string query = $"INSERT INTO suppliers VALUES ('{supplier.id}', '{supplier.name}', '{supplier.phone}', '{supplier.email}', '{supplier.note}', {supplier.status})";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        public int Update(SupplierDTO supplier)
        {
            ReloadData();
            try
            {
                //var suppliers = supplierDoc.SelectSingleNode("/suppliers");
                //var supplierNode =
                //    supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + supplier.id + "']");
                //supplierNode.SelectSingleNode("supplier_name").InnerText = supplier.name;
                //supplierNode.SelectSingleNode("supplier_phone").InnerText = supplier.phone;
                //supplierNode.SelectSingleNode("supplier_email").InnerText = supplier.email;
                //supplierNode.SelectSingleNode("supplier_status").InnerText = supplier.status.ToString();


                //supplierDoc.Save(Config.getXMLPath("suppliers"));

                string query = $"UPDATE suppliers SET supplier_name = '{supplier.name}', supplier_phone = '{supplier.phone}', supplier_email = '{supplier.email}', supplier_note = '{supplier.note}', supplier_status = {supplier.status} WHERE supplier_id = '{supplier.id}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        public int Delete(string id)
        {
            ReloadData();
            try
            {
                //var supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                //supplierNode.SelectSingleNode("supplier_deleted").InnerText = CustomDateTime.GetNow();
                //supplierDoc.Save(Config.getXMLPath("suppliers"));

                string query = $"UPDATE suppliers SET supplier_deleted = '{CustomDateTime.GetNow()}' WHERE supplier_id = '{id}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        internal int Restore(string id)
        {
            ReloadData();
            try
            {
                //var supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                //supplierNode.SelectSingleNode("supplier_deleted").InnerText = "";
                //supplierDoc.Save(Config.getXMLPath("suppliers"));

                string query = $"UPDATE suppliers SET supplier_deleted = '' WHERE supplier_id = '{id}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }

        internal int ForceDelete(string id)
        {
            ReloadData();
            try
            {
                //var supplierNode = supplierDoc.SelectSingleNode("/suppliers/supplier[supplier_id='" + id + "']");
                //supplierNode.ParentNode.RemoveChild(supplierNode);
                //supplierDoc.Save(Config.getXMLPath("suppliers"));

                string query = $"DELETE FROM suppliers WHERE supplier_id = '{id}'";
                DB.ExecuteNonQuery(query);

                return Predefined.SUCCESS;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(ex.Message);
                return Predefined.ERROR;
            }
        }
    }
}