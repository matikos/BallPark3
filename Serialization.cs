using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BallPark3
{
    public class Serialization
    {
        #region XML serialization
        public static T DeserializeStandardXml<T>(string xmlValue)
        {
            return DeserializeStandardXml<T>(xmlValue, new Type[] { });
        }

        public static T DeserializeStandardXml<T>(string xmlValue, Encoding enc)
        {
            using (StreamReader reader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(xmlValue ?? "")), enc, true)) {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }

        public static T DeserializeStandardXml<T>(string xmlValue, Type[] ExtraTypes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), ExtraTypes);
            using (System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(new StringReader(xmlValue)))
            {
                return ((T)serializer.Deserialize(reader));
            }
        }

        public static string SerializeStandardObject<T>(T obj)
        {
            return SerializeStandardObject<T>(obj, new XmlSerializerNamespaces());
        }

        public static string SerializeStandardObject<T>(T obj, Encoding enc)
        {
            return SerializeStandardObject<T>(obj, null, enc);
        }

        public static string SerializeStandardObject<T>(T obj, XmlSerializerNamespaces ns)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new Type[] { obj.GetType() });

            using (StringWriter sw = new StringWriter())
            {
                using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(sw))
                {
                    serializer.Serialize(writer, obj, (ns ?? new XmlSerializerNamespaces()));
                }
                return sw.ToString();
            }
        }
        
        public static string SerializeStandardObject<T>(T obj, XmlSerializerNamespaces ns, Encoding enc)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new Type[] { obj.GetType() });

            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings()
                {
                    CloseOutput = false,
                    Encoding = enc
                };

                using (System.Xml.XmlWriter xw = System.Xml.XmlWriter.Create(ms, xmlWriterSettings))
                {
                    serializer.Serialize(xw, obj, (ns ?? new XmlSerializerNamespaces()));
                }
                return enc.GetString(ms.ToArray());
            }
        }
        #endregion

        public static byte[] WriteObject<T>(Object obj)
        {
            if (typeof(T) != obj.GetType())
                throw new Exception("Supplied object is not of type <T>, please check types and re-submit");
            BinaryFormatter binForm = new BinaryFormatter();
            byte[] BlobData;
            using (var ms = new MemoryStream())
            {
                binForm.Serialize(ms, obj);
                BlobData = ms.ToArray();
            }

            return BlobData;
        }

        public static T ReadObject<T>(byte[] BlobData)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(BlobData, 0, BlobData.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                return (T)binForm.Deserialize(memStream);
            }
        }
    }
}