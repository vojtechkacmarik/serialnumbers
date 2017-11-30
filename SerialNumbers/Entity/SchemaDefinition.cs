using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerialNumbers.Entity
{
    /// <summary>
    /// Represents schema definition
    /// </summary>
    /// <seealso cref="SerialNumbers.Entity.EntityBase" />
    public class SchemaDefinition : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaDefinition"/> class.
        /// </summary>
        public SchemaDefinition()
        {
            Values = new List<SchemaValue>();
        }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the increment.
        /// </summary>
        [Required]
        public int Increment { get; set; }

        /// <summary>
        /// Gets or sets the mask.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Mask { get; set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        [ForeignKey(nameof(SchemaId))]
        public Schema Schema { get; set; }

        /// <summary>
        /// Gets or sets the schema identifier.
        /// </summary>
        [Required]
        public int SchemaId { get; set; }

        /// <summary>
        /// Gets or sets the seed.
        /// </summary>
        [Required]
        public int Seed { get; set; }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        public ICollection<SchemaValue> Values { get; set; }
    }
}