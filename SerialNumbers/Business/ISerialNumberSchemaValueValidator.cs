namespace SerialNumbers.Business
{
    public interface ISerialNumberSchemaValueValidator
    {
        void Validate(string mask, params string[] args);
    }
}