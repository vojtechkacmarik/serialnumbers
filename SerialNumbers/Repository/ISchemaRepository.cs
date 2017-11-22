using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    internal interface ISchemaRepository : IUnitOfWork
    {
        Schema AddOrThrowIfExists(string schema, Customer customer);
    }
}