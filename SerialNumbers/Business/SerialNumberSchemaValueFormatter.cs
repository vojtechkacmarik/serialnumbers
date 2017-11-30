using System;
using System.Collections.Generic;
using System.Linq;

namespace SerialNumbers.Business
{
    /// <inheritdoc />
    public class SerialNumberSchemaValueFormatter : ISerialNumberSchemaValueFormatter
    {
        private readonly ISerialNumberSchemaValueValidator _serialNumberSchemaValueValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialNumberSchemaValueFormatter"/> class.
        /// </summary>
        /// <param name="serialNumberSchemaValueValidator">The serial number schema value validator.</param>
        /// <exception cref="ArgumentNullException">serialNumberSchemaValueValidator</exception>
        public SerialNumberSchemaValueFormatter(ISerialNumberSchemaValueValidator serialNumberSchemaValueValidator)
        {
            _serialNumberSchemaValueValidator = serialNumberSchemaValueValidator ?? throw new ArgumentNullException(nameof(serialNumberSchemaValueValidator));
        }

        /// <inheritdoc />
        public string Format(string mask, int value, params string[] args)
        {
            Validate(mask, args);

            var parameters = BuildParameters(value, args);
            return Format(mask, parameters);
        }

        private static object[] BuildParameters(int value, IEnumerable<string> args)
        {
            return args != null ? new object[] { value }.Concat(args).ToArray() : new object[] { value }.ToArray();
        }

        private static string Format(string mask, params object[] parameters)
        {
            return string.Format(mask, parameters);
        }

        private void Validate(string mask, string[] args)
        {
            _serialNumberSchemaValueValidator.Validate(mask, args);
        }
    }
}