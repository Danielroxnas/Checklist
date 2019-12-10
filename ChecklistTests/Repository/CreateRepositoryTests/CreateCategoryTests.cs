using Checklist.Entity;
using Checklist.Models;
using Checklist.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace ChecklistTests.Repository.CreateRepositoryTests
{
    public class CreateCategoryTests
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
        public void It_should_create_a_category()
        {
            var id = Guid.NewGuid();
            _sut.CreateCategory(new Category { Id = id, Name = "Chark" });
            Assert.That(_context.Categories.FirstOrDefault(x => x.Id == id), Is.Not.Null);
            Assert.That(_context.Categories
                .FirstOrDefault(x => x.Id == id).Name, Is.EqualTo("Chark"));
        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_null()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.CreateCategory(null));
        }
    }
}
