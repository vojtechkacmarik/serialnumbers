using System;
using SerialNumbers.Repository;

namespace SerialNumbers.Business
{
    internal class SerialNumberProvider : ISerialNumberProvider
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISchemaValueRepository _schemaValueRepository;

        public SerialNumberProvider(ISchemaValueRepository schemaValueRepository, ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository ?? throw new ArgumentNullException(nameof(subjectRepository));
            _schemaValueRepository = schemaValueRepository ?? throw new ArgumentNullException(nameof(schemaValueRepository));
        }

        public string Current(string schema, string customer, params object[] args)
        {
            throw new NotImplementedException();
        }

        public string Next(string schema, string customer, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Reset(string schema, string customer)
        {
            throw new NotImplementedException();
        }
    }
}