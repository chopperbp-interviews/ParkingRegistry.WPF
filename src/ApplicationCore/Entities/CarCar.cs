using ParkingRegistry.ApplicationCore.BaseEntities.Entities;

namespace ParkingRegistry.ApplicationCore.Entities
{
    public class CarCar : Car
    {
        public CarCar(string numberPlate, PassCar pass) : base(numberPlate)
        {
            Pass = pass;
        }
        private CarCar(string numberPlate) : base(numberPlate)
        { }

        public PassCar Pass { get; } = default!;
    }
}
