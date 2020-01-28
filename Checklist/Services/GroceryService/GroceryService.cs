using Checklist.Models;
using Checklist.Repository;
using System;

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
        public Grocery Create(Grocery grocery)
        {
            grocery.GroceryId = Guid.NewGuid();
            _baseRepository.Create(grocery);
            _unitOfWork.Save();
            return grocery;
        }
    }
}