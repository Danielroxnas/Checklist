using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class User : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ShoppingList> Checklists { get; set; }
    }
}