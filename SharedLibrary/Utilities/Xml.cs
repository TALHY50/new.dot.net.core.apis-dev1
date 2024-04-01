using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SharedLibrary.Utilities;

public static class Xml
{
    public static XmlSerializer Serialize<T> (T data)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var writer = new Writer();
        var ns = new XmlSerializerNamespaces();
        ns.Add(string.Empty, string.Empty);
        serializer.Serialize(writer, data, ns);
        return serializer;
    }
    
    
    public static XElement ToXElement<T>(this object obj)
    {
        using (var memoryStream = new MemoryStream())
        {
            using (TextWriter streamWriter = new StreamWriter(memoryStream))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, obj);
                return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
            }
        }
    }

    public static T FromXElement<T>(this XElement xElement)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        return (T)xmlSerializer.Deserialize(xElement.CreateReader());
    }
    
    
    public static T Deserialize<T>(string xml)
    {
        var xmlReaderSettings = new XmlReaderSettings() { CheckCharacters = false };

        XmlReader xmlReader = XmlTextReader.Create(new StringReader(xml), xmlReaderSettings);
        XmlSerializer xs = new XmlSerializer(typeof(T));

        return (T)xs.Deserialize(xmlReader);
    }
    
    public static string SerializeToXml<T>(T obj)
    {
        var serializer = new XmlSerializer(typeof(T));
        var settings = new XmlWriterSettings
        {
            OmitXmlDeclaration = true,
            Indent = true
        };

        using (var stringWriter = new StringWriter())
        {
            using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(xmlWriter, obj);
                return stringWriter.ToString();
            }
        }
    }
    
    
    public static string SerializeToSoapXml<T>(T obj)
    {
        var serializer = new XmlSerializer(typeof(T));
        var settings = new XmlWriterSettings
        {
            OmitXmlDeclaration = false,
            Indent = true
        };

        // Define the SOAP namespaces
        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add("soap", "http://schemas.xmlsoap.org/soap/envelope/");
        namespaces.Add("", "http://tempuri.org/"); // Default namespace

        using (var stringWriter = new StringWriter())
        {
            using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                // Serialize with custom namespaces
                serializer.Serialize(xmlWriter, obj, namespaces);
                return stringWriter.ToString();
            }
        }
    }
    
    
}