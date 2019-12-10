using Checklist.Entity;
using Checklist.Models;
using System;

namespace Checklist.Repository
{
    public class CreateRepository : ICreateRepository
    {
        private readonly ChecklistContext _checklistContext;

        public CreateRepository(ChecklistContext checklistContext)
        {
            _checklistContext = checklistContext;
        }

        public void CreateShoppingList(ShoppingList list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            _checklistContext.ShoppingList.Add(list);
            _checklistContext.SaveChanges();
        }

        public void CreateGrocery(Grocery grocery)
        {
            if (grocery is null)
            {
                throw new ArgumentNullException(nameof(grocery));
            }
            _checklistContext.Groceries.Add(grocery);
            _checklistContext.SaveChanges();
        }

        public void CreateCategory(Category category)
        {
            if (category is null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _checklistContext.Categories.Add(category);
            _checklistContext.SaveChanges();
        }

        public void CreateUser(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _checklistContext.Users.Add(user);
            _checklistContext.SaveChanges();
        }
    }
}
