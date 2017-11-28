namespace SerialNumbers.Business
{
    public interface ISerialNumberSchemaValueValidator
    {
        bool IsValid(string mask, params string[] args);
    }
}