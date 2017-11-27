using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace SerialNumbers.Utils.Commands
{
    internal class DeleteCommand : CommandLineApplication, ICommand
    {
        private readonly ILogger<DeleteCommand> _logger;
        private readonly ISerialNumberService _serialNumberSchemaProvider;

        public DeleteCommand(ILogger<DeleteCommand> logger, ISerialNumberService serialNumberService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberSchemaProvider = serialNumberService ??
                                          throw new ArgumentNullException(nameof(serialNumberService));

            Name = "delete";
            FullName = Description = "Command to delete the schema.";

            HelpOption("-? | --help | -h");

            var schema = Argument("schema", "Unique name of the schema");
            var customer = Argument("customer", "Unique name of the customer");

            OnExecute(() => Execute(schema, customer));
        }

        public int Execute(CommandArgument schema, CommandArgument customer)
        {
            _logger.LogInformation($"Schema with following parameters will be deleted: Schema={schema.Value}, Customer={customer.Value}");
            _serialNumberSchemaProvider.DeleteSchema(schema.Value, customer.Value);
            _logger.LogInformation("Schema was deleted.");

            return 0;
        }
    }
}