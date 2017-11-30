using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Repository for Customer
    /// </summary>
    public interface ICustomerRepository : IUnitOfWork
    {
        /// <summary>
        /// Gets the existing entity or add new.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>The existing entity or new one.</returns>
        Customer GetOrAdd(string customer);
    }
}