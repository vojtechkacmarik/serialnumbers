using System;

namespace SerialNumbers
{
    /// <inheritdoc />
    public class SerialNumberSchemaFactory : ISerialNumberSchemaFactory
    {
        private readonly ISerialNumberSchemaDefinitionFactory _serialNumberSchemaDefinitionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialNumberSchemaFactory"/> class.
        /// </summary>
        /// <param name="serialNumberSchemaDefinitionFactory">The serial number schema definition factory.</param>
        /// <exception cref="ArgumentNullException">serialNumberSchemaDefinitionFactory</exception>
        public SerialNumberSchemaFactory(ISerialNumberSchemaDefinitionFactory serialNumberSchemaDefinitionFactory)
        {
            _serialNumberSchemaDefinitionFactory = serialNumberSchemaDefinitionFactory ?? throw new ArgumentNullException(nameof(serialNumberSchemaDefinitionFactory));
        }

        /// <inheritdoc />
        public ISerialNumberSchema Create(string schema, string customer, string mask, int seed, int increment, DateTime createdAt)
        {
            var schemaDefinition = _serialNumberSchemaDefinitionFactory.Create(mask, seed, increment, createdAt);
            return new SerialNumberSchema(schema, customer, schemaDefinition);
        }
    }
}