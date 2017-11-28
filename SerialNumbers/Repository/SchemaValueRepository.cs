using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    internal class SchemaValueRepository : Repository<SchemaValue>, ISchemaValueRepository
    {
        private readonly SerialNumberDbContext _dbContext;

        public SchemaValueRepository(SerialNumberDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}