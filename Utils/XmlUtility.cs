using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace iPlay.Utils
{
    public class XmlUtility
    {
        /// <summary>
        /// Serializuoja objektus į xml
        /// </summary>
        /// <typeparam name="T">Objekto tipas</typeparam>
        /// <param name="input">Serializuojamas objektas</param>
        /// <param name="xmlNamespace">xmlns atributas</param>
        /// <returns>XML failas string formatu</returns>
        public static string SerializeToXmlString<T>(T input, bool defaultNamespaces = false, bool xmlDeclaration = false)
        {
            XmlRootAttribute attr = (XmlRootAttribute)Attribute.GetCustomAttribute(input.GetType(), typeof(XmlRootAttribute));

            var xns = new XmlSerializerNamespaces();

            if (!defaultNamespaces)
                if (attr != null)
                    xns.Add(string.Empty, attr.Namespace);
                else
                    xns.Add(string.Empty, string.Empty);


            var serializer = new XmlSerializer(input.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = !xmlDeclaration;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, input, xns);
                return stream.ToString();
            }
        }

        /// <summary>
        /// Gamina objektą iš xml stringo
        /// </summary>
        /// <typeparam name="T">Objekto tipas</typeparam>
        /// <param name="xmlString">xml duomenys</param>
        /// <returns>Nurodytas objektas jeigu xml duomenys atitiko jo struktūrą</returns>
        public static T DeserializeFromXmlString<T>(string xmlString)
        {
            try
            {
                T objectFromXml = (T)Activator.CreateInstance(typeof(T));
                XmlSerializer ser = new XmlSerializer(typeof(T));

                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {
                    objectFromXml = (T)ser.Deserialize(reader);
                }

                return (T)objectFromXml;
            }
            catch (Exception ex)
            {
                throw new Exception("Klaida parsinant XML dokumentą", new Exception(xmlString, ex));
            }
        }

    }
}
