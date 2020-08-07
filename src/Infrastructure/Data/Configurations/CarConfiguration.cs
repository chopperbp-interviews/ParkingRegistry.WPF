using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRegistry.ApplicationCore.BaseEntities.Entities;
using ParkingRegistry.ApplicationCore.Entities;

namespace ParkingRegistry.Infrastructure.Data.Configurations
{
    class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
        }
    }
}
