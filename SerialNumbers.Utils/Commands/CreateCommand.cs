using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace SerialNumbers.Utils.Commands
{
    internal class CreateCommand : CommandLineApplication, ICommand
    {
        private readonly ILogger<CreateCommand> _logger;
        private readonly ISerialNumberService _serialNumberSchemaProvider;

        public CreateCommand(ILogger<CreateCommand> logger, ISerialNumberService serialNumberService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberSchemaProvider = serialNumberService ??
                                          throw new ArgumentNullException(nameof(serialNumberService));

            Name = "create";
            FullName = Description = "Command to create a schema.";

            HelpOption("-? | --help | -h");

            var schema = Argument("schema", "Unique name of the schema");
            var customer = Argument("customer", "Unique name of the customer");
            var mask = Argument("mask", "Mask");
            var seed = Option("-s |--seed <seed>", "Seed.", CommandOptionType.SingleValue);
            var increment = Option("-i |--increment <increment>", "Increment.", CommandOptionType.SingleValue);

            OnExecute(() => Execute(schema, customer, mask, seed, increment));
        }

        public int Execute(CommandArgument schema, CommandArgument customer, CommandArgument mask, CommandOption seed, CommandOption increment)
        {
            var seedAsInt = seed.HasValue() ? ConvertToInt32(seed.Value()) : 0;
            var incrementAsInt = increment.HasValue() ? ConvertToInt32(increment.Value()) : 1;

            _logger.LogInformation($"Schema with following parameters will be created: Schema={schema.Value}, Customer={customer.Value}, Mask={mask.Value}, Seed={seedAsInt}, Increment={incrementAsInt}");
            var result = _serialNumberSchemaProvider.CreateSchema(schema.Value, customer.Value, mask.Value, seedAsInt, incrementAsInt);
            _logger.LogInformation($"Schema '{result.Schema}' was created.");

            return 0;
        }

        private static int ConvertToInt32(string value)
        {
            return Convert.ToInt32(value);
        }
    }
}