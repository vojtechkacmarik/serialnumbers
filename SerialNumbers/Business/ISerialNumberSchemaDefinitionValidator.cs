namespace SerialNumbers.Business
{
    /// <summary>
    /// Validator for schema definition
    /// </summary>
    public interface ISerialNumberSchemaDefinitionValidator
    {
        /// <summary>
        /// Validates the specified mask and increment.
        /// </summary>
        /// <param name="mask">The mask.</param>
        /// <param name="increment">The increment.</param>
        void Validate(string mask, int increment);
    }
}