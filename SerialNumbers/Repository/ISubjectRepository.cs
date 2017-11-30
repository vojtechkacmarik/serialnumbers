using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for Subject
    /// </summary>
    /// <seealso cref="SerialNumbers.UnitOfWork.IUnitOfWork" />
    public interface ISubjectRepository : IUnitOfWork
    {
        /// <summary>
        /// Gets the existing entity or add new.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <returns>The existing entity or new one.</returns>
        Subject GetOrAdd(string subject);
    }
}