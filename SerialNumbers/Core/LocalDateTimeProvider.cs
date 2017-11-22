using System;

namespace SerialNumbers.Core
{
    internal class LocalDateTimeProvider : ISerialNumberDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}