namespace SerialNumbers
{
    public interface ISerialNumberSchema
    {
        string Customer { get; }

        string Schema { get; }

        ISerialNumberSchemaDefinition SchemaDefinition { get; }
    }
}