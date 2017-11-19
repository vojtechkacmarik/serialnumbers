using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SerialNumbers.Extensions;
using SerialNumbers.Utils.Commands;
using Serilog;

namespace SerialNumbers.Utils
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new LoggerFactory()
                .AddConsole(LogLevel.Debug)
                .AddSerilog()
                .AddDebug());

            services.AddLogging();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSerialNumbers(Configuration.GetConnectionString(SerialNumberConstants.SERIAL_NUMBERS_CONNECTION));
            services.AddSingleton<ICommand, CreateCommand>();
            services.AddSingleton<ISerialNumbersCommandLineApplication, SerialNumbersCommandLineApplication>();
        }
    }
}