using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRegistry.ApplicationCore.Entities.Types;

namespace ParkingRegistry.Infrastructure.Data.Configurations
{
    class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable("PaymentTypes");
            builder.HasData(
                new { Id = 1, Type = "Daily", Discount = 0 },
                new { Id = 2, Type = "Weekly", Discount = 5 },
                new { Id = 3, Type = "Monthly", Discount = 10 }
                );
        }
    }
}
