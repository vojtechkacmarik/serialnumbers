using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SerialNumbers.Persistence
{
    internal class SerialNumberDesignTimeDbContextFactory : IDesignTimeDbContextFactory<SerialNumberDbContext>
    {
        public SerialNumberDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SerialNumberDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString(SerialNumberConstants.SERIAL_NUMBERS_CONNECTION));

            return new SerialNumberDbContext(builder.Options);
        }
    }
}