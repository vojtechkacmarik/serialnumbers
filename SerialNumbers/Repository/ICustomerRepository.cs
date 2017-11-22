using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    internal interface ICustomerRepository : IUnitOfWork
    {
        Customer GetOrAdd(string customer);
    }
}