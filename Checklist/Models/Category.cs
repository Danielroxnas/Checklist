using System;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class Category
    {
        public string Name { get; set; }
        [Key]
        public Guid Id { get; set; }
    }
}