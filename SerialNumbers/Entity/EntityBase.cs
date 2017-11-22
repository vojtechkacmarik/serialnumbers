using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    internal abstract class EntityBase : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}