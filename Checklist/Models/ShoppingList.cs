using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class ShoppingList : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public List<Grocery> Groceries { get; set; }
    }
}