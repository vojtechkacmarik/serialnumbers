namespace SerialNumbers.Business
{
    public interface ISerialNumberSchemaDefinitionValidator
    {
        void Validate(string mask, int increment);
    }
}