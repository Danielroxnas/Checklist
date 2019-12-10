namespace Checklist.Repository
{
    public interface IRepository<T> where T : class
    {

        void Insert(T entity);
    }
}