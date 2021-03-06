﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checklist.Models
{
    public class Grocery
    {
        //public Grocery()
        //{ }

        //public Grocery(string groceryName, Category category)
        //{
        //    GroceryId = Guid.NewGuid();
        //    GroceryName = groceryName;
        //    Category = category;
        //}

        //public Grocery(Guid groceryId, string groceryName, Category category)
        //{
        //    GroceryId = groceryId;
        //    GroceryName = groceryName;
        //    Category = category;
        //}

        //[Key]
        public Guid GroceryId { get; set; }
        public string GroceryName { get; set; }
        [ForeignKey("categoryId")]
        public virtual Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<GroceryShoppingList> GroceryShoppingList { get; set; }

    }
}