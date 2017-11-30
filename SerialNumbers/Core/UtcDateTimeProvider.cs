using System;

namespace SerialNumbers.Core
{
    /// <summary>
    /// UTC datetime value provider.
    /// </summary>
    /// <seealso cref="SerialNumbers.Core.ISerialNumberDateTimeProvider" />
    public class UtcDateTimeProvider : ISerialNumberDateTimeProvider
    {
        /// <inheritdoc />
        public DateTime Now => DateTime.UtcNow;
    }
}