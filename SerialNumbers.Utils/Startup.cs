using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private const string JSON_CONFIG_FILE_PATH = "appsettings.json";

        public Startup()
        {
            var baseDirectoryPath = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(baseDirectoryPath)
                .AddJsonFile(JSON_CONFIG_FILE_PATH);

            Configuration = builder.Build();
        }

        private IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AddConfiguration(services, Configuration);
            AddLogging(services);
            AddSerialNumbers(services, Configuration.GetConnectionString(SerialNumberConstants.SERIAL_NUMBERS_CONNECTION));
            AddSerialNumbersCommands(services);
            AddSerialNumbersCommandLineApplication(services);
        }

        private static void AddConfiguration(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(configuration);
        }

        private static void AddLogging(IServiceCollection services)
        {
            var loggerFactory = new LoggerFactory()
                .AddConsole(LogLevel.Debug)
                .AddSerilog();

            services.AddSingleton(loggerFactory);
            services.AddLogging();
        }

        private static void AddSerialNumberCommand(IServiceCollection services, Type commandInterfaceType, Type commandType)
        {
            services.AddSingleton(commandInterfaceType, commandType);
        }

        private static void AddSerialNumbers(IServiceCollection services, string connectionString)
        {
            services.AddSerialNumbers(connectionString);
            services.AddSerialNumbersLocalDateTimeProvider();
        }

        private static void AddSerialNumbersCommandLineApplication(IServiceCollection services)
        {
            services.AddSingleton<ISerialNumbersCommandLineApplication, SerialNumbersCommandLineApplication>();
        }

        private static void AddSerialNumbersCommands(IServiceCollection services)
        {
            var commandInterfaceType = typeof(ICommand);
            var assemblyIncludingCommands = commandInterfaceType.GetTypeInfo().Assembly;
            var commands = assemblyIncludingCommands.GetTypes()
                .Where(type => type.GetTypeInfo().IsClass && !type.GetTypeInfo().IsAbstract && commandInterfaceType.IsAssignableFrom(type))
                .ToArray();
            commands.ForEach(commandType => AddSerialNumberCommand(services, commandInterfaceType, commandType));
        }
    }
}