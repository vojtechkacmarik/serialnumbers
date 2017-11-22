using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    internal class Subject : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public List<SchemaValue> SchemaValues { get; set; }
    }
}