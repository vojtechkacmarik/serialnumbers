using System;

namespace SerialNumbers
{
    /// <summary>
    /// Factory to create schema definition.
    /// </summary>
    public interface ISerialNumberSchemaDefinitionFactory
    {
        /// <summary>
        /// Creates the schema definition.
        /// </summary>
        /// <param name="mask">The mask.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <param name="createdAt">The created at.</param>
        /// <returns>The schema definition.</returns>
        ISerialNumberSchemaDefinition Create(string mask, int seed, int increment, DateTime createdAt);
    }
}