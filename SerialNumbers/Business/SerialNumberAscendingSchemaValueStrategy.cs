using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    internal class SerialNumberAscendingSchemaValueStrategy : ISerialNumberSchemaValueStrategy
    {
        public bool IsSuitable(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            return currentSchemaValue != null && schemaDefinition.Increment > 0;
        }

        public int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            return currentSchemaValue.Value + schemaDefinition.Increment;
        }
    }
}