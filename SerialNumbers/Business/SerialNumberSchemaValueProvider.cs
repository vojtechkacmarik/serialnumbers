using System;
using System.Collections.Generic;
using System.Linq;
using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    /// <inheritdoc />
    public class SerialNumberSchemaValueProvider : ISerialNumberSchemaValueProvider
    {
        private readonly IEnumerable<ISerialNumberSchemaValueStrategy> _serialNumberSchemaValueStrategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialNumberSchemaValueProvider"/> class.
        /// </summary>
        /// <param name="serialNumberSchemaValueStrategies">The serial number schema value strategies.</param>
        /// <exception cref="ArgumentNullException">serialNumberSchemaValueStrategies</exception>
        public SerialNumberSchemaValueProvider(IEnumerable<ISerialNumberSchemaValueStrategy> serialNumberSchemaValueStrategies)
        {
            _serialNumberSchemaValueStrategies = serialNumberSchemaValueStrategies ?? throw new ArgumentNullException(nameof(serialNumberSchemaValueStrategies));
        }

        /// <inheritdoc />
        public int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));

            var suitableStrategy = Resolve(schemaDefinition, currentSchemaValue);
            if (suitableStrategy != null) return suitableStrategy.GetNextValue(schemaDefinition, currentSchemaValue);

            throw new InvalidOperationException("Cannot resolve a suitable strategy to obtain next schema value!");
        }

        private ISerialNumberSchemaValueStrategy Resolve(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            return _serialNumberSchemaValueStrategies
                .SingleOrDefault(strategy => strategy.IsSuitable(schemaDefinition, currentSchemaValue));
        }
    }
}