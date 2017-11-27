using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SerialNumbers.Core;
using SerialNumbers.EntityFramework;
using SerialNumbers.Repository;

namespace SerialNumbers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the serial numbers components into services which are managed by DI container.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="connectionString">The connection string (optional).</param>
        public static void AddSerialNumbers(this IServiceCollection services, string connectionString)
        {
            var internalConnectionString = connectionString ?? SerialNumberConstants.SERIAL_NUMBERS_CONNECTION;
            services.AddDbContext<SerialNumberDbContext>(options => options.UseSqlServer(internalConnectionString));

            services.AddScoped<ISerialNumberDbContext, SerialNumberDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISchemaRepository, SchemaRepository>();
            services.AddScoped<ISchemaDefinitionRepository, SchemaDefinitionRepository>();
            services.AddScoped<ISerialNumberService, SerialNumberService>();
            services.AddScoped<ISerialNumberSchemaProvider, SerialNumberSchemaProvider>();
            services.AddScoped<ISerialNumberProvider, SerialNumberProvider>();
            services.AddTransient<ISerialNumberSchema, SerialNumberSchema>();
            services.AddSingleton<ISerialNumberSchemaFactory, SerialNumberSchemaFactory>();
            services.AddTransient<ISerialNumberSchemaDefinition, SerialNumberSchemaDefinition>();
            services.AddSingleton<ISerialNumberSchemaDefinitionFactory, SerialNumberSchemaDefinitionFactory>();
        }

        /// <summary>
        /// Adds the serial numbers UTC date time provider.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddSerialNumbersUtcDateTimeProvider(this IServiceCollection services)
        {
            services.AddSingleton<ISerialNumberDateTimeProvider, UtcDateTimeProvider>();
        }

        /// <summary>
        /// Adds the serial numbers local date time provider.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddSerialNumbersLocalDateTimeProvider(this IServiceCollection services)
        {
            services.AddSingleton<ISerialNumberDateTimeProvider, LocalDateTimeProvider>();
        }
    }
}