using System;
using System.Collections.Generic;

namespace Checklist.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> Get(int? skip, int? take);
        IEnumerable<T> Create(IEnumerable<T> entity);
        T Create(T entity);
        T GetById(Guid id);
        void Delete(T entity);

    }
}