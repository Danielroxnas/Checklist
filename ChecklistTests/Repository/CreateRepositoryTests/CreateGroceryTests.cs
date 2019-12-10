using Checklist.Entity;
using Checklist.Models;
using Checklist.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChecklistTests.Repository.CreateRepositoryTests
{
    public class CreateGroceryTests
    {
        private ChecklistContext _context;
        private CreateRepository _sut;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChecklistContext>();
            optionsBuilder.UseInMemoryDatabase(DateTime.Now + "_Database");
            _context = new ChecklistContext(optionsBuilder.Options);
            _sut = new CreateRepository(_context);
        }

        [Test]
        public void It_should_create_a_grocery()
        {
            var id = Guid.NewGuid();
            _sut.CreateGrocery(new Grocery
            {Id = id, Name = "Bananer", CategoryId = Guid.NewGuid()});
            Assert.That(_context.Groceries.FirstOrDefault(x => x.Id == id), Is.Not.Null);
            Assert.That(_context.Groceries
                .FirstOrDefault(x => x.Id == id).Name, Is.EqualTo("Bananer"));
        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_null()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.CreateGrocery(null));
        }
    }
}
