using Checklist.Models;
using Checklist.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class InsertTests : _InMemoryOptions
    {

        [Test]
        public void It_should_insert_a_category()
        {
            var sut = new BaseRepository<Category>(_context);

            var id = Guid.NewGuid();
            sut.Insert(new Category { Id = id, Name = "Chark" });
            sut.Commit();
            Assert.That(_context.Categories.FirstOrDefault(x => x.Id == id), Is.Not.Null);
            Assert.That(_context.Categories
                .FirstOrDefault(x => x.Id == id).Name, Is.EqualTo("Chark"));
        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_grocery_is_null()
        {
            var sut = new BaseRepository<Category>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Insert(null));
        }

        [Test]
        public void It_should_insert_a_gorcery()
        {
            var id = Guid.NewGuid();
            var entity = new Grocery
            { Id = id, Name = "Bananer", CategoryId = Guid.NewGuid() };
            var sut = new BaseRepository<Grocery>(_context);

            sut.Insert(entity);
            sut.Commit();
            Assert.That(_context.Groceries.FirstOrDefault(x => x.Id == id), Is.Not.Null);
            Assert.That(_context.Groceries
                .FirstOrDefault(x => x.Id == id).Name, Is.EqualTo("Bananer"));
        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_category_is_null()
        {
            var sut = new BaseRepository<Category>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Insert(null));
        }
        [Test]
        public void It_should_insert_a_shopping_list()
        {
            var id = Guid.NewGuid();
            var sut = new BaseRepository<ShoppingList>(_context);

            sut.Insert(new ShoppingList
            {
                Id = id,
                Groceries = new List<Grocery> {
                    new Grocery { Id = Guid.NewGuid(), CategoryId = Guid.NewGuid(), Name = "Bananer" }
                }
            });
            sut.Commit();

            Assert.That(_context.ShoppingList.FirstOrDefault(x => x.Id == id), Is.Not.Null);
            Assert.That(_context.ShoppingList.FirstOrDefault(x => x.Id == id).Groceries.Select(x => x.Name).First(), Is.EqualTo("Bananer"));
        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_null()
        {
            var sut = new BaseRepository<ShoppingList>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Insert(null));
        }

        [Test]
        public void It_should_inserts_groceries()
        {
            var bananerId = Guid.NewGuid();
            var teId = Guid.NewGuid();
            var sut = new BaseRepository<Grocery>(_context);
            sut.Inserts(new List<Grocery>{
                new Grocery {Id = bananerId, Name = "Bananer", CategoryId = Guid.NewGuid() },
                new Grocery{Id = teId, Name = "Te", CategoryId = Guid.NewGuid() }});
            sut.Commit();
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
    }
}
