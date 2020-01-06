using Checklist.Entity;
using Checklist.Models;
using Checklist.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class InsertsTests : _InMemoryOptions
    {

        [Test]
        public void It_should_inserts_groceries()
        {
            var bananerId = Guid.NewGuid();
            var teId = Guid.NewGuid();
            var sut = new BaseRepository<Grocery>(_context);
            sut.Inserts(new List<Grocery>{
                new Grocery {Id = bananerId, Name = "Bananer", CategoryId = Guid.NewGuid() },
                new Grocery{Id = teId, Name = "Te", CategoryId = Guid.NewGuid() }});
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            Assert.That(_context.Groceries.FirstOrDefault(x => x.Id == bananerId), Is.Not.Null);
            Assert.That(_context.Groceries
                .FirstOrDefault(x => x.Id == bananerId).Name, Is.EqualTo("Bananer"));
            Assert.That(_context.Groceries
                .FirstOrDefault(x => x.Id == teId).Name, Is.EqualTo("Te"));

        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_groceries_is_null()
        {
            var sut = new BaseRepository<Grocery>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Inserts(null));

        }
        [Test]
        public void It_should_inserts_categories()
        {
            var mejeriId = Guid.NewGuid();
            var charkId = Guid.NewGuid();
            var sut = new BaseRepository<Category>(_context);
            sut.Inserts(new List<Category>{
                new Category {Id = mejeriId, Name = "Mejeri" },
                new Category{Id = charkId, Name = "Chark" }});
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            Assert.That(_context.Categories.FirstOrDefault(x => x.Id == mejeriId), Is.Not.Null);
            Assert.That(_context.Categories
                .FirstOrDefault(x => x.Id == mejeriId).Name, Is.EqualTo("Mejeri"));
            Assert.That(_context.Categories
                .FirstOrDefault(x => x.Id == charkId).Name, Is.EqualTo("Chark"));

        }
        [Test]
        public void It_should_throw_ArgumentNullException_if_categories_is_null()
        {
            var sut = new BaseRepository<Category>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Inserts(null));

        }
    }
}
