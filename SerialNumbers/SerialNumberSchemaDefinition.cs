using System;

namespace SerialNumbers
{
    internal class SerialNumberSchemaDefinition : ISerialNumberSchemaDefinition
    {
        internal SerialNumberSchemaDefinition(string mask, int seed, int increment, DateTime createdAt)
        {
            Mask = mask;
            Seed = seed;
            Increment = increment;
            CreatedAt = createdAt;
        }

        public DateTime CreatedAt { get; }

        public int Increment { get; }

        public string Mask { get; }

        public int Seed { get; }
    }
}