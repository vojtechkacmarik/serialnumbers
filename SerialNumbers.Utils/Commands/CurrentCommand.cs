using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using SerialNumbers.Business;

namespace SerialNumbers.Utils.Commands
{
    internal class CurrentCommand : CommandLineApplication, ICommand
    {
        private readonly ILogger<CurrentCommand> _logger;
        private readonly ISerialNumberService _serialNumberService;

        public CurrentCommand(ILogger<CurrentCommand> logger, ISerialNumberService serialNumberService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberService = serialNumberService ?? throw new ArgumentNullException(nameof(serialNumberService));

            Name = "current";
            FullName = Description = "Command to obtain a current schema value.";

            HelpOption("-? | --help | -h");

            var schema = Argument("schema", "Unique name of the schema");
            var customer = Argument("customer", "Unique name of the customer");
            var subject = Argument("subject", "Unique name of the subject for the serial numbers schema");
            var arguments = Option("-a |--arguments <arguments>", "(optional) Arguments.", CommandOptionType.MultipleValue);

            OnExecute(() => Execute(schema, customer, subject, arguments));
        }

        public int Execute(CommandArgument schema, CommandArgument customer, CommandArgument subject, CommandOption arguments)
        {
            var argumentsAsString = string.Join(",", arguments.Values);
            var args = arguments.Values.ToArray();
            _logger.LogInformation($"Current schema value with following parameters will be obtained: Schema={schema.Value}, Customer={customer.Value}, Subject={subject.Value}, Arguments={argumentsAsString}");
            var result = _serialNumberService.Current(schema.Value, customer.Value, subject.Value, args);
            _logger.LogInformation($"Current schema '{schema.Value}' value was obtained: {result}");

            return 0;
        }
    }
}