using System;
using System.Text.RegularExpressions;

namespace SerialNumbers.Business
{
    /// <inheritdoc />
    public class SerialNumberSchemaDefinitionValidator : ISerialNumberSchemaDefinitionValidator
    {
        private const string PATTERN = @"\{0(\:[^\{\}]*[\d\W]+)?\}";

        /// <inheritdoc />
        public void Validate(string mask, int increment)
        {
            if (mask == null) throw new ArgumentNullException(nameof(mask));

            Validate(increment);
            Validate(mask);
        }

        private static void Validate(string mask)
        {
            var match = Regex.Match(mask, PATTERN);
            var isValid = match.Success;
            if (!isValid)
                throw new InvalidOperationException(
                    $"Schema definition is not valid. Invalid value '{nameof(mask)}': The {nameof(mask)} has to contain at least one parameter placeholder like '{{0}}'!");
        }

        private static void Validate(int increment)
        {
            var isValid = increment != 0;
            if (!isValid)
                throw new InvalidOperationException(
                    $"Schema definition is not valid. Invalid value '{nameof(increment)}': The {nameof(increment)} has to be different from zero!");
        }
    }
}