using Checklist.Context;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class _InMemoryOptions
    {
        public DbContextOptionsBuilder<ChecklistContext> _optionsBuilder;

        public ChecklistContext _context { get; private set; }

        [SetUp]
        public void Setup()
        {
            _optionsBuilder = new DbContextOptionsBuilder<ChecklistContext>();
            _optionsBuilder.UseInMemoryDatabase(DateTime.UtcNow + "_Database");
           _context = new ChecklistContext(_optionsBuilder.Options);
        }
        [TearDown]
        public void Teardown()
        {
            _context.Database.EnsureDeleted();
        }

    }
}
