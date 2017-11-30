using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SerialNumbers.Entity
{
    /// <summary>
    /// Represents schema
    /// </summary>
    /// <seealso cref="SerialNumbers.Entity.EntityBase" />
    public class Schema : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> class.
        /// </summary>
        public Schema()
        {
            SchemaDefinitions = new List<SchemaDefinition>();
        }

        /// <summary>
        /// Gets the current schema definition.
        /// </summary>
        [NotMapped]
        public SchemaDefinition CurrentSchemaDefinition => SchemaDefinitions
            .OrderByDescending(schemaDefinition => schemaDefinition.Id)
            .First();

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Required]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the schema definitions.
        /// </summary>
        public ICollection<SchemaDefinition> SchemaDefinitions { get; set; }
    }
}