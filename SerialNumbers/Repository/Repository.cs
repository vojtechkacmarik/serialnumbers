using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SerialNumbers.Entity;
using SerialNumbers.EntityFramework;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    public class Repository<TEntity> : IUnitOfWork, IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly SerialNumberDbContext _dbContext;

        public Repository(SerialNumberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            return await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void AssertNotExists(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            var existingEntity = _dbContext.Set<TEntity>().SingleOrDefault(predicate);
            if (existingEntity != null)
            {
                throw new InvalidOperationException($"An existing entity {nameof(TEntity)} was found.");
            }
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate)
                .AsEnumerable();
        }

        public int SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}