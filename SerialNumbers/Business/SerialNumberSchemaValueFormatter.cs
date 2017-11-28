using System;

namespace SerialNumbers.Business
{
    public class SerialNumberSchemaValueFormatter : ISerialNumberSchemaValueFormatter
    {
        private readonly ISerialNumberSchemaValueValidator _serialNumberSchemaValueValidator;

        public SerialNumberSchemaValueFormatter(ISerialNumberSchemaValueValidator serialNumberSchemaValueValidator)
        {
            _serialNumberSchemaValueValidator = serialNumberSchemaValueValidator ?? throw new ArgumentNullException(nameof(serialNumberSchemaValueValidator));
        }

        public string Format(string mask, int value, params string[] args)
        {
            var isValid = _serialNumberSchemaValueValidator.IsValid(mask, args);
            if (!isValid) throw new InvalidOperationException("The schema definition mask is incorrect. The number of arguments doesn't fit to expected parameters like '{0}' etc.!");

            return string.Format(mask, value, args);
        }
    }
}