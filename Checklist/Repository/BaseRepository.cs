using Checklist.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Checklist.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ChecklistContext _checklistContext;
        private readonly DbSet<T> _dbset;

        public BaseRepository(ChecklistContext checklistContext)
        {
            _checklistContext = checklistContext;
            _dbset = _checklistContext.Set<T>();
        }

        public void Create(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbset.Add(entity);
        }

        public IEnumerable<T> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return _dbset.Where(expression);
        }

        public T GetById(Guid id)
        {
            return _dbset.Find(id);
        }

        public void Create(IEnumerable<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            _dbset.AddRange(entities);
        }

        public void Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbset.Attach(entity);
            _checklistContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbset.Remove(entity);
        }

        public IEnumerable<T> Get(int? skip, int? take)
        {
            IQueryable<T> result = _dbset;
            if (skip.HasValue) result = result.Skip(skip.Value);
            if (take.HasValue) result = result.Take(take.Value);
            return result;
        }
    }
}
