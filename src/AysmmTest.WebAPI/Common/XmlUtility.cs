using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AysmmTest.WebAPI.Common
{
    public static class XmlUtility
    {
        public static T DeserializeObject<T>(string message)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            byte[] byteArray = Encoding.ASCII.GetBytes(message);

            MemoryStream reader = new MemoryStream(byteArray);

            return (T)serializer.Deserialize(reader);
        }

        public static string Serialize<T>(T obj)
        {
            if (obj == null)
            {
                return null;
            }

            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            XmlWriterSettings settings = new XmlWriterSettings();

            settings.Indent = false;
            settings.Encoding = new UnicodeEncoding(false, false);
            settings.OmitXmlDeclaration = true;

            StringBuilder sb = new StringBuilder();

            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                xmlSerializer.Serialize(writer, obj);
            }

            return sb.ToString();
        }
    }
}
