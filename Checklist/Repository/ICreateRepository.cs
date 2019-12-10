using Checklist.Models;

namespace Checklist.Repository
{
    public interface ICreateRepository
    {
        void CreateCategory(Category category);
        void CreateGrocery(Grocery grocery);
        void CreateShoppingList(ShoppingList list);
        void CreateUser(User user);
    }
}