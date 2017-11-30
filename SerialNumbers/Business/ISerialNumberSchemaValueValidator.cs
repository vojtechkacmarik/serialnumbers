namespace SerialNumbers.Business
{
    /// <summary>
    /// Validator for schema value
    /// </summary>
    public interface ISerialNumberSchemaValueValidator
    {
        /// <summary>
        /// Validates the specified mask and args.
        /// </summary>
        /// <param name="mask">The mask.</param>
        /// <param name="args">The arguments.</param>
        void Validate(string mask, params string[] args);
    }
}