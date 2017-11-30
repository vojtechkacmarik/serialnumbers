using System;

namespace SerialNumbers
{
    /// <inheritdoc />
    public class SerialNumberSchemaDefinitionFactory : ISerialNumberSchemaDefinitionFactory
    {
        /// <inheritdoc />
        public ISerialNumberSchemaDefinition Create(string mask, int seed, int increment, DateTime createdAt)
        {
            return new SerialNumberSchemaDefinition(mask, seed, increment, createdAt);
        }
    }
}