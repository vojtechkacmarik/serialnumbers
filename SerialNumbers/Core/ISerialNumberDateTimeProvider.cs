using System;

namespace SerialNumbers.Core
{
    public interface ISerialNumberDateTimeProvider
    {
        DateTime Now { get; }
    }
}