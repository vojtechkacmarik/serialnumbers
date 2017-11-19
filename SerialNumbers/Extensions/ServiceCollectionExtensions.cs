using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SerialNumbers.Persistence;

namespace SerialNumbers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSerialNumbers(this IServiceCollection services, string connectionString)
        {
            var internalConnectionString = connectionString ?? SerialNumberConstants.SERIAL_NUMBERS_CONNECTION;
            services.AddDbContext<SerialNumberDbContext>(options => options.UseSqlServer(internalConnectionString));
            services.AddTransient<ISerialNumberSchemaProvider, SerialNumberSchemaProvider>();
        }
    }
}