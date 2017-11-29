using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    public interface ISubjectRepository : IUnitOfWork
    {
        Subject GetOrAdd(string subject);
    }
}