﻿using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    internal interface ISchemaDefinitionRepository : IUnitOfWork
    {
        SchemaDefinition Add(string mask, int seed, int increment, Schema schema);
    }
}