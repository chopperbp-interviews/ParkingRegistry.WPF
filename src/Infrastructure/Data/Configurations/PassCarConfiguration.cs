using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRegistry.ApplicationCore.Entities;

namespace ParkingRegistry.Infrastructure.Data.Configurations
{
    class PassCarConfiguration : IEntityTypeConfiguration<PassCar>
    {
        public void Configure(EntityTypeBuilder<PassCar> builder)
        {
            builder.ToTable("PassCars");
            builder.HasData(
                new { Id = 10, PaymentTypeId = 1, },
                new { Id = 11, PaymentTypeId = 2, },
                new { Id = 12, PaymentTypeId = 2, }
            );
        }
    }
}
