using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    /// <summary>
    /// Represents customer
    /// </summary>
    public class Customer : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            Schemas = new List<Schema>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the schemas.
        /// </summary>
        public ICollection<Schema> Schemas { get; set; }
    }
}