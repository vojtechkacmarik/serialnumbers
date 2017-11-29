using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    public interface ISchemaDefinitionRepository : IUnitOfWork
    {
        SchemaDefinition Add(string mask, int seed, int increment, Schema schema);

        SchemaDefinition GetCurrent(int schemaId);
    }
}