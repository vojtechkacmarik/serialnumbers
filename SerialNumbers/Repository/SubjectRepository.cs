using System;
using System.Linq;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly SerialNumberDbContext _dbContext;

        public SubjectRepository(SerialNumberDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Subject GetOrAdd(string subject)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));

            var existingSubject = _dbContext.Set<Subject>().SingleOrDefault(c => c.Name.Equals(subject, StringComparison.CurrentCultureIgnoreCase));
            if (existingSubject != null) return existingSubject;

            var newSubject = new Subject { Name = subject };
            Add(newSubject);

            return newSubject;
        }
    }
}