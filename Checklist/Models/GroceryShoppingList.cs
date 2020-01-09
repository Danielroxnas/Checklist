using System;

namespace Checklist.Models
{
    public class GroceryShoppingList
    {
        public Guid GroceryId { get; set; }
        public Guid ShoppingListId { get; set; }
        public Grocery Grocery { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}