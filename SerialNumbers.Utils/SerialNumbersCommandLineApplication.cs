using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SerialNumbers.Utils.Commands;

namespace SerialNumbers.Utils
{
    public class SerialNumbersCommandLineApplication : CommandLineApplication, ISerialNumbersCommandLineApplication
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SerialNumbersCommandLineApplication> _logger;
        private readonly IServiceProvider _serviceProvider;

        public SerialNumbersCommandLineApplication(IServiceProvider serviceProvider, ILogger<SerialNumbersCommandLineApplication> logger, IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            Name = "SerialNumbers.Utils";
            FullName = "Serial Numbers - Command Line Tool";
            Description = "Serial Numbers - the C# serial numbers provider";
            RegisterCommands();

            HelpOption("-? | --help | -h");
            VersionOption("--version | -v", "v1.0");

            OnExecute((Func<int>)Execute);
        }

        public int Execute()
        {
            ShowHelp();
            return 0;
        }

        private void RegisterCommands()
        {
            foreach (var command in _serviceProvider.GetServices<ICommand>())
            {
                if (!(command is CommandLineApplication commandLineApp)) continue;

                Commands.Add(commandLineApp);
                _logger.LogInformation($"Command {commandLineApp.Name} was registered.");
            }
        }
    }
}