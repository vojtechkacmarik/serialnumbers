namespace SerialNumbers
{
    internal class SerialNumberSchemaProvider : ISerialNumberSchemaProvider
    {
        public ISerialNumberSchema Create(string schemaId, string customerId, string mask, int seed = 0, int increment = 1)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string schemaId)
        {
            throw new System.NotImplementedException();
        }

        public ISerialNumberSchema Get(string schemaId)
        {
            throw new System.NotImplementedException();
        }

        public ISerialNumberSchema Update(string schemaId, string mask, int seed, int increment)
        {
            throw new System.NotImplementedException();
        }
    }
}