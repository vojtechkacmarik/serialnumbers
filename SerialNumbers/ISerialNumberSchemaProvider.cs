namespace SerialNumbers
{
    public interface ISerialNumberSchemaProvider
    {
        ISerialNumberSchema Create(string schemaId, string customerId, string mask, int seed = 0, int increment = 1);

        void Delete(string schemaId);

        ISerialNumberSchema Get(string schemaId);

        ISerialNumberSchema Update(string schemaId, string mask, int seed, int increment);
    }
}