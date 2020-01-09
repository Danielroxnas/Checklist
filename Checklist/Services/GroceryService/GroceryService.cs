using Checklist.DTO;
using Checklist.Models;
using Checklist.Repository;
using Checklist.Services;

namespace Checklist.Services
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


        public void Create(Grocery grocery)
        {
            _baseRepository.Create(grocery);
            _unitOfWork.Save();
        }
    }
}