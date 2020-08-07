using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRegistry.ApplicationCore.Entities;

namespace ParkingRegistry.Infrastructure.Data.Configurations
{
    class CarCustomerConfiguration : IEntityTypeConfiguration<CarCustomer>
    {
        public void Configure(EntityTypeBuilder<CarCustomer> builder)
        {
            builder.HasOne(p => p.Pass)
                   .WithMany(c => c.Cars)
                   .HasForeignKey("PassId")
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
           new { Id = 1, NumberPlate = "OOO-001", PassId = 1 },
           new { Id = 2, NumberPlate = "OOO-002", PassId = 1 },
           new { Id = 3, NumberPlate = "OOO-003", PassId = 1 },
           new { Id = 4, NumberPlate = "TTT-001", PassId = 2 },
           new { Id = 5, NumberPlate = "TTT-002", PassId = 2 },
           new { Id = 6, NumberPlate = "XXX-001", PassId = 3 },
           new { Id = 7, NumberPlate = "XXX-002", PassId = 3 }
            );
        }
    }
}
