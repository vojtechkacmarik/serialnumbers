using System;
using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    /// <inheritdoc />
    public class SerialNumberInitialSchemaValueStrategy : ISerialNumberSchemaValueStrategy
    {
        /// <inheritdoc />
        public bool IsSuitable(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));

            return currentSchemaValue == null;
        }

        /// <inheritdoc />
        public int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));

            return schemaDefinition.Seed;
        }
    }
}