using ParkingRegistry.ApplicationCore.BaseEntities.Entities;

namespace ParkingRegistry.ApplicationCore.Entities
{
    public class CarCustomer : Car
    {
        public CarCustomer(string numberPlate, PassCustomer pass) : base(numberPlate)
        {
            Pass = pass;
        }
        private CarCustomer(string numberPlate) : base(numberPlate)
        { }

        public PassCustomer Pass { get; } = default!;
    }
}
