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
        static string folderMedicineImage = "Shared/Medicine/Images";
        public static XmlDocument getDoc(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(getXMLPath(fileName));
            return xmlDoc;
        }
        public static string getXMLPath(string fileName)
        {
            string xmlDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, folderXML);
            string relativePath = Path.Combine(xmlDirectory, fileName + ".xml");
            return relativePath;
        }
        public static string getCurrentDirectory()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        }
        public static string getImagePath()
        {
            return Path.Combine(getCurrentDirectory(), folderMedicineImage);

        }
    }
}
