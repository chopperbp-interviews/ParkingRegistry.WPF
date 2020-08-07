using ParkingRegistry.ApplicationCore.BaseEntities.Entities;
using System;

namespace ParkingRegistry.ApplicationCore.Entities
{
    public class Parking : BaseEntity
    {
        public Parking(Car car) : this()
        {
            Car = car;
        }
        private Parking()
        {
            StartDate = DateTimeOffset.Now;
        }
        public DateTimeOffset StartDate { get; private set; }
        public DateTimeOffset? EndDate { get; private set; }
        public Car Car { get; private set; } = default!;

        public void StopParking()
        {
            EndDate = DateTimeOffset.Now;
        }
    }
}
