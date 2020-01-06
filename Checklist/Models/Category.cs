﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Models
{
    public class Category 
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}