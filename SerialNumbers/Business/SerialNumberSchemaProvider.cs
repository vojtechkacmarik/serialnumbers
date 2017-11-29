using System;
using SerialNumbers.Entity;
using SerialNumbers.Repository;

namespace SerialNumbers.Business
{
    public class SerialNumberSchemaProvider : ISerialNumberSchemaProvider
    {
        private readonly ISerialNumberSchemaDefinitionValidator _serialNumberSchemaDefinitionValidator;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISchemaDefinitionRepository _schemaDefinitionRepository;
        private readonly ISchemaRepository _schemaRepository;
        private readonly ISerialNumberSchemaFactory _serialNumberSchemaFactory;

        public SerialNumberSchemaProvider(ICustomerRepository customerRepository,
            ISchemaRepository schemaRepository,
            ISchemaDefinitionRepository schemaDefinitionRepository,
            ISerialNumberSchemaFactory serialNumberSchemaFactory,
            ISerialNumberSchemaDefinitionValidator serialNumberSchemaDefinitionValidator)
        {
            _serialNumberSchemaDefinitionValidator = serialNumberSchemaDefinitionValidator ?? throw new ArgumentNullException(nameof(serialNumberSchemaDefinitionValidator));
            _serialNumberSchemaFactory = serialNumberSchemaFactory ?? throw new ArgumentNullException(nameof(serialNumberSchemaFactory));
            _schemaDefinitionRepository = schemaDefinitionRepository ?? throw new ArgumentNullException(nameof(schemaDefinitionRepository));
            _schemaRepository = schemaRepository ?? throw new ArgumentNullException(nameof(schemaRepository));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public ISerialNumberSchema Create(string schema, string customer, string mask, int seed = 0, int increment = 1)
        {
            Validate(mask, increment);

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
                ? CreateSchema(schemaEntity.Name, schemaEntity.Customer.Name, schemaEntity.CurrentSchemaDefinition)
                : null;
        }

        public ISerialNumberSchema Update(string schema, string customer, string mask, int seed, int increment)
        {
            Validate(mask, increment);

            var schemaEntity = _schemaRepository.AssertExists(schema, customer);
            var schemaDefinitionEntity = _schemaDefinitionRepository.Add(mask, seed, increment, schemaEntity);
            _schemaDefinitionRepository.SaveChanges();

            return CreateSchema(schemaEntity.Name, schemaEntity.Customer.Name, schemaDefinitionEntity);
        }

        private void Validate(string mask, int increment)
        {
            _serialNumberSchemaDefinitionValidator.Validate(mask, increment);
        }

        private ISerialNumberSchema CreateSchema(string schema, string customer, SchemaDefinition schemaDefinition)
        {
            return _serialNumberSchemaFactory.Create(schema,
                customer,
                schemaDefinition.Mask,
                schemaDefinition.Seed,
                schemaDefinition.Increment,
                schemaDefinition.CreatedAt);
        }
    }
}