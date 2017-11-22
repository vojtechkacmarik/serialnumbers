using System;

namespace SerialNumbers
{
    internal interface ISerialNumberSchemaDefinitionFactory
    {
        ISerialNumberSchemaDefinition Create(string mask, int seed, int increment, DateTime createdAt);
    }
}