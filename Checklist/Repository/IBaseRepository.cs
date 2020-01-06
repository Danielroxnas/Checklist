using System;
using System.Collections.Generic;

namespace Checklist.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        //IEnumerable<T> GetAll(int skip = 0, int take = 0);
        IEnumerable<T> Get(int? skip, int? take);
        void Inserts(List<T> entity);
        void Insert(T entity);
        T GetById(Guid id);
        void Delete(T entity);

    }
}