using Checklist.Entity;
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
        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories()?.ToList();
        }
        [HttpGet]
        public Category GetCategory(Category category)
        {
            return _categoryService.GetCategoryById(category.Id);
        }
        [HttpPost]
        public void SaveCategory(string name)
        {
            var category = new Category { Id = Guid.NewGuid(), Name = name };
            _categoryService.Insert(category);
        }
    }
}