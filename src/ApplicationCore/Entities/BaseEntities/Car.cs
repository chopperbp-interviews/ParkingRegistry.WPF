using ParkingRegistry.ApplicationCore.Entities;
using System.Collections.Generic;

namespace ParkingRegistry.ApplicationCore.BaseEntities.Entities
{
    public abstract class Car : BaseEntity
    {
        public Car(string numberPlate) 
        {
            NumberPlate = numberPlate;
        }
        public string NumberPlate { get; private set; }

        private List<Parking> _parkings = new List<Parking>();
        public IReadOnlyCollection<Parking> Parkings => _parkings.AsReadOnly();

    }
}
