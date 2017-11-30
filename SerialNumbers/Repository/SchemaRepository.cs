using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for Schema
    /// </summary>
    public class SchemaRepository : Repository<Schema>, ISchemaRepository
    {
        private readonly SerialNumberDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public SchemaRepository(SerialNumberDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public Schema AddOrThrowIfExists(string schema, Customer customer)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            AssertNotExists(s =>
                s.Name.Equals(schema, StringComparison.InvariantCultureIgnoreCase) &&
                s.Customer.Name.Equals(customer.Name, StringComparison.InvariantCultureIgnoreCase));

            var newSchema = new Schema
            {
                Name = schema,
                Customer = customer
            };

            Add(newSchema);
            return newSchema;
        }

        /// <inheritdoc />
        public Schema AssertExists(string schema, string customer)
        {
            var existingEntity = Get(schema, customer);
            if (existingEntity != null) return existingEntity;

            throw new InvalidOperationException($"The {nameof(Schema)} (Schema={schema}, Customer={customer}) doesn't exist!");
        }

        /// <inheritdoc />
        public void Delete(string schema, string customer)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            var existingSchema = Get(schema, customer);
            Delete(existingSchema);
        }

        /// <inheritdoc />
        public Schema Get(string schema, string customer)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            return _dbContext.Set<Schema>()
                .Include(s => s.Customer)
                .Include(s => s.SchemaDefinitions)
                .SingleOrDefault(s =>
                    s.Name.Equals(schema, StringComparison.InvariantCultureIgnoreCase) &&
                    s.Customer.Name.Equals(customer, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}