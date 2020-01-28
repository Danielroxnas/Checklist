using System;

namespace Checklist.DTO
{
    public class GroceryDTO
    {
        public Guid GroceryId { get; set; }
        public string GroceryName { get; set; }
        public Guid CategoryId { get; set; }
    }
}
