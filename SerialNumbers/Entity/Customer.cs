using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    internal class Customer : EntityBase
    {
        public Customer()
        {
            Schemas = new List<Schema>();
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Schema> Schemas { get; set; }
    }
}