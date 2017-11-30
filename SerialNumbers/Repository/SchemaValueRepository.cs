using System;
using System.Linq;
using SerialNumbers.Business;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for SchemaValue
    /// </summary>
    public class SchemaValueRepository : Repository<SchemaValue>, ISchemaValueRepository
    {
        private readonly SerialNumberDbContext _dbContext;
        private readonly ISerialNumberSchemaValueProvider _serialNumberSchemaValueProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaValueRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="serialNumberSchemaValueProvider">The serial number schema value provider.</param>
        /// <exception cref="ArgumentNullException">serialNumberSchemaValueProvider</exception>
        public SchemaValueRepository(SerialNumberDbContext dbContext,
            ISerialNumberSchemaValueProvider serialNumberSchemaValueProvider)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _serialNumberSchemaValueProvider = serialNumberSchemaValueProvider ?? throw new ArgumentNullException(nameof(serialNumberSchemaValueProvider));
        }

        /// <inheritdoc />
        public void DeleteAll(int schemaDefinitionId, int subjectId)
        {
            var entitiesToDelete = _dbContext.Set<SchemaValue>()
                .Where(schemaValue =>
                    schemaValue.SchemaDefinitionId == schemaDefinitionId && schemaValue.SubjectId == subjectId)
                .ToList();
            _dbContext.Set<SchemaValue>().RemoveRange(entitiesToDelete);
        }

        /// <inheritdoc />
        public SchemaValue GetCurrent(int schemaDefinitionId, int subjectId)
        {
            return _dbContext.Set<SchemaValue>()
                .Where(schemaValue => schemaValue.SchemaDefinitionId == schemaDefinitionId
                                      && schemaValue.SubjectId == subjectId)
                .OrderByDescending(schemaValue => schemaValue.Id)
                .FirstOrDefault();
        }

        /// <inheritdoc />
        public SchemaValue Next(SchemaDefinition schemaDefinition, int subjectId)
        {
            if (schemaDefinition == null) throw new ArgumentNullException(nameof(schemaDefinition));

            var currentSchemaValue = GetCurrent(schemaDefinition.Id, subjectId);
            var nextValue = GetNextValue(schemaDefinition, currentSchemaValue);

            var newSchemaValue = new SchemaValue
            {
                SchemaDefinitionId = schemaDefinition.Id,
                SubjectId = subjectId,
                Value = nextValue
            };
            Add(newSchemaValue);
            return newSchemaValue;
        }

        private int GetNextValue(SchemaDefinition schemaDefinition, SchemaValue currentSchemaValue)
        {
            return _serialNumberSchemaValueProvider.GetNextValue(schemaDefinition, currentSchemaValue);
        }
    }
}