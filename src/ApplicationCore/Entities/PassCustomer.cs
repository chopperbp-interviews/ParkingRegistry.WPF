using ParkingRegistry.ApplicationCore.BaseEntities.Entities;
using ParkingRegistry.ApplicationCore.Entities.Types;
using System.Collections.Generic;

namespace ParkingRegistry.ApplicationCore.Entities
{
    public class PassCustomer : BaseEntity
    {
        public PassCustomer(Customer customer, PaymentType paymentType) 
        {
            Customer = customer;
            PaymentType = paymentType;
        }
        private PassCustomer() : base()
        { }
        public string Number => Id.ToString().PadLeft(8, '0');
        public Customer Customer { get; private set; } = default!;
        private List<CarCustomer> _cars = new List<CarCustomer>();
        public IReadOnlyCollection<CarCustomer> Cars => _cars.AsReadOnly();
        public PaymentType PaymentType { get; private set; } = default!;

    }
}
