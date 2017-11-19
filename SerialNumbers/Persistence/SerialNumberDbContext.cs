using Microsoft.EntityFrameworkCore;
using SerialNumbers.Entity;

namespace SerialNumbers.Persistence
{
    internal class SerialNumberDbContext : DbContext
    {
        public SerialNumberDbContext(DbContextOptions<SerialNumberDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public DbSet<Customer> Customer { get; set; }

        /// <summary>
        /// Gets or sets the schemas.
        /// </summary>
        public DbSet<Schema> Schemas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("sn");

            builder.Entity<Customer>()
                .HasIndex(b => b.Key)
                .IsUnique();

            builder.Entity<Schema>()
                .HasIndex(b => b.Key)
                .IsUnique();
        }
    }
}