namespace QPharma.Util;

public class Config
{
    private static readonly string folderXML = "XML";
    private static readonly string folderMedicineImage = "Shared/Medicine/Images";

    public static XmlDocument getDoc(string fileName)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(getXMLPath(fileName));
        return xmlDoc;
    }

    public static string getXMLPath(string fileName)
    {
        var xmlDirectory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
            folderXML);
        var relativePath = Path.Combine(xmlDirectory, fileName + ".xml");
        return relativePath;
    }

    public static string getCurrentDirectory()
    {
        return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
    }
}