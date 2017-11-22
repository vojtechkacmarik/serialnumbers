namespace SerialNumbers
{
    public interface ISerialNumberService
    {
        ISerialNumberSchema CreateSchema(string schema, string customer, string mask, int seed = 0, int increment = 1);

        string Current(string schema, string customer, params object[] args);

        void DeleteSchema(string schema, string customer);

        ISerialNumberSchema GetSchema(string schema, string customer);

        string Next(string schema, string customer, params object[] args);

        void Reset(string schema, string customer);

        ISerialNumberSchema UpdateSchema(string schema, string customer, string mask, int seed, int increment);
    }
}