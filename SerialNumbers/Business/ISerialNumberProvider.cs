namespace SerialNumbers.Business
{
    internal interface ISerialNumberProvider
    {
        string Current(string schema, string customer, string subject, params string[] args);

        string Next(string schema, string customer, string subject, params string[] args);

        void Reset(string schema, string customer, string subject);
    }
}