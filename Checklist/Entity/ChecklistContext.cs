

using Checklist.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Entity
{
    public class ChecklistContext : DbContext
    {
        public ChecklistContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Checklist> Checklists { get; set; }
        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Initial Catalog=Checklist;Trusted_Connection=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}