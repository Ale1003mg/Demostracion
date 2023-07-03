using System.Xml;

namespace Demo.Apigate.Common
{
    public class CreateXml
    {
        public void Xml(string xmlPath)
        {
            XmlDocument doc = new();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", null, null);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            XmlElement root = doc.DocumentElement;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement element1 = doc.CreateElement(string.Empty, "doc", string.Empty);
            doc.AppendChild(element1);

            XmlElement element2 = doc.CreateElement(string.Empty, "assembly", string.Empty);
            element1.AppendChild(element2);

            XmlElement element3 = doc.CreateElement(string.Empty, "name", string.Empty);
            XmlText text1 = doc.CreateTextNode("demo.apigate");
            element3.AppendChild(text1);
            element2.AppendChild(element3);

            XmlElement element4 = doc.CreateElement(string.Empty, "members", string.Empty);
            element1.AppendChild(element4);

            XmlElement element5 = doc.CreateElement(string.Empty, "member", string.Empty);
            XmlAttribute atributo = doc.CreateAttribute("name");
            atributo.Value = "T:STORESERVICES.demo.apigate";
            element5.Attributes.Append(atributo);
            element4.AppendChild(element5);

            XmlElement element6 = doc.CreateElement(string.Empty, "summary", string.Empty);
            XmlText text2 = doc.CreateTextNode("Enable Cross-Origin Requests (CORS)");
            element6.AppendChild(text2);
            element5.AppendChild(element6);

            doc.Save(xmlPath);
        }
    }
}
