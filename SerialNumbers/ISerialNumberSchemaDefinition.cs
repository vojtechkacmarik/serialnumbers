using System;

namespace SerialNumbers
{
    public interface ISerialNumberSchemaDefinition
    {
        DateTime CreatedAt { get; }

        int Increment { get; }

        string Mask { get; }

        int Seed { get; }
    }
}