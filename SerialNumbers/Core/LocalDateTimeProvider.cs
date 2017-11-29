using System;

namespace SerialNumbers.Core
{
    public class LocalDateTimeProvider : ISerialNumberDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}