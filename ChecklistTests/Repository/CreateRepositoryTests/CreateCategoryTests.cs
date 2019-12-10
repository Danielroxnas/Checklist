using Checklist.Entity;
using Checklist.Models;
using Checklist.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;

namespace ChecklistTests.Repository.CreateRepositoryTests
{
    public class InsertTests
    {
        private ChecklistContext _context;
        private BaseRepository<Category> _sut;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChecklistContext>();
            optionsBuilder.UseInMemoryDatabase(DateTime.Now + "_Database");
            _context = new ChecklistContext(optionsBuilder.Options);
            _sut = new BaseRepository<Category>(_context);
        }

        [Test]
        public void It_should_insert_a_category()
        {
            var id = Guid.NewGuid();
            _sut.Insert(new Category { Id = id, Name = "Chark" });
            _sut.Commit();
            Assert.That(_context.Categories.FirstOrDefault(x => x.Id == id), Is.Not.Null);
            Assert.That(_context.Categories
                .FirstOrDefault(x => x.Id == id).Name, Is.EqualTo("Chark"));
        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_null()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.Insert(null));
        }
    }
}
