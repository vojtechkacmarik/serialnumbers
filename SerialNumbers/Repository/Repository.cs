using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Generic repository for entity
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class Repository<TEntity> : IUnitOfWork, IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly SerialNumberDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public Repository(SerialNumberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public IUnitOfWork UnitOfWork => _dbContext;

        /// <inheritdoc />
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        /// <inheritdoc />
        public void AssertNotExists(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var existingEntity = _dbContext.Set<TEntity>().SingleOrDefault(predicate);
            if (existingEntity != null)
            {
                throw new InvalidOperationException($"An existing entity {nameof(TEntity)} was found.");
            }
        }

        /// <inheritdoc />
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        /// <inheritdoc />
        public void Edit(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <inheritdoc />
        public virtual TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> List()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate)
                .AsEnumerable();
        }

        /// <inheritdoc />
        public int SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }

        /// <inheritdoc />
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}