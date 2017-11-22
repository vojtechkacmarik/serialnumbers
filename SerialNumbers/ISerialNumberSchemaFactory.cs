using System;

namespace SerialNumbers
{
    internal interface ISerialNumberSchemaFactory
    {
        ISerialNumberSchema Create(string schema, string customer, string mask, int seed, int increment, DateTime createdAt);
    }
}