using SerialNumbers.UnitOfWork;

namespace SerialNumbers.EntityFramework
{
    internal interface IDbContext : IUnitOfWork
    {
    }
}