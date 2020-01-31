using System;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class Category 
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}