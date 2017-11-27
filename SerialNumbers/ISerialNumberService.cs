namespace SerialNumbers
{
    /// <summary>
    /// Provides public API to manage serial numbers.
    /// </summary>
    public interface ISerialNumberService
    {
        /// <summary>
        /// Creates the new schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <returns>The created schema.</returns>
        ISerialNumberSchema CreateSchema(string schema, string customer, string mask, int seed = 0, int increment = 1);

        /// <summary>
        /// Gets the current schema value.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="args">The optional arguments.</param>
        /// <returns>The current schema value.</returns>
        string Current(string schema, string customer, params object[] args);

        /// <summary>
        /// Deletes the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        void DeleteSchema(string schema, string customer);

        /// <summary>
        /// Gets the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <returns>The schema.</returns>
        ISerialNumberSchema GetSchema(string schema, string customer);

        /// <summary>
        /// Gets the next schema value.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="args">The optional arguments.</param>
        /// <returns>The next schema value.</returns>
        string Next(string schema, string customer, params object[] args);

        /// <summary>
        /// Resets the specified schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        void Reset(string schema, string customer);

        /// <summary>
        /// Updates the schema.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <returns>The updated schema.</returns>
        ISerialNumberSchema UpdateSchema(string schema, string customer, string mask, int seed, int increment);
    }
}