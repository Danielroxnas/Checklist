using System;
using Checklist.DTO;
using Checklist.Models;
using Checklist.Services;
using Microsoft.AspNetCore.Mvc;

namespace Checklist.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IGroceryService _groceryService;
        private readonly ICategoryService _categoryService;

        public SettingsController(IGroceryService groceryService, ICategoryService categoryService)
        {
            _groceryService = groceryService;
            _categoryService = categoryService;
        }

        [HttpPost]
        public void CreateGrocery([FromBody]GroceryDTO groceryDTO)
        {
            var category = _categoryService.GetCategoryById(groceryDTO.CategoryId);
            var grocery = new Grocery(groceryDTO.GroceryName, category);
            _groceryService.Create(grocery);
        }
    }
}