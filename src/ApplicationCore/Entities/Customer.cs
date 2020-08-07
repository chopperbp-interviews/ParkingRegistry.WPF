using ParkingRegistry.ApplicationCore.BaseEntities.Entities;
using System.Collections.Generic;

namespace ParkingRegistry.ApplicationCore.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(string name, int discount)
        {
            Name = name;
            Discount = discount;
        }
        public string Name { get; private set; }
        public int Discount { get; private set; }

        private List<PassCustomer> _passes = new List<PassCustomer>();
        public IReadOnlyCollection<PassCustomer> Passes => _passes.AsReadOnly();
    }
}
