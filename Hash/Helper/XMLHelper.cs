using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace RSAManager.Helpers
{
    public static class XMLHelper
    {
        public static string ToXML(object instance) 
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(instance.GetType());
            var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
            using (var stream = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, instance, emptyNamepsaces);
                    return stream.ToString();
                }
            }
        }

        public static T FromXML<T>(string xml) where T : class
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xml))
            {
                try
                {
                    return (T)deserializer.Deserialize(reader);
                }
                finally
                {
                    reader.Close();
                }
            }
        }
    }
}