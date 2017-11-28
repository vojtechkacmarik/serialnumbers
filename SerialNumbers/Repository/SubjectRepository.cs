using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    internal class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly SerialNumberDbContext _dbContext;

        public SubjectRepository(SerialNumberDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}