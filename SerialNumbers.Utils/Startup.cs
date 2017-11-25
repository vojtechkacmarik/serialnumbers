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
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        private IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AddLogging(services);
            AddConfiguration(services);
            AddSerialNumbers(services);
            AddSerialNumbersCommands(services);
            services.AddSingleton<ISerialNumbersCommandLineApplication, SerialNumbersCommandLineApplication>();
        }

        private static void AddSerialNumbersCommands(IServiceCollection services)
        {
            services.AddSingleton<ICommand, CreateCommand>();
        }

        private static void AddLogging(IServiceCollection services)
        {
            var loggerFactory = new LoggerFactory()
                .AddConsole(LogLevel.Debug)
                .AddSerilog()
                .AddDebug();

            services.AddSingleton(loggerFactory);
            services.AddLogging();
        }

        private void AddConfiguration(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton(Configuration);
        }

        private void AddSerialNumbers(IServiceCollection services)
        {
            services.AddSerialNumbers(Configuration.GetConnectionString(SerialNumberConstants.SERIAL_NUMBERS_CONNECTION));
            services.AddSerialNumbersLocalDateTimeProvider();
        }
    }
}