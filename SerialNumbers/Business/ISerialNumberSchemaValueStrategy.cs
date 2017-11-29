using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    public interface ISerialNumberSchemaValueStrategy
    {
        bool IsSuitable(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue);

        int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue);
    }
}