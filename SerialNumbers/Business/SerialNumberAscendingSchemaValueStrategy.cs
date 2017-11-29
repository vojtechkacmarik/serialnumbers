using System;
using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    public class SerialNumberAscendingSchemaValueStrategy : ISerialNumberSchemaValueStrategy
    {
        public bool IsSuitable(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));

            return currentSchemaValue != null && schemaDefinition.Increment > 0;
        }

        public int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));
            if (currentSchemaValue == null) throw new ArgumentNullException(nameof(currentSchemaValue));

            return currentSchemaValue.Value + schemaDefinition.Increment;
        }
    }
}