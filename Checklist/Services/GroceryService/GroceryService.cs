using Checklist.Models;
using Checklist.Repository;

namespace Checklist.Controllers
{
    public class GroceryService : IGroceryService
    {
        private readonly IBaseRepository<Grocery> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GroceryService(IBaseRepository<Grocery> baseRepository, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save(Grocery grocery)
        {
            _baseRepository.Insert(grocery);
            _unitOfWork.Save();
        }
    }
}