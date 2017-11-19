using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    internal class Customer : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Key { get; set; }

        public List<Schema> Schemas { get; set; }
    }
}