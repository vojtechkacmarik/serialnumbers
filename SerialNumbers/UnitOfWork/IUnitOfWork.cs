using System.Threading;
using System.Threading.Tasks;

namespace SerialNumbers.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}