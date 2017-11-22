using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerialNumbers.Entity
{
    internal class SchemaValue : EntityBase
    {
        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int Value { get; set; }
    }
}