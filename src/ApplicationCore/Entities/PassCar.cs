using ParkingRegistry.ApplicationCore.BaseEntities.Entities;
using ParkingRegistry.ApplicationCore.Entities.Types;

namespace ParkingRegistry.ApplicationCore.Entities
{
    public class PassCar : BaseEntity
    {
        public PassCar(PaymentType paymentType) 
        {
            PaymentType = paymentType;
        }
        private PassCar() { }
        public CarCar Car { get; private set; } = default!;
        public PaymentType PaymentType { get; private set; } = default!;
    }
}
