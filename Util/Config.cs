using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectXML.Util
{
    public class Config
    {
        static string folderXML = "XML";
        public static XmlDocument getDoc(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(getPath(fileName));
            return xmlDoc;
        }
        public static string getPath(string fileName)
        {
            string xmlDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, folderXML);
            string relativePath = Path.Combine(xmlDirectory, fileName + ".xml");
            return relativePath;
        }
    }
}
