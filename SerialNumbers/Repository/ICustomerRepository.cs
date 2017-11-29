using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    public interface ICustomerRepository : IUnitOfWork
    {
        Customer GetOrAdd(string customer);
    }
}