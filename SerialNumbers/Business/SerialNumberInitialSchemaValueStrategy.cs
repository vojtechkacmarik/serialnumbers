using System;
using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    public class SerialNumberInitialSchemaValueStrategy : ISerialNumberSchemaValueStrategy
    {
        public bool IsSuitable(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));

            return currentSchemaValue == null;
        }

        public int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));

            return schemaDefinition.Seed;
        }
    }
}