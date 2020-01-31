using System;
using System.Collections.Generic;
using Checklist.Models;

namespace Checklist.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category Create(Category category);
        IEnumerable<Category> Create(IEnumerable<Category> categories);
        Category GetCategoryById(Guid id);
    }
}