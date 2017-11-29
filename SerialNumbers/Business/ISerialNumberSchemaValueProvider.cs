using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    public interface ISerialNumberSchemaValueProvider
    {
        int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue);
    }
}