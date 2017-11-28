using System;
using System.Collections.Generic;
using System.Linq;
using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    internal class SerialNumberSchemaValueProvider : ISerialNumberSchemaValueProvider
    {
        private readonly IEnumerable<ISerialNumberSchemaValueStrategy> _serialNumberSchemaValueStrategies;

        public SerialNumberSchemaValueProvider(IEnumerable<ISerialNumberSchemaValueStrategy> serialNumberSchemaValueStrategies)
        {
            _serialNumberSchemaValueStrategies = serialNumberSchemaValueStrategies ?? throw new ArgumentNullException(nameof(serialNumberSchemaValueStrategies));
        }

        public int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            var suitableStrategy = Resolve(schemaDefinition, currentSchemaValue);
            if (suitableStrategy != null) return suitableStrategy.GetNextValue(schemaDefinition, currentSchemaValue);

            throw new InvalidOperationException("Cannot resolve a suitable strategy to obtain next schema value!");
        }

        private ISerialNumberSchemaValueStrategy Resolve(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            return _serialNumberSchemaValueStrategies
                .FirstOrDefault(strategy => strategy.IsSuitable(schemaDefinition, currentSchemaValue));
        }
    }
}