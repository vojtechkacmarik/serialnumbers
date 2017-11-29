using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}