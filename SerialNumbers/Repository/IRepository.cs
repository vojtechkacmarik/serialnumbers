using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SerialNumbers.Entity;
using SerialNumbers.UnitOfWork;

namespace SerialNumbers.Repository
{
    /// <summary>
    /// Interface for some repository component
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Asserts the entity does not exist.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        void AssertNotExists(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Edit(TEntity entity);

        /// <summary>
        /// Gets the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Gets the list of entities.
        /// </summary>
        /// <returns>The list of entities.</returns>
        IEnumerable<TEntity> List();

        /// <summary>
        /// Gets the list of entities by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The list of entities.</returns>
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate);
    }
}