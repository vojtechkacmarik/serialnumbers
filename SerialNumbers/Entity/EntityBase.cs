using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    /// <summary>
    /// Base entity
    /// </summary>
    public abstract class EntityBase : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}