using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SerialNumbers.Entity
{
    internal class Schema : EntityBase
    {
        public Schema()
        {
            SchemaDefinitions = new List<SchemaDefinition>();
        }

        [NotMapped]
        public SchemaDefinition CurrentSchemaDefinition => SchemaDefinitions
            .OrderByDescending(schemaDefinition => schemaDefinition.Id)
            .First();

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<SchemaDefinition> SchemaDefinitions { get; set; }
    }
}