using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(TEntity entity);

        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);

        void AssertNotExists(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);

        void Edit(TEntity entity);

        TEntity GetById(int id);

        IEnumerable<TEntity> List();

        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate);
    }
}