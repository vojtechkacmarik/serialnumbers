namespace SerialNumbers.Business
{
    /// <summary>
    /// Provider of business methods for schema and schema definition
    /// </summary>
    public interface ISerialNumberSchemaProvider
    {
        /// <summary>
        /// Creates the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <returns>The schema</returns>
        ISerialNumberSchema Create(string schema, string customer, string mask, int seed = 0, int increment = 1);

        /// <summary>
        /// Deletes the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        void Delete(string schema, string customer);

        /// <summary>
        /// Gets the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <returns>The schema</returns>
        ISerialNumberSchema Get(string schema, string customer);

        /// <summary>
        /// Updates the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <returns>The schema</returns>
        ISerialNumberSchema Update(string schema, string customer, string mask, int seed, int increment);
    }
}