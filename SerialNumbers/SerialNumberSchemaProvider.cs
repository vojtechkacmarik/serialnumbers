using System;
using SerialNumbers.Repository;

namespace SerialNumbers
{
    internal class SerialNumberSchemaProvider : ISerialNumberSchemaProvider
    {
        private readonly ISerialNumberSchemaFactory _serialNumberSchemaFactory;
        private readonly ISchemaDefinitionRepository _schemaDefinitionRepository;
        private readonly ISchemaRepository _schemaRepository;
        private readonly ICustomerRepository _customerRepository;

        public SerialNumberSchemaProvider(ICustomerRepository customerRepository,
            ISchemaRepository schemaRepository,
            ISchemaDefinitionRepository schemaDefinitionRepository,
            ISerialNumberSchemaFactory serialNumberSchemaFactory)
        {
            _serialNumberSchemaFactory = serialNumberSchemaFactory ?? throw new ArgumentNullException(nameof(serialNumberSchemaFactory));
            _schemaDefinitionRepository = schemaDefinitionRepository ?? throw new ArgumentNullException(nameof(schemaDefinitionRepository));
            _schemaRepository = schemaRepository ?? throw new ArgumentNullException(nameof(schemaRepository));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public ISerialNumberSchema Create(string schema, string customer, string mask, int seed = 0, int increment = 1)
        {
            var customerEntity = _customerRepository.GetOrAdd(customer);
            var schemaEntity = _schemaRepository.AddOrThrowIfExists(schema, customerEntity);
            var schemaDefinition = _schemaDefinitionRepository.Add(mask, seed, increment, schemaEntity);
            _schemaDefinitionRepository.SaveChanges();

            return _serialNumberSchemaFactory.Create(schema, customer, mask, seed, increment, schemaDefinition.CreatedAt);
        }

        public void Delete(string schema, string customer)
        {
            throw new NotImplementedException();
        }

        public ISerialNumberSchema Get(string schema, string customer)
        {
            throw new NotImplementedException();
        }

        public ISerialNumberSchema Update(string schema, string customer, string mask, int seed, int increment)
        {
            throw new NotImplementedException();
        }
    }
}