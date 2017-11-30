using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    /// <summary>
    /// Strategy to get next schema value
    /// </summary>
    public interface ISerialNumberSchemaValueStrategy
    {
        /// <summary>
        /// Determines whether the strategy is suitable.
        /// </summary>
        /// <param name="schemaDefinition">The schema definition.</param>
        /// <param name="currentSchemaValue">The current schema value.</param>
        /// <returns>
        ///   <c>true</c> if the strategy is suitable; otherwise, <c>false</c>.
        /// </returns>
        bool IsSuitable(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue);

        /// <summary>
        /// Gets the next value.
        /// </summary>
        /// <param name="schemaDefinition">The schema definition.</param>
        /// <param name="currentSchemaValue">The current schema value.</param>
        /// <returns>The next schema value.</returns>
        int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue);
    }
}