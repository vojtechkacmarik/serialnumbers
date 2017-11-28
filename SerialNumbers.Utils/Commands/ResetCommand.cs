using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using SerialNumbers.Business;

namespace SerialNumbers.Utils.Commands
{
    internal class ResetCommand : CommandLineApplication, ICommand
    {
        private readonly ILogger<ResetCommand> _logger;
        private readonly ISerialNumberService _serialNumberService;

        public ResetCommand(ILogger<ResetCommand> logger, ISerialNumberService serialNumberService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberService = serialNumberService ?? throw new ArgumentNullException(nameof(serialNumberService));

            Name = "reset";
            FullName = Description = "Command to reset schema values.";

            HelpOption("-? | --help | -h");

            var schema = Argument("schema", "Unique name of the schema");
            var customer = Argument("customer", "Unique name of the customer");
            var subject = Argument("subject", "Unique name of the subject for the serial numbers schema");

            OnExecute(() => Execute(schema, customer, subject));
        }

        public int Execute(CommandArgument schema, CommandArgument customer, CommandArgument subject)
        {
            _logger.LogInformation($"Schema value with the following parameters will be deleted: Schema={schema.Value}, Customer={customer.Value}, Subject={subject.Value}");
            _serialNumberService.Reset(schema.Value, customer.Value, subject.Value);
            _logger.LogInformation($"Schema '{schema.Value}' value was deleted.");

            return 0;
        }
    }
}