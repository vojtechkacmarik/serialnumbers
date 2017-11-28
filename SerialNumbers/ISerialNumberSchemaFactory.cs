using System;

namespace SerialNumbers
{
    /// <summary>
    /// Factory to create schema
    /// </summary>
    public interface ISerialNumberSchemaFactory
    {
        /// <summary>
        /// Creates the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <param name="createdAt">The created at.</param>
        /// <returns>The schema.</returns>
        ISerialNumberSchema Create(string schema, string customer, string mask, int seed, int increment, DateTime createdAt);
    }
}