namespace SerialNumbers
{
    /// <summary>
    /// Schema.
    /// </summary>
    public interface ISerialNumberSchema
    {
        /// <summary>
        /// Gets the customer.
        /// </summary>
        string Customer { get; }

        /// <summary>
        /// Gets the schema.
        /// </summary>
        string Schema { get; }

        /// <summary>
        /// Gets the schema definition.
        /// </summary>
        ISerialNumberSchemaDefinition SchemaDefinition { get; }
    }
}