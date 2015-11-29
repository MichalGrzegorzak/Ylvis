using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ylvis.Utils.Features.Serialization
{
    public abstract class SerializeHelper
    {
        public static T DeserializeXML<T>(string xmlData) where T : new()
        {
            if (string.IsNullOrEmpty(xmlData))
                return default(T);

            TextReader tr = new StringReader(xmlData);

            T DocItms = new T();

            XmlSerializer xms = new XmlSerializer(DocItms.GetType());

            DocItms = (T)xms.Deserialize(tr);


            return DocItms == null ? default(T) : DocItms;
        }

        public static string SeralizeObjectToXML<T>(T xmlObject)
        {
            var sbTR = new StringBuilder();
            var xmsTR = new XmlSerializer(xmlObject.GetType());
            var xwsTR = new XmlWriterSettings();
            var xmwTR = XmlWriter.Create(sbTR, xwsTR);

            xmsTR.Serialize(xmwTR, xmlObject);
            return sbTR.ToString();
        }

        public static string SeralizeObjectToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T DeSeralizeObjectFromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

    }
}
