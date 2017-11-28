using SerialNumbers.Entity;

namespace SerialNumbers.Business
{
    internal interface ISerialNumberSchemaValueProvider
    {
        int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue);
    }
}