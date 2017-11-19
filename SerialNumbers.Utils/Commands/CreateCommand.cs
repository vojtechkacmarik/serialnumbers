using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace SerialNumbers.Utils.Commands
{
    internal class CreateCommand : CommandLineApplication, ICommand
    {
        private readonly ILogger<CreateCommand> _logger;
        private readonly ISerialNumberSchemaProvider _serialNumberSchemaProvider;

        public CreateCommand(ILogger<CreateCommand> logger, ISerialNumberSchemaProvider serialNumberSchemaProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberSchemaProvider = serialNumberSchemaProvider ??
                                          throw new ArgumentNullException(nameof(serialNumberSchemaProvider));

            Name = "create";
            FullName = Description = "Command to create a schema.";

            HelpOption("-? | --help | -h");

            var schemaKey = Argument("", "Schema key");
            var customerKey = Argument("-customer", "Customer key");
            var initValue = Argument("-initValue", "Initial value");
            var seed = Argument("-seed", "Seed");
            var increment = Argument("-increment", "Increment");

            OnExecute(() => Execute(schemaKey, customerKey, initValue, seed, increment));
        }

        public int Execute(CommandArgument schemaKey, CommandArgument customerKey, CommandArgument mask, CommandArgument seed, CommandArgument increment)
        {
            var schema = _serialNumberSchemaProvider.Create(schemaKey.Value, customerKey.Value, mask.Value, int.Parse(seed.Value), int.Parse(increment.Value));
            _logger.LogInformation($"Schema {schema.SchemaId} was created.");
            return 0;
        }
    }
}