using Checklist.Models;

namespace Checklist.Controllers
{
    public interface IGroceryService
    {
        void Save(Grocery grocery);
    }
}