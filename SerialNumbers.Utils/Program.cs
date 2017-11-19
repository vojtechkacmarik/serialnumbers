using Microsoft.Extensions.DependencyInjection;

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

            var app = serviceProvider.GetService<ISerialNumbersCommandLineApplication>();
            return app.Execute(args);
        }
    }
}