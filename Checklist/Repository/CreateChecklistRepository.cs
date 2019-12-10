using Checklist.Entity;
using Checklist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checklist.Repository
{
    public class CreateChecklistRepository
    {
        private readonly ChecklistContext _checklistContext;

        public CreateChecklistRepository(ChecklistContext checklistContext)
        {
            _checklistContext = checklistContext;
        }

        public void CreateShopingList(List<Grocery> list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }


        }
    }
}
