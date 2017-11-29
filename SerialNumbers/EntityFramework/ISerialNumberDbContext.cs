using System;
using Microsoft.EntityFrameworkCore;
using SerialNumbers.Entity;

namespace SerialNumbers.EntityFramework
{
    public interface ISerialNumberDbContext : IDbContext, IDisposable
    {
        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the schema definitions.
        /// </summary>
        DbSet<SchemaDefinition> SchemaDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the schemas.
        /// </summary>
        DbSet<Schema> Schemas { get; set; }

        /// <summary>
        /// Gets or sets the schema values.
        /// </summary>
        DbSet<SchemaValue> SchemaValues { get; set; }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        DbSet<Subject> Subjects { get; set; }
    }
}