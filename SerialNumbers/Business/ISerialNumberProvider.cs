namespace SerialNumbers.Business
{
    /// <summary>
    /// Provider of business methods for schema value
    /// </summary>
    public interface ISerialNumberProvider
    {
        /// <summary>
        /// Gets the current schema value.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The current schema value</returns>
        string Current(string schema, string customer, string subject, params string[] args);

        /// <summary>
        /// Gets the next schema value.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The next schema value</returns>
        string Next(string schema, string customer, string subject, params string[] args);

        /// <summary>
        /// Resets the schema values.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="subject">The subject.</param>
        void Reset(string schema, string customer, string subject);
    }
}