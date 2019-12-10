using System;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class Grocery
    {
        public string Name { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }

    }
}