using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checklist.DTO;
using Checklist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Checklist.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IGroceryService _groceryService;

        public SettingsController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }

        [HttpPost]
        public void Save([FromBody]Grocery grocery)
        {
            grocery.Id = Guid.NewGuid();
            _groceryService.Save(grocery);

        }


    }
}