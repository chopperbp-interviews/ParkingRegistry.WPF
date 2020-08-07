using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRegistry.ApplicationCore.BaseEntities.Entities;
using ParkingRegistry.ApplicationCore.Entities;

namespace ParkingRegistry.Infrastructure.Data.Configurations
{
    class CarCarConfiguration : IEntityTypeConfiguration<CarCar>
    {
        public void Configure(EntityTypeBuilder<CarCar> builder)
        {
            builder.HasOne(p => p.Pass)
                   .WithOne(c => c.Car)
                   .HasForeignKey<CarCar>("PassId")
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new { Id = 8, NumberPlate = "AAA-001", PassId = 10 },
                new { Id = 9, NumberPlate = "AAA-002", PassId = 11 },
                new { Id = 10, NumberPlate = "AAA-003", PassId = 12 }
            );
        }
    }
}
