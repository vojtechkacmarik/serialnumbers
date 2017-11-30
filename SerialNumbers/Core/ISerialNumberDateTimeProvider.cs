using System;

namespace SerialNumbers.Core
{
    /// <summary>
    /// Provider of some datetime values.
    /// </summary>
    public interface ISerialNumberDateTimeProvider
    {
        /// <summary>
        /// Gets the now.
        /// </summary>
        DateTime Now { get; }
    }
}