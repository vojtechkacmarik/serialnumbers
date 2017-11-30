using System;
using System.Linq;
using SerialNumbers.Core;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for SchemaDefinition
    /// </summary>
    public class SchemaDefinitionRepository : Repository<SchemaDefinition>, ISchemaDefinitionRepository
    {
        private readonly ISerialNumberDateTimeProvider _dateTimeProvider;
        private readonly SerialNumberDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaDefinitionRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="dateTimeProvider">The date time provider.</param>
        /// <exception cref="ArgumentNullException">dateTimeProvider</exception>
        public SchemaDefinitionRepository(SerialNumberDbContext dbContext,
            ISerialNumberDateTimeProvider dateTimeProvider)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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