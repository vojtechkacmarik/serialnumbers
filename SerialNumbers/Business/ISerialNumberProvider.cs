namespace SerialNumbers.Business
{
    internal interface ISerialNumberProvider
    {
        string Current(string schema, string customer, params object[] args);

        string Next(string schema, string customer, params object[] args);

        void Reset(string schema, string customer);
    }
}