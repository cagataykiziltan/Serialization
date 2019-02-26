using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Serialization
{
    public static class Serializer
    {
        public static string ToJson<T>(T thisObject)
        {
           return JsonConvert.SerializeObject(thisObject, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver(),
                NullValueHandling = NullValueHandling.Include,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore

            });

        }

        public static T FromJson<T>(string jsonString)
        {
            return (T)JsonConvert.DeserializeObject(jsonString, typeof(T), new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver(),
                NullValueHandling = NullValueHandling.Include,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore

            });
        }

        public static string ToXml<T>(T thisObject)
        {

            var serializer = new XmlSerializer(typeof(T));
            XmlDocument xmlDoc = new XmlDocument();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, thisObject);
                memoryStream.Position = 0;
                xmlDoc.Load(memoryStream);

                return xmlDoc.InnerXml;
            }

        }

        public static T FromXml<T>(string xmlString)
        {
            StringReader xmlReader = new StringReader(xmlString);
            XmlSerializer deserializer = new XmlSerializer(typeof(T));

            return (T)deserializer.Deserialize(xmlReader);
        }

        public static byte[] ToBinary(object thisObject)
        {
            using (var stream = new MemoryStream())
           {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, thisObject);

                return stream.ToArray();

            }

        }
     
        public static T FromBinary<T>(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                var formatter = new BinaryFormatter();

                return (T)formatter.Deserialize(stream);

            }
        }

    }

}