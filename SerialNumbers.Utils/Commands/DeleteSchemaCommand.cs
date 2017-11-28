using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using SerialNumbers.Business;

namespace SerialNumbers.Utils.Commands
{
    internal class DeleteSchemaCommand : CommandLineApplication, ICommand
    {
        private readonly ILogger<DeleteSchemaCommand> _logger;
        private readonly ISerialNumberService _serialNumberService;

        public DeleteSchemaCommand(ILogger<DeleteSchemaCommand> logger, ISerialNumberService serialNumberService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberService = serialNumberService ?? throw new ArgumentNullException(nameof(serialNumberService));

            Name = "delete-schema";
            FullName = Description = "Command to delete the schema.";

            HelpOption("-? | --help | -h");

            var schema = Argument("schema", "Unique name of the schema");
            var customer = Argument("customer", "Unique name of the customer");

            OnExecute(() => Execute(schema, customer));
        }

        public int Execute(CommandArgument schema, CommandArgument customer)
        {
            _logger.LogInformation($"Schema with following parameters will be deleted: Schema={schema.Value}, Customer={customer.Value}");
            _serialNumberService.DeleteSchema(schema.Value, customer.Value);
            _logger.LogInformation("Schema was deleted.");

            return 0;
        }
    }
}