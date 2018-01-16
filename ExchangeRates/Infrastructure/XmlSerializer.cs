using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ExchangeRates.Infrastructure
{
    public interface IXmlSerializer
    {
        T Deserialize<T>(string xml) where T : class;
    }

    public class XmlSerializerImpl : IXmlSerializer
    {
        public T Deserialize<T>(string xml) where T : class
        {
            if (!string.IsNullOrEmpty(xml))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                using (var stringReader = new StringReader(xml))
                using (var xmlReader = XmlReader.Create(stringReader))
                {
                    return (T) xmlSerializer.Deserialize(xmlReader);
                }
            }

            return null;
        }
    }
}