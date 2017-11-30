using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for SchemaDefinition
    /// </summary>
    public interface ISchemaDefinitionRepository : IUnitOfWork
    {
        /// <summary>
        /// Adds the new schema definition.
        /// </summary>
        /// <param name="mask">The mask.</param>
        /// <param name="seed">The seed.</param>
        /// <param name="increment">The increment.</param>
        /// <param name="schema">The schema.</param>
        /// <returns>The schema definition</returns>
        SchemaDefinition Add(string mask, int seed, int increment, Schema schema);

        /// <summary>
        /// Gets the current schema definition.
        /// </summary>
        /// <param name="schemaId">The schema identifier.</param>
        /// <returns>The current schema definition.</returns>
        SchemaDefinition GetCurrent(int schemaId);
    }
}