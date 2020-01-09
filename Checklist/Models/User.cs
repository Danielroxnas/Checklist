using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class User
    {
        public User()
        {
            Checklists = new HashSet<ShoppingList>();
        }
        [Required]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<ShoppingList> Checklists { get; set; }
    }
}