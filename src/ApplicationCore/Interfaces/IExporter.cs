using System.Collections.Generic;

namespace ParkingRegistry.ApplicationCore.Interfaces
{
    public interface IExporter
    {
        string Name { get; }
        string FileExtension { get; }

        byte[] Export<T>(IEnumerable<T> data);
    }
}
