using System;

namespace SerialNumbers
{
    /// <summary>
    /// Schema definition.
    /// </summary>
    public interface ISerialNumberSchemaDefinition
    {
        /// <summary>
        /// Gets the value when schema definition was created.
        /// </summary>
        DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the increment (positive or negative).
        /// </summary>
        int Increment { get; }

        /// <summary>
        /// Gets the mask (for usage in string.Format function).
        /// </summary>
        string Mask { get; }

        /// <summary>
        /// Gets the seed (initial value).
        /// </summary>
        int Seed { get; }
    }
}