﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SerialNumbers.Entity
{
    internal class Customer : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public List<Schema> Schemas { get; set; }
    }
}