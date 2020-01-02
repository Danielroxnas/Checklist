using Checklist.Entity;
using Checklist.Models;
using Checklist.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Checklist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public IndexController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories().ToList();
        } 
    }
}