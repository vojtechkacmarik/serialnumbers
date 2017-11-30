using System;

namespace SerialNumbers.Core
{
    /// <summary>
    /// Local datetime value provider
    /// </summary>
    /// <seealso cref="SerialNumbers.Core.ISerialNumberDateTimeProvider" />
    public class LocalDateTimeProvider : ISerialNumberDateTimeProvider
    {
        /// <inheritdoc />
        public DateTime Now => DateTime.Now;
    }
}