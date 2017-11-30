using System;
using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    /// <inheritdoc />
    public class SerialNumberAscendingSchemaValueStrategy : ISerialNumberSchemaValueStrategy
    {
        /// <inheritdoc />
        public bool IsSuitable(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));

            return currentSchemaValue != null && schemaDefinition.Increment > 0;
        }

        /// <inheritdoc />
        public int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));
            if (currentSchemaValue == null) throw new ArgumentNullException(nameof(currentSchemaValue));

            return currentSchemaValue.Value + schemaDefinition.Increment;
        }
    }
}