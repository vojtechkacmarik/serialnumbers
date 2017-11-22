using System;

namespace SerialNumbers.Core
{
    public class UtcDateTimeProvider : ISerialNumberDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}