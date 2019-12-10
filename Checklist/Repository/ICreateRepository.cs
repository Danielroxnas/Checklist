using Checklist.Models;
using System.Collections.Generic;

namespace Checklist.Repository
{
    public interface ICreateRepository
    {
        void CreateGroceries(List<Grocery> groceries);
        void CreateCategory(Category category);
        void CreateGrocery(Grocery grocery);
        void CreateShoppingList(ShoppingList list);
        void CreateUser(User user);
    }
}