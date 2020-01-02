using System.Collections.Generic;
using Checklist.Models;

namespace Checklist.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
    }
}