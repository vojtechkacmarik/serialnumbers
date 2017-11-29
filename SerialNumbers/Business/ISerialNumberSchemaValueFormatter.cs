namespace SerialNumbers.Business
{
    public interface ISerialNumberSchemaValueFormatter
    {
        string Format(string mask, int value, params string[] args);
    }
}