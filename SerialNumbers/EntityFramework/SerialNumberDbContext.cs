using Microsoft.EntityFrameworkCore;
using SerialNumbers.Entity;

namespace SerialNumbers.EntityFramework
{
    internal class SerialNumberDbContext : DbContext, ISerialNumberDbContext
    {
        public SerialNumberDbContext(DbContextOptions<SerialNumberDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the schema definitions.
        /// </summary
        public DbSet<SchemaDefinition> SchemaDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the schemas.
        /// </summary>
        public DbSet<Schema> Schemas { get; set; }

        /// <summary>
        /// Gets or sets the schema values.
        /// </summary>
        public DbSet<SchemaValue> SchemaValues { get; set; }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("sn");

            builder.Entity<Customer>()
                .HasIndex(b => b.Name)
                .IsUnique();

            builder.Entity<Subject>()
                .HasIndex(b => b.Name)
                .IsUnique();

            builder.Entity<Schema>()
                .HasIndex(p => new { p.Name, p.CustomerId })
                .IsUnique();
        }
    }
}