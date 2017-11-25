using Microsoft.Extensions.DependencyInjection;
using SerialNumbers.Extensions;

namespace SerialNumbers.Utils
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var services = new ServiceCollection();

            var startup = new Startup();
            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.BuildDatabase();

            var app = serviceProvider.GetService<ISerialNumbersCommandLineApplication>();
            return app.Execute(args);
        }
    }
}