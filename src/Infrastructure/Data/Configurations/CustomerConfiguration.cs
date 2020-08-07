using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRegistry.ApplicationCore.Entities;

namespace ParkingRegistry.Infrastructure.Data.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasData(
                new { Id = 1, Name = "First Customer", Discount = 0 },
                new { Id = 2, Name = "Second Customer", Discount = 2 }
                );
        }
    }
}
