using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerialNumbers.Entity
{
    /// <summary>
    /// Represents schema value
    /// </summary>
    /// <seealso cref="SerialNumbers.Entity.EntityBase" />
    public class SchemaValue : EntityBase
    {
        /// <summary>
        /// Gets or sets the schema definition.
        /// </summary>
        [ForeignKey(nameof(SchemaDefinitionId))]
        public SchemaDefinition SchemaDefinition { get; set; }

        /// <summary>
        /// Gets or sets the schema definition identifier.
        /// </summary>
        [Required]
        public int SchemaDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; }

        /// <summary>
        /// Gets or sets the subject identifier.
        /// </summary>
        [Required]
        public int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Required]
        public int Value { get; set; }
    }
}