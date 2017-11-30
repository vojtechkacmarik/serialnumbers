namespace SerialNumbers
{
    /// <inheritdoc />
    public class SerialNumberSchema : ISerialNumberSchema
    {
        internal SerialNumberSchema(string schema, string customer, ISerialNumberSchemaDefinition schemaDefinition)
        {
            Schema = schema;
            Customer = customer;
            SchemaDefinition = schemaDefinition;
        }

        /// <inheritdoc />
        public string Customer { get; }

        /// <inheritdoc />
        public string Schema { get; }

        /// <inheritdoc />
        public ISerialNumberSchemaDefinition SchemaDefinition { get; }
    }
}