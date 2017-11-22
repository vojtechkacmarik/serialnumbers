using System;

namespace SerialNumbers
{
    internal class SerialNumberService : ISerialNumberService
    {
        private readonly ISerialNumberSchemaProvider _serialNumberSchemaProvider;

        public SerialNumberService(ISerialNumberSchemaProvider serialNumberSchemaProvider)
        {
            _serialNumberSchemaProvider = serialNumberSchemaProvider ?? throw new ArgumentNullException(nameof(serialNumberSchemaProvider));
        }

        public ISerialNumberSchema CreateSchema(string schema, string customer, string mask, int seed = 0, int increment = 1)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (mask == null) throw new ArgumentNullException(nameof(mask));

            return _serialNumberSchemaProvider.Create(schema, customer, mask, seed, increment);
        }

        public string Current(string schema, string customer, params object[] args)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSchema(string schema, string customer)
        {
            throw new System.NotImplementedException();
        }

        public ISerialNumberSchema GetSchema(string schema, string customer)
        {
            throw new System.NotImplementedException();
        }

        public string Next(string schema, string customer, params object[] args)
        {
            throw new System.NotImplementedException();
        }

        public void Reset(string schema, string customer)
        {
            throw new System.NotImplementedException();
        }

        public ISerialNumberSchema UpdateSchema(string schema, string customer, string mask, int seed, int increment)
        {
            throw new System.NotImplementedException();
        }
    }
}