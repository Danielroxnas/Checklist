using Checklist.Entity;
using Checklist.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        public void Insert(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbset.Add(entity);
        }

        public void Commit()
        {
            _checklistContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset;
        }

        public T GetById(Guid id)
        {
            return _dbset.Find(id);
        }

        public void Inserts(List<T> entities)
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

    }
}
