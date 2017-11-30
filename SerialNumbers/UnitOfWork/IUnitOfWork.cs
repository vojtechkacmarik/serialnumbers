using System.Threading;
using System.Threading.Tasks;

namespace SerialNumbers.UnitOfWork
{
    /// <summary>
    /// Abstraction for business operation
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves the changes.
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}