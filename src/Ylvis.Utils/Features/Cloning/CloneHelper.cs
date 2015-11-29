using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Ylvis.Utils.Features.Serialization;

namespace Ylvis.Utils.Features.Cloning
{
    public static class CloneHelper
    {
        public static T CloneObject<T>(T item)
        {
            using (var ms = new MemoryStream())
            {
                //instancja BinaryFormattera - informujemy go, ze bedzie uzyty w celu klonowania
                var bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));

                //serializacja
                bf.Serialize(ms, item);

                //przewijamy memoryStream do poczatku
                ms.Seek(0, SeekOrigin.Begin);

                //deserializacja
                return (T)bf.Deserialize(ms);
            }
        }

        public static T CloneObjectXml<T>(T objClone) where T : new()
        {
            string GetString = SerializeHelper.SeralizeObjectToXML<T>(objClone);
            return SerializeHelper.DeserializeXML<T>(GetString);
        }

        public static T CloneObjectJson<T>(T objClone) where T : class
        {
            string json = SerializeHelper.SeralizeObjectToJson(objClone);
            return SerializeHelper.DeSeralizeObjectFromJson<T>(json);
        }


    }
}
