namespace SerialNumbers.Business
{
    internal interface ISerialNumberSchemaDefinitionValidator
    {
        bool IsValid(string mask, int seed, int increment);
    }
}