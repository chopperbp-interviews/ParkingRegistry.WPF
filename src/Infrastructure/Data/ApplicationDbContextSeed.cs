using Microsoft.Extensions.Logging;

namespace ParkingRegistry.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static void Seed(
              ApplicationDbContext context,
              ILoggerFactory loggerFactory)
        {
            context.Database.EnsureCreated();
            // context.SaveChanges();
        }
    }
}
