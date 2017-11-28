using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using SerialNumbers.Business;

namespace SerialNumbers.Utils.Commands
{
    internal class UpdateSchemaCommand : CommandLineApplication, ICommand
    {
        private readonly ILogger<UpdateSchemaCommand> _logger;
        private readonly ISerialNumberService _serialNumberService;

        public UpdateSchemaCommand(ILogger<UpdateSchemaCommand> logger, ISerialNumberService serialNumberService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberService = serialNumberService ?? throw new ArgumentNullException(nameof(serialNumberService));

            Name = "update-schema";
            FullName = Description = "Command to update the schema by the schema definition.";

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

            _logger.LogInformation($"Schema with following parameters will be updated: Schema={schema.Value}, Customer={customer.Value}, Mask={mask.Value}, Seed={seedAsInt}, Increment={incrementAsInt}");
            var result = _serialNumberService.UpdateSchema(schema.Value, customer.Value, mask.Value, seedAsInt, incrementAsInt);
            _logger.LogInformation($"Schema '{result.Schema}' was updated.");

            return 0;
        }

        private static int ConvertToInt32(string value)
        {
            return Convert.ToInt32(value);
        }
    }
}