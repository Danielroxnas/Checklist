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
            _repository.Get(null, null) ?? throw new ArgumentNullException();

        public Category GetCategoryById(Guid id) =>
            _repository.GetById(id) ?? throw new ArgumentNullException();

        public Category Create(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _repository.Create(category);
            _unitOfWork.Save();
            return category;
        }

        public IEnumerable<Category> Create(IEnumerable<Category> categories)
        {
            var cats = categories?.Where(x => x != null).ToList();
            if(cats == null || cats.Count == 0)
            {
                return null;
            }
            var existingCategories = _repository.Get(null, null)?.ToList();

            if (existingCategories != null)
            {
                categories = cats?.Where(x => !existingCategories.Select(y => y.CategoryName).Contains(x?.CategoryName));

            }
            cats.ToList().ForEach(x => x.CategoryId = Guid.NewGuid());
            _repository.Create(cats);
            _unitOfWork.Save();
            return categories;


        }
    }
}
