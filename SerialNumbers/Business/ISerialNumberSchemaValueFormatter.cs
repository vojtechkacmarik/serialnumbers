namespace SerialNumbers.Business
{
    internal interface ISerialNumberSchemaValueFormatter
    {
        string Format(string mask, int value, params string[] args);
    }
}