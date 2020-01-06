using System;
using System.Collections.Generic;
using System.Linq;
using Checklist.Models;
using Checklist.Repository;

namespace Checklist.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IBaseRepository<Category> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.Get(null,null);
        }

        public Category GetCategoryById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Category grocery)
        {
            _repository.Insert(grocery);
            _unitOfWork.Save();

        }
    }
}
