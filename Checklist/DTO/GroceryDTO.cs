using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist.DTO
{
    public class GroceryDTO
    {
        public Guid GroceryId { get; set; }
        public string GroceryName { get; set; }
        public Guid CategoryId { get; set; }
    }
}
