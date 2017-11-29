using SerialNumbers.UnitOfWork;

namespace SerialNumbers.EntityFramework
{
    public interface IDbContext : IUnitOfWork
    {
    }
}