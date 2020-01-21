using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class Grocery
    {
        public Grocery()
        {}

        public Grocery(string groceryName, Category category)
        {
            GroceryId = Guid.NewGuid();
            GroceryName = groceryName;
            Category = category;
        }

        public Grocery(Guid groceryId, string groceryName, Category category)
        {
            GroceryId = groceryId;
            GroceryName = groceryName;
            Category = category;
        }

        [Required]
        public Guid GroceryId { get; set; }
        public string GroceryName { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<GroceryShoppingList> GroceryShoppingList { get; set; }

    }
}