using Checklist.Entity;

namespace Checklist.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChecklistContext _checklistContext;

        public UnitOfWork(ChecklistContext checklistContext)
        {
            _checklistContext = checklistContext;
        }

        public void Save()
        {
            _checklistContext.SaveChanges();
        }
    }
}
