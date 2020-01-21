using Checklist.Models;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Context
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryShoppingList>()
                .HasKey(bc => new { bc.GroceryId, bc.ShoppingListId});
            modelBuilder.Entity<GroceryShoppingList>()
                .HasOne(bc => bc.Grocery)
                .WithMany(b => b.GroceryShoppingList)
                .HasForeignKey(bc => bc.GroceryId);
            modelBuilder.Entity<GroceryShoppingList>()
                .HasOne(bc => bc.ShoppingList)
                .WithMany(c => c.GroceryShoppingList)
                .HasForeignKey(bc => bc.ShoppingListId);
        }
    }
}