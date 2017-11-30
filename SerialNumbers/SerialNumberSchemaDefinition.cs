using System;

namespace SerialNumbers
{
    /// <inheritdoc />
    public class SerialNumberSchemaDefinition : ISerialNumberSchemaDefinition
    {
        internal SerialNumberSchemaDefinition(string mask, int seed, int increment, DateTime createdAt)
        {
            Mask = mask;
            Seed = seed;
            Increment = increment;
            CreatedAt = createdAt;
        }

        /// <inheritdoc />
        public DateTime CreatedAt { get; }

        /// <inheritdoc />
        public int Increment { get; }

        /// <inheritdoc />
        public string Mask { get; }

        /// <inheritdoc />
        public int Seed { get; }
    }
}