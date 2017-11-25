using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SerialNumbers.Extensions;
using SerialNumbers.Utils.Commands;

namespace SerialNumbers.Utils
{
    public class SerialNumbersCommandLineApplication : CommandLineApplication, ISerialNumbersCommandLineApplication
    {
        private readonly ILogger<SerialNumbersCommandLineApplication> _logger;

        public SerialNumbersCommandLineApplication(IServiceProvider serviceProvider, ILogger<SerialNumbersCommandLineApplication> logger)
        {
            if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            Name = "SerialNumbers.Utils";
            FullName = "Serial Numbers - Command Line Tool";
            Description = "Serial Numbers - the C# serial numbers provider";
            RegisterCommands(serviceProvider);

            HelpOption("-? | --help | -h");
            VersionOption("--version | -v", "v1.0");

            OnExecute((Func<int>)Execute);
        }

        public int Execute()
        {
            ShowHelp();
            return 0;
        }

        private static IServiceScopeFactory GetServiceScopeFactory(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        private static IEnumerable<CommandLineApplication> GetSuitableCommands(IServiceScope serviceScope)
        {
            return serviceScope.ServiceProvider.GetServices<ICommand>()
                .OfType<CommandLineApplication>()
                .ToArray();
        }

        private void AddCommand(CommandLineApplication command)
        {
            Commands.Add(command);
            _logger.LogInformation($"Command '{command.Name}' was registered successfully.");
        }

        private void RegisterCommands(IServiceProvider serviceProvider)
        {
            var serviceScopeFactory = GetServiceScopeFactory(serviceProvider);
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var suitableCommands = GetSuitableCommands(serviceScope);
                suitableCommands.ForEach(AddCommand);
            }
        }
    }
}