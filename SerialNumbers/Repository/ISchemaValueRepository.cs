﻿using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    public interface ISchemaValueRepository : IUnitOfWork
    {
        void DeleteAll(int schemaDefinitionId, int subjectId);

        SchemaValue GetCurrent(int schemaDefinitionId, int subjectId);

        SchemaValue Next(SchemaDefinition schemaDefinition, int subjectId);
    }
}