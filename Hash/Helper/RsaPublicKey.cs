using System.Xml.Serialization;

namespace RSAManager.Helpers
{
    [XmlRoot("RSAKeyValue")]
    public class RSAPublicKey
    {
        [XmlElement("Modulus")]
        public string Modulus { get; set; }

        [XmlElement("Exponent")]
        public string Exponent { get; set; }

        public virtual string ToXml()
        {
            return XMLHelper.ToXML(this);
        }
    }
}