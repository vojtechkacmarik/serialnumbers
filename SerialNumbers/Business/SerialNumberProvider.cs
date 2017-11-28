using System;
using SerialNumbers.Entity;
using SerialNumbers.Repository;

namespace SerialNumbers.Business
{
    internal class SerialNumberProvider : ISerialNumberProvider
    {
        private readonly ISchemaRepository _schemaRepository;
        private readonly ISchemaValueRepository _schemaValueRepository;
        private readonly ISerialNumberSchemaValueFormatter _serialNumberSchemaValueFormatter;
        private readonly ISubjectRepository _subjectRepository;

        public SerialNumberProvider(ISchemaValueRepository schemaValueRepository,
            ISubjectRepository subjectRepository,
            ISchemaRepository schemaRepository,
            ISerialNumberSchemaValueFormatter serialNumberSchemaValueFormatter)
        {
            _serialNumberSchemaValueFormatter = serialNumberSchemaValueFormatter ?? throw new ArgumentNullException(nameof(serialNumberSchemaValueFormatter));
            _schemaRepository = schemaRepository ?? throw new ArgumentNullException(nameof(schemaRepository));
            _subjectRepository = subjectRepository ?? throw new ArgumentNullException(nameof(subjectRepository));
            _schemaValueRepository = schemaValueRepository ?? throw new ArgumentNullException(nameof(schemaValueRepository));
        }

        public string Current(string schema, string customer, string subject, params string[] args)
        {
            return GetValue(schema, customer, subject, (schemaEntity, subjectEntity) =>
                {
                    var currentValue =
                        _schemaValueRepository.GetCurrent(schemaEntity.CurrentSchemaDefinition.Id, subjectEntity.Id);
                    if (currentValue != null) return currentValue;

                    var initialValue =
                        _schemaValueRepository.Next(schemaEntity.CurrentSchemaDefinition, subjectEntity.Id);
                    _schemaValueRepository.SaveChanges();
                    return initialValue;
                },
                args
            );
        }

        public string Next(string schema, string customer, string subject, params string[] args)
        {
            return GetValue(schema, customer, subject, (schemaEntity, subjectEntity) =>
                {
                    var nextValue = _schemaValueRepository.Next(schemaEntity.CurrentSchemaDefinition, subjectEntity.Id);
                    _schemaValueRepository.SaveChanges();
                    return nextValue;
                },
                args
            );
        }

        public void Reset(string schema, string customer, string subject)
        {
            var schemaEntity = _schemaRepository.AssertExists(schema, customer);
            var subjectEntity = _subjectRepository.GetOrAdd(subject);
            _schemaValueRepository.DeleteAll(schemaEntity.CurrentSchemaDefinition.Id, subjectEntity.Id);
            _schemaValueRepository.SaveChanges();
        }

        private string GetFormattedValue(SchemaDefinition schemaDefinition, int value, params string[] args)
        {
            return _serialNumberSchemaValueFormatter.Format(schemaDefinition.Mask, value, args);
        }

        private string GetValue(string schema, string customer, string subject, Func<Schema, Subject, SchemaValue> getValueFunc, params string[] args)
        {
            var schemaEntity = _schemaRepository.AssertExists(schema, customer);
            var subjectEntity = _subjectRepository.GetOrAdd(subject);

            var schemaValueEntity = getValueFunc.Invoke(schemaEntity, subjectEntity);

            return GetFormattedValue(schemaEntity.CurrentSchemaDefinition, schemaValueEntity.Value, args);
        }
    }
}