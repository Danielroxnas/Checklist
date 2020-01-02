using System.Collections.Generic;
using System.Linq;
using Checklist.Models;
using Checklist.Repository;

namespace Checklist.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _repository;

        public CategoryService(IBaseRepository<Category> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAll();
        }
    }
}
