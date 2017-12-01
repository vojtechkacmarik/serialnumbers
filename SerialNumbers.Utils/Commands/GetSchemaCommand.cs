using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using SerialNumbers.Business;

namespace SerialNumbers.Utils.Commands
{
    internal class GetSchemaCommand : CommandLineApplication, ICommand
    {
        private readonly ILogger<GetSchemaCommand> _logger;
        private readonly ISerialNumberService _serialNumberService;

        public GetSchemaCommand(ILogger<GetSchemaCommand> logger, ISerialNumberService serialNumberService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberService = serialNumberService ?? throw new ArgumentNullException(nameof(serialNumberService));

            Name = "get-schema";
            FullName = Description = "Command to get the schema.";

            HelpOption("-? | --help | -h");

            var schema = Argument("schema", "Unique name of the schema");
            var customer = Argument("customer", "Unique name of the customer");

            OnExecute(() => Execute(schema, customer));
        }

        public int Execute(CommandArgument schema, CommandArgument customer)
        {
            _logger.LogInformation($"Schema with following parameters will be returned: Schema={schema.Value}, Customer={customer.Value}");
            var result = _serialNumberService.GetSchema(schema.Value, customer.Value);
            _logger.LogInformation(result != null
                ? $"Schema 'Schema={result.Schema}, Customer={result.Customer}' was returned."
                : "Schema was not found.");
            return 0;
        }
    }
}