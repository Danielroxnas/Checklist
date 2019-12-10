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
    public class CreateGroceriesTests
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
        public void It_should_create_groceries()
        {
            var bananerId = Guid.NewGuid();
            var teId = Guid.NewGuid();
            _sut.CreateGroceries(new List<Grocery>{ 
                new Grocery {Id = bananerId, Name = "Bananer", CategoryId = Guid.NewGuid() },
                new Grocery{Id = teId, Name = "Te", CategoryId = Guid.NewGuid() }});
            Assert.That(_context.Groceries.FirstOrDefault(x => x.Id == bananerId), Is.Not.Null);
            Assert.That(_context.Groceries
                .FirstOrDefault(x => x.Id == bananerId).Name, Is.EqualTo("Bananer"));
            Assert.That(_context.Groceries
                .FirstOrDefault(x => x.Id == teId).Name, Is.EqualTo("Te"));
        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_null()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.CreateGroceries(null));
        }
    }
}
