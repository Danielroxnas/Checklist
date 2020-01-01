using Checklist.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class _InMemoryOptions
    {
        public _InMemoryOptions()
        {
                var optionsBuilder = new DbContextOptionsBuilder<ChecklistContext>();
                optionsBuilder.UseInMemoryDatabase(DateTime.Now + "_Database");
                _context = new ChecklistContext(optionsBuilder.Options);
         
        }

        public ChecklistContext _context { get; private set; }
    }
}
