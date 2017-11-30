using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for Schema
    /// </summary>
    public interface ISchemaRepository : IUnitOfWork
    {
        /// <summary>
        /// Adds the new schema or throw exception if exists.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <returns>The schema.</returns>
        Schema AddOrThrowIfExists(string schema, Customer customer);

        /// <summary>
        /// Asserts the entity exists.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="customer">The customer.</param>
        /// <returns>The schema.</returns>
        Schema AssertExists(string schema, string customer);

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
        /// <returns>The schema.</returns>
        Schema Get(string schema, string customer);
    }
}