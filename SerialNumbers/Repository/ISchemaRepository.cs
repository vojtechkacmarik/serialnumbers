using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    internal interface ISchemaRepository : IUnitOfWork
    {
        Schema AddOrThrowIfExists(string schema, Customer customer);

        Schema AssertExists(string schema, string customer);

        void Delete(string schema, string customer);

        Schema Get(string schema, string customer);
    }
}