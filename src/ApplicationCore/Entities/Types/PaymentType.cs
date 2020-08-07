using ParkingRegistry.ApplicationCore.BaseEntities.Entities;

namespace ParkingRegistry.ApplicationCore.Entities.Types
{
    public class PaymentType : BaseEntity
    {
        public PaymentType(string type, int discount)
        {
            Type = type;
            Discount = discount;
        }
        public string Type { get; private set; }
        public int Discount { get; private set; }
    }
}
