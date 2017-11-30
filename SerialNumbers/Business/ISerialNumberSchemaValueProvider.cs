using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    /// <summary>
    /// Provider of next schema value
    /// </summary>
    public interface ISerialNumberSchemaValueProvider
    {
        /// <summary>
        /// Gets the next value.
        /// </summary>
        /// <param name="schemaDefinition">The schema definition.</param>
        /// <param name="currentSchemaValue">The current schema value.</param>
        /// <returns>The next schema value</returns>
        int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue);
    }
}