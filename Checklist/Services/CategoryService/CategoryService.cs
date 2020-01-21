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

        public IEnumerable<Category> GetAllCategories() => 
            _repository.Get(null,null) ?? throw new ArgumentNullException();
        
        public Category GetCategoryById(Guid id) => 
            _repository.GetById(id) ?? throw new ArgumentNullException();

        public void Create(Category category)
        {
            _repository.Create(category);
            _unitOfWork.Save();
        }

        public void Create(IEnumerable<Category> categories)
        {
            var existingCategories = _repository.Get(null, null)?.ToList();
            
            if(existingCategories != null)
            {
                categories = categories.Where(x => !existingCategories.Select(y => y.CategoryName).Contains(x.CategoryName));
            }
            _repository.Create(categories);
            _unitOfWork.Save();
        }
    }
}
