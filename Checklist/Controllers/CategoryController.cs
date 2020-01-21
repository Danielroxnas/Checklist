using Checklist.Context;
using Checklist.Models;
using Checklist.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Checklist.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public List<Category> AllCategories()
        {
            return _categoryService.GetAllCategories()?.ToList();
        }
        [HttpGet]
        public Category Category(Category category)
        {
            return _categoryService.GetCategoryById(category.CategoryId);
        }
        [HttpPost]
        public void Category([FromBody]string name)
        {
            var category = new Category { CategoryId = Guid.NewGuid(), CategoryName = name };
            _categoryService.Create(category);
        }
        [HttpPost]
        public void Categories([FromBody]List<string> names)
        {
            var categories = names.Select(x => new Category { CategoryId = Guid.NewGuid(), CategoryName = x }).ToList();
            _categoryService.Create(categories);
        }
    }
}