using System;
using SerialNumbers.Entity;
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
            var schemaDefinitionEntity = _schemaDefinitionRepository.Add(mask, seed, increment, schemaEntity);
            _schemaDefinitionRepository.SaveChanges();

            return _serialNumberSchemaFactory.Create(schemaEntity.Name, customerEntity.Name, mask, seed, increment, schemaDefinitionEntity.CreatedAt);
        }

        public void Delete(string schema, string customer)
        {
            _schemaRepository.Delete(schema, customer);
            _schemaRepository.SaveChanges();
        }

        public ISerialNumberSchema Get(string schema, string customer)
        {
            var schemaEntity = _schemaRepository.Get(schema, customer);
            return schemaEntity != null
                ? _serialNumberSchemaFactory.Create(schemaEntity.Name,
                    schemaEntity.Customer.Name,
                    schemaEntity.CurrentSchemaDefinition.Mask,
                    schemaEntity.CurrentSchemaDefinition.Seed,
                    schemaEntity.CurrentSchemaDefinition.Increment,
                    schemaEntity.CurrentSchemaDefinition.CreatedAt)
                : null;
        }

        public ISerialNumberSchema Update(string schema, string customer, string mask, int seed, int increment)
        {
            var schemaEntity = _schemaRepository.Get(schema, customer);
            if (schemaEntity == null) throw new InvalidOperationException($"Cannot update entity {nameof(Schema)} (Schema='{schema}', Customer='{customer}'). Entity doesn't exist!");

            var schemaDefinitionEntity = _schemaDefinitionRepository.Add(mask, seed, increment, schemaEntity);
            _schemaDefinitionRepository.SaveChanges();

            return _serialNumberSchemaFactory.Create(schemaEntity.Name,
                schemaEntity.Customer.Name,
                schemaDefinitionEntity.Mask,
                schemaDefinitionEntity.Seed,
                schemaDefinitionEntity.Increment,
                schemaDefinitionEntity.CreatedAt);
        }
    }
}