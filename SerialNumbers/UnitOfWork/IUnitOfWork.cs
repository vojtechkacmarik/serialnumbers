using System.Threading;
using System.Threading.Tasks;

namespace SerialNumbers.UnitOfWork
{
    internal interface IUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}