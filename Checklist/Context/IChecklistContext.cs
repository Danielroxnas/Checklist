﻿using Checklist.Models;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Context
{
    public interface IChecklistContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Grocery> Groceries { get; set; }
        DbSet<ShoppingList> ShoppingList { get; set; }
        DbSet<User> Users { get; set; }
    }
}