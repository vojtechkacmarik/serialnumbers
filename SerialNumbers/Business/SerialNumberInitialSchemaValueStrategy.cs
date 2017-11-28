using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    internal class SerialNumberInitialSchemaValueStrategy : ISerialNumberSchemaValueStrategy
    {
        public bool IsSuitable(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            return currentSchemaValue == null;
        }

        public int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            return schemaDefinition.Seed;
        }
    }
}