using System;

namespace SerialNumbers
{
    internal class SerialNumberProvider : ISerialNumberProvider
    {
        public string GetLastSerialNumber(string schemaId)
        {
            throw new NotImplementedException();
        }

        public string GetNextSerialNumber(string schemaId, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Reset(string schemaId)
        {
            throw new NotImplementedException();
        }
    }
}