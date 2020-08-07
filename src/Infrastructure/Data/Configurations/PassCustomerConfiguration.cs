using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRegistry.ApplicationCore.Entities;

namespace ParkingRegistry.Infrastructure.Data.Configurations
{
    class PassCustomerConfiguration : IEntityTypeConfiguration<PassCustomer>
    {
        public void Configure(EntityTypeBuilder<PassCustomer> builder)
        {
            builder.ToTable("PassCustomers");
            builder.HasData(
                new { Id = 1, CustomerId = 1, PaymentTypeId = 1 },
                new { Id = 2, CustomerId = 1, PaymentTypeId = 2 },
                new { Id = 3, CustomerId = 2, PaymentTypeId = 3 }
                );
        }
    }
}
