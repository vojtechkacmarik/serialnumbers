using System;
using SerialNumbers.Core;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    internal class SchemaDefinitionRepository : Repository<SchemaDefinition>, ISchemaDefinitionRepository
    {
        private readonly ISerialNumberDateTimeProvider _dateTimeProvider;

        public SchemaDefinitionRepository(SerialNumberDbContext dbContext,
            ISerialNumberDateTimeProvider dateTimeProvider)
            : base(dbContext)
        {
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }

        public SchemaDefinition Add(string mask, int seed, int increment, Schema schema)
        {
            var newSchemaDefinition = new SchemaDefinition
            {
                Mask = mask,
                Seed = seed,
                Increment = increment,
                Schema = schema,
                CreatedAt = Now()
            };

            Add(newSchemaDefinition);
            return newSchemaDefinition;
        }

        private DateTime Now()
        {
            return _dateTimeProvider.Now;
        }
    }
}