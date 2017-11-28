namespace SerialNumbers.Business
{
    internal interface ISerialNumberSchemaProvider
    {
        ISerialNumberSchema Create(string schema, string customer, string mask, int seed = 0, int increment = 1);

        void Delete(string schema, string customer);

        ISerialNumberSchema Get(string schema, string customer);

        ISerialNumberSchema Update(string schema, string customer, string mask, int seed, int increment);
    }
}