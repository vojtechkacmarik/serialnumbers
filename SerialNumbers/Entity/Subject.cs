using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    internal class Subject : EntityBase
    {
        public Subject()
        {
            SchemaValues = new List<SchemaValue>();
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<SchemaValue> SchemaValues { get; set; }
    }
}