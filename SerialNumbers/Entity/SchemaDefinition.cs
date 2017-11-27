using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerialNumbers.Entity
{
    internal class SchemaDefinition : EntityBase
    {
        public SchemaDefinition()
        {
            Values = new List<SchemaValue>();
        }

        public DateTime CreatedAt { get; set; }

        [Required]
        public int Increment { get; set; }

        [Required]
        [StringLength(255)]
        public string Mask { get; set; }

        [ForeignKey(nameof(SchemaId))]
        public Schema Schema { get; set; }

        [Required]
        public int SchemaId { get; set; }

        [Required]
        public int Seed { get; set; }

        public ICollection<SchemaValue> Values { get; set; }
    }
}