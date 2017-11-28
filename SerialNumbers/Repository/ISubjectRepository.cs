using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    internal interface ISubjectRepository : IUnitOfWork
    {
        Subject GetOrAdd(string subject);
    }
}