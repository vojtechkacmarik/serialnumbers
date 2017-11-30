namespace SerialNumbers.Business
{
    /// <summary>
    /// Formatter for specified mask and arguments.
    /// </summary>
    public interface ISerialNumberSchemaValueFormatter
    {
        /// <summary>
        /// Formats the specified mask.
        /// </summary>
        /// <param name="mask">The mask.</param>
        /// <param name="value">The value.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The formatted value</returns>
        string Format(string mask, int value, params string[] args);
    }
}