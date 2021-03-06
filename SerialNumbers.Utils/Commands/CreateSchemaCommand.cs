﻿using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using SerialNumbers.Business;

namespace SerialNumbers.Utils.Commands
{
    internal class CreateSchemaCommand : CommandLineApplication, ICommand
    {
        private readonly ILogger<CreateSchemaCommand> _logger;
        private readonly ISerialNumberService _serialNumberService;

        public CreateSchemaCommand(ILogger<CreateSchemaCommand> logger, ISerialNumberService serialNumberService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberService = serialNumberService ?? throw new ArgumentNullException(nameof(serialNumberService));

            Name = "create-schema";
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
            var result = _serialNumberService.CreateSchema(schema.Value, customer.Value, mask.Value, seedAsInt, incrementAsInt);
            _logger.LogInformation($"Schema '{result.Schema}' was created.");

            return 0;
        }

        private static int ConvertToInt32(string value)
        {
            return Convert.ToInt32(value);
        }
    }
}