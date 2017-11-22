using System;

namespace SerialNumbers
{
    internal class SerialNumberProvider : ISerialNumberProvider
    {
        public string Current(string schema, string customer, params object[] args)
        {
            throw new NotImplementedException();
        }

        public string Next(string schema, string customer, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Reset(string schema, string customer)
        {
            throw new NotImplementedException();
        }
    }
}