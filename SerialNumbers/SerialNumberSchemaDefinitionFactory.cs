using System;

namespace SerialNumbers
{
    public class SerialNumberSchemaDefinitionFactory : ISerialNumberSchemaDefinitionFactory
    {
        public ISerialNumberSchemaDefinition Create(string mask, int seed, int increment, DateTime createdAt)
        {
            return new SerialNumberSchemaDefinition(mask, seed, increment, createdAt);
        }
    }
}