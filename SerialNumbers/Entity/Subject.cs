using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    /// <summary>
    /// Represents subject
    /// </summary>
    /// <seealso cref="SerialNumbers.Entity.EntityBase" />
    public class Subject : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Subject"/> class.
        /// </summary>
        public Subject()
        {
            SchemaValues = new List<SchemaValue>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the schema values.
        /// </summary>
        public ICollection<SchemaValue> SchemaValues { get; set; }
    }
}