using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class Category 
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}