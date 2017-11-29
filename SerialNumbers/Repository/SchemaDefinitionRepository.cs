using System;
using System.Linq;
using SerialNumbers.Core;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    public class SchemaDefinitionRepository : Repository<SchemaDefinition>, ISchemaDefinitionRepository
    {
        private readonly ISerialNumberDateTimeProvider _dateTimeProvider;
        private readonly SerialNumberDbContext _dbContext;

        public SchemaDefinitionRepository(SerialNumberDbContext dbContext,
            ISerialNumberDateTimeProvider dateTimeProvider)
            : base(dbContext)
        {
            _dbContext = dbContext;
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

        public SchemaDefinition GetCurrent(int schemaId)
        {
            return _dbContext.Set<SchemaDefinition>()
                .Where(schemaDefinition => schemaDefinition.SchemaId == schemaId)
                .OrderByDescending(schemaDefinition => schemaDefinition.Id)
                .First();
        }

        private DateTime Now()
        {
            return _dateTimeProvider.Now;
        }
    }
}