using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class ShoppingList
    {
        public Guid ShoppingListId { get; set; }
        public string ShoppingListName { get; set; }
        public virtual ICollection<GroceryShoppingList> GroceryShoppingList { get; set; }
        public virtual User User { get; set; }
    }
}