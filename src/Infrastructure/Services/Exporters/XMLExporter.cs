using ParkingRegistry.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ParkingRegistry.Infrastructure.Servies.Exporters
{
    public class XMLExporter : IExporter
    {
        public string Name => "XML";

        public string FileExtension => "xml";

        public byte[] Export<T>(IEnumerable<T> data)
        {
            if (data.Count() == 0)
            {
                return new byte[0];
            }
            var type = data.First()!.GetType();
            var properties = type.GetProperties();
            var list = data.Select(x => new XElement("Item", 
                                        properties.Select(p => new XElement(p.Name,p.GetValue(x)))
                                        ));
            var xml = new XElement("Root", list);

            using var ms = new MemoryStream();
            using var xmlWriter = XmlWriter.Create(ms, new XmlWriterSettings { Encoding = new UTF8Encoding() });
            var xs = new XmlSerializer(typeof(XElement));
            try
            {
                xs.Serialize(ms, xml);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            return ms.ToArray();
        }
    }
}
