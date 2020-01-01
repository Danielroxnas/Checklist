using System;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class Grocery : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }

    }
}