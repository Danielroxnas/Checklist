using System;
using System.Collections.Generic;
using Checklist.Models;

namespace Checklist.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        void Create(Category category);
        void Create(IEnumerable<Category> categories);
        Category GetCategoryById(Guid id);
    }
}