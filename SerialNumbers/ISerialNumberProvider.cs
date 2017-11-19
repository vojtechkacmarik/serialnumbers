namespace SerialNumbers
{
    public interface ISerialNumberProvider
    {
        string GetLastSerialNumber(string schemaId);

        string GetNextSerialNumber(string schemaId, params object[] args);

        void Reset(string schemaId);
    }
}