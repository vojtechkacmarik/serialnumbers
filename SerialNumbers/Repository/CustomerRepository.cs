using System;
using System.Linq;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for Customer
    /// </summary>
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly SerialNumberDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CustomerRepository(SerialNumberDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public Customer GetOrAdd(string customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            var existingCustomer = _dbContext.Set<Customer>().SingleOrDefault(c => c.Name.Equals(customer, StringComparison.CurrentCultureIgnoreCase));
            if (existingCustomer != null) return existingCustomer;

            var newCustomer = new Customer { Name = customer };
            Add(newCustomer);

            return newCustomer;
        }
    }
}