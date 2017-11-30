using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Extensions
{
    /// <summary>
    /// Extensions for <see cref="ServiceProvider"/>
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Builds the database. It does the initial creation (migration).
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void BuildSerialNumbersDatabase(this ServiceProvider serviceProvider)
        {
            var serviceScopeFactory = serviceProvider.GetService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<SerialNumberDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}