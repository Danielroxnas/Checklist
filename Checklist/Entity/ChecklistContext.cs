using Checklist.Models;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Entity
{
    public class ChecklistContext : DbContext
    {
        public ChecklistContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingList> ShoppingList { get; set; }
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}