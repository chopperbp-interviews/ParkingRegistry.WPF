using ParkingRegistry.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace ParkingRegistry.Infrastructure.Servies.Exporters
{
    public class JSONExporter : IExporter
    {
        public string Name => "JSON";

        public string FileExtension => "json";

        public byte[] Export<T>(IEnumerable<T> data)
        {
            var list = data.Cast<object>().ToList();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement)
            };
            return JsonSerializer.SerializeToUtf8Bytes(list, options);
        }
    }
}
