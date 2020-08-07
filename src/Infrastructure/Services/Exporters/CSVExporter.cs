using CsvHelper;
using ParkingRegistry.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ParkingRegistry.Infrastructure.Servies.Exporters
{
    public class CSVExporter : IExporter
    {
        public string Name => "CSV";

        public string FileExtension => "csv";

        public byte[] Export<T>(IEnumerable<T> data)
        {
            using var ms = new MemoryStream();
            using var writer = new StreamWriter(ms, new UTF8Encoding(false));
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(data);
            writer.Flush();
            ms.Position = 0;
            var result = ms.ToArray();
            return result;
        }
    }
}
