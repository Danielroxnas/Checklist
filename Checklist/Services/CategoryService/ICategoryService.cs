using System;
using System.Collections.Generic;
using Checklist.Models;

namespace Checklist.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        void Insert(Category grocery);
        Category GetCategoryById(Guid id);
    }
}