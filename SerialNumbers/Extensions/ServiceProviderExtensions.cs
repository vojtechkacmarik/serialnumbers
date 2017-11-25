using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void BuildDatabase(this ServiceProvider serviceProvider)
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