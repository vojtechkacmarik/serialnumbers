using System;

namespace SerialNumbers
{
    public class SerialNumberSchemaFactory : ISerialNumberSchemaFactory
    {
        private readonly ISerialNumberSchemaDefinitionFactory _serialNumberSchemaDefinitionFactory;

        public SerialNumberSchemaFactory(ISerialNumberSchemaDefinitionFactory serialNumberSchemaDefinitionFactory)
        {
            _serialNumberSchemaDefinitionFactory = serialNumberSchemaDefinitionFactory ?? throw new ArgumentNullException(nameof(serialNumberSchemaDefinitionFactory));
        }

        public ISerialNumberSchema Create(string schema, string customer, string mask, int seed, int increment, DateTime createdAt)
        {
            var schemaDefinition = _serialNumberSchemaDefinitionFactory.Create(mask, seed, increment, createdAt);
            return new SerialNumberSchema(schema, customer, schemaDefinition);
        }
    }
}