using System.Collections.Generic;

namespace Checklist.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get();
        void Insert(T entity);
    }
}