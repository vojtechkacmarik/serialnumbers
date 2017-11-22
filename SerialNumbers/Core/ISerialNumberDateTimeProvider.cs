using System;

namespace SerialNumbers.Core
{
    internal interface ISerialNumberDateTimeProvider
    {
        DateTime Now { get; }
    }
}