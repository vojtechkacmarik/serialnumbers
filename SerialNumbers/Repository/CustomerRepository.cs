using System;
using System.Linq;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly SerialNumberDbContext _dbContext;

        public CustomerRepository(SerialNumberDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

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