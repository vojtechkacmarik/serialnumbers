using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SerialNumbers.Utils.Commands;

namespace SerialNumbers.Utils
{
    public class SerialNumbersCommandLineApplication : CommandLineApplication, ISerialNumbersCommandLineApplication
    {
        private readonly ILogger<SerialNumbersCommandLineApplication> _logger;
        private readonly IServiceProvider _serviceProvider;

        public SerialNumbersCommandLineApplication(IServiceProvider serviceProvider, ILogger<SerialNumbersCommandLineApplication> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

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

        private void RegisterCommands(IServiceProvider serviceProvider)
        {
            var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = serviceScopeFactory.CreateScope())
            {
                foreach (var command in scope.ServiceProvider.GetServices<ICommand>())
                {
                    if (!(command is CommandLineApplication commandLineApp)) continue;

                    Commands.Add(commandLineApp);
                    _logger.LogInformation($"Command {commandLineApp.Name} was registered.");
                }
            }
        }
    }
}