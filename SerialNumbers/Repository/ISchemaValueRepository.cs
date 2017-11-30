using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for SchemaValue
    /// </summary>
    public interface ISchemaValueRepository : IUnitOfWork
    {
        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <param name="schemaDefinitionId">The schema definition identifier.</param>
        /// <param name="subjectId">The subject identifier.</param>
        void DeleteAll(int schemaDefinitionId, int subjectId);

        /// <summary>
        /// Gets the current schema value.
        /// </summary>
        /// <param name="schemaDefinitionId">The schema definition identifier.</param>
        /// <param name="subjectId">The subject identifier.</param>
        /// <returns>The current schema value</returns>
        SchemaValue GetCurrent(int schemaDefinitionId, int subjectId);

        /// <summary>
        /// Gets the next schema value by the specified schema definition and subject.
        /// </summary>
        /// <param name="schemaDefinition">The schema definition.</param>
        /// <param name="subjectId">The subject identifier.</param>
        /// <returns>The next schema value.</returns>
        SchemaValue Next(SchemaDefinition schemaDefinition, int subjectId);
    }
}