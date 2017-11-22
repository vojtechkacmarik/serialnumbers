using System;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    internal class SchemaRepository : Repository<Schema>, ISchemaRepository
    {
        public SchemaRepository(SerialNumberDbContext dbContext)
            : base(dbContext)
        {
        }

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
    }
}