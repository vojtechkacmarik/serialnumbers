using System;

namespace SerialNumbers.Business
{
    internal class SerialNumberSchemaDefinitionValidator : ISerialNumberSchemaDefinitionValidator
    {
        public bool IsValid(string mask, int seed, int increment)
        {
            // TODO vkacmarik: validate mask
            if (increment == 0) throw new InvalidOperationException("Invalid value 'increment': The increment has to be different from zero!");
            return true;
        }
    }
}