using Checklist.Entity;
using Checklist.Models;
using Checklist.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class CreatesTests : _InMemoryOptions
    {

        [Test]
        public void It_should_inserts_groceries()
        {
            var bananerId = Guid.NewGuid();
            var teId = Guid.NewGuid();
            var sut = new BaseRepository<Grocery>(_context);
            sut.Create(new List<Grocery>{
                new Grocery {GroceryId = bananerId, GroceryName = "Bananer", Category = new Category() },
                new Grocery {GroceryId = teId, GroceryName = "Te", Category = new Category()  }});
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            Assert.That(_context.Groceries.FirstOrDefault(x => x.GroceryId == bananerId), Is.Not.Null);
            Assert.That(_context.Groceries
                .FirstOrDefault(x => x.GroceryId == bananerId).GroceryName, Is.EqualTo("Bananer"));
            Assert.That(_context.Groceries
                .FirstOrDefault(x => x.GroceryId == teId).GroceryName, Is.EqualTo("Te"));

        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_groceries_is_null()
        {
            var sut = new BaseRepository<Grocery>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Create((List<Grocery>)null));

        }
        [Test]
        public void It_should_inserts_categories()
        {
            var mejeriId = Guid.NewGuid();
            var charkId = Guid.NewGuid();
            var sut = new BaseRepository<Category>(_context);
            sut.Create(new List<Category>{
                new Category {CategoryId = mejeriId, CategoryName = "Mejeri" },
                new Category{CategoryId = charkId, CategoryName = "Chark" }});
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            Assert.That(_context.Categories.FirstOrDefault(x => x.CategoryId == mejeriId), Is.Not.Null);
            Assert.That(_context.Categories
                .FirstOrDefault(x => x.CategoryId == mejeriId).CategoryName, Is.EqualTo("Mejeri"));
            Assert.That(_context.Categories
                .FirstOrDefault(x => x.CategoryId == charkId).CategoryName, Is.EqualTo("Chark"));

        }
        [Test]
        public void It_should_throw_ArgumentNullException_if_categories_is_null()
        {
            var sut = new BaseRepository<Category>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Create((List<Category>)null));

        }
    }
}
