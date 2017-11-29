namespace SerialNumbers
{
    public class SerialNumberSchema : ISerialNumberSchema
    {
        internal SerialNumberSchema(string schema, string customer, ISerialNumberSchemaDefinition schemaDefinition)
        {
            Schema = schema;
            Customer = customer;
            SchemaDefinition = schemaDefinition;
        }

        public string Customer { get; }
        public string Schema { get; }
        public ISerialNumberSchemaDefinition SchemaDefinition { get; }
    }
}