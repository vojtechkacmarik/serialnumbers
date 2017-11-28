using System;
using Microsoft.Extensions.Logging;

namespace SerialNumbers.Business
{
    /// <inheritdoc />
    internal class SerialNumberService : ISerialNumberService
    {
        private readonly ILogger<ISerialNumberService> _logger;
        private readonly ISerialNumberProvider _serialNumberProvider;
        private readonly ISerialNumberSchemaProvider _serialNumberSchemaProvider;

        public SerialNumberService(ISerialNumberSchemaProvider serialNumberSchemaProvider,
            ISerialNumberProvider serialNumberProvider,
            ILogger<ISerialNumberService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serialNumberProvider = serialNumberProvider ?? throw new ArgumentNullException(nameof(serialNumberProvider));
            _serialNumberSchemaProvider = serialNumberSchemaProvider ?? throw new ArgumentNullException(nameof(serialNumberSchemaProvider));
        }

        /// <inheritdoc />
        public ISerialNumberSchema CreateSchema(string schema, string customer, string mask, int seed = 0, int increment = 1)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (mask == null) throw new ArgumentNullException(nameof(mask));

            var result = _serialNumberSchemaProvider.Create(schema, customer, mask, seed, increment);
            _logger.LogInformation($"The schema ({ToLog(result)}) was created successfully!");
            return result;
        }

        /// <inheritdoc />
        public string Current(string schema, string customer, string subject, params string[] args)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            return _serialNumberProvider.Current(schema, customer, subject, args);
        }

        /// <inheritdoc />
        public void DeleteSchema(string schema, string customer)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            _serialNumberSchemaProvider.Delete(schema, customer);
            _logger.LogInformation($"The schema (Schema={schema}, Customer={customer}) was deleted successfully!");
        }

        /// <inheritdoc />
        public ISerialNumberSchema GetSchema(string schema, string customer)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            return _serialNumberSchemaProvider.Get(schema, customer);
        }

        /// <inheritdoc />
        public string Next(string schema, string customer, string subject, params string[] args)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            return _serialNumberProvider.Next(schema, customer, subject, args);
        }

        /// <inheritdoc />
        public void Reset(string schema, string customer, string subject)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            _serialNumberProvider.Reset(schema, customer, subject);
        }

        /// <inheritdoc />
        public ISerialNumberSchema UpdateSchema(string schema, string customer, string mask, int seed, int increment)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (mask == null) throw new ArgumentNullException(nameof(mask));

            var result = _serialNumberSchemaProvider.Update(schema, customer, mask, seed, increment);
            _logger.LogInformation($"The schema ({ToLog(result)}) was updated successfully!");
            return result;
        }

        private static string ToLog(ISerialNumberSchema schema)
        {
            return
                $"Schema={schema.Schema}, Customer={schema.Customer}, Mask={schema.SchemaDefinition.Mask}, Seed={schema.SchemaDefinition.Seed}, Increment={schema.SchemaDefinition.Increment}";
        }
    }
}