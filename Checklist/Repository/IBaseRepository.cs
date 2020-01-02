using System;
using System.Collections.Generic;

namespace Checklist.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Inserts(List<T> entity);
        void Insert(T entity);
        void Commit();
        T GetById(Guid id);
    }
}