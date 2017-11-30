using SerialNumbers.UnitOfWork;

namespace SerialNumbers.EntityFramework
{
    /// <summary>
    /// Abstraction for EF DbContext
    /// </summary>
    /// <seealso cref="SerialNumbers.UnitOfWork.IUnitOfWork" />
    public interface IDbContext : IUnitOfWork
    {
    }
}