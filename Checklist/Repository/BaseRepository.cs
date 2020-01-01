﻿using Checklist.Entity;
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

        //public T GetById(Guid id)
        //{
        //    _dbset.AsNoTracking().FirstOrDefaultAsync(x => x.id)
        //}

        public void Inserts(List<T> entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbset.AddRange(entity);
        }

        public T Get()
        {
            throw new NotImplementedException();
        }
    }
}