using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ParkingRegistry.Infrastructure.Data
{
    class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = AppContext.BaseDirectory;
            var basepath = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder()
               .SetBasePath(basePath)
               .AddJsonFile("appsettings.json", false)
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString(nameof(ApplicationDbContext));
                optionsBuilder.UseSqlServer(connectionString, options =>
                options.MigrationsAssembly(typeof(ApplicationDbContextFactory).Assembly.GetName().Name));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
