using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class Checklist
    {
        [Key]
        public Guid Id { get; set; }
        public List<Grocery> Groceries { get; set; }
    }
}