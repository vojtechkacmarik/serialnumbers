namespace SerialNumbers
{
    public interface ISerialNumberSchema
    {
        string CustomerId { get; }

        string SchemaId { get; }

        ISerialNumberSchemaDefinition SchemaDefinition { get; }
    }
}