using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingRegistry.ApplicationCore.Entities;
using System;
using System.Linq.Expressions;

namespace ParkingRegistry.Infrastructure.Data.Configurations
{
    class ParkingConfiguration : IEntityTypeConfiguration<Parking>
    {
        public void Configure(EntityTypeBuilder<Parking> builder)
        {
            builder.ToTable("Parkings");

            builder.HasData(
                new { Id = 1, CarId = 1, StartDate = DateTimeOffset.Parse("06/08/2020 08:45:00 +1:00"), EndDate = (DateTimeOffset?)null! },
                new { Id = 2, CarId = 1, StartDate = DateTimeOffset.Parse("05/08/2020 08:45:00 +1:00"), EndDate = DateTimeOffset.Parse("05/08/2020 09:45:00 +1:00") },
                new { Id = 3, CarId = 2, StartDate = DateTimeOffset.Parse("01/08/2020 08:00:00 +1:00"), EndDate = DateTimeOffset.Parse("01/08/2020 09:00:00 +1:00") }
                );
        }
    }
}
