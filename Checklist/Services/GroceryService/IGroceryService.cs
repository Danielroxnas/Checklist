using Checklist.DTO;
using Checklist.Models;

namespace Checklist.Services
{
    public interface IGroceryService
    {
        Grocery Create(Grocery grocery);
    }
}