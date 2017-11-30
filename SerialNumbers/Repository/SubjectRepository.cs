using System;
using System.Linq;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for SUbject
    /// </summary>
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly SerialNumberDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public SubjectRepository(SerialNumberDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
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