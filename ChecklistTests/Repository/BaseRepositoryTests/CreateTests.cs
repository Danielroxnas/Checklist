using Checklist.Entity;
using Checklist.Models;
using Checklist.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class CreateTests : _InMemoryOptions
    {

        [Test]
        public void It_should_insert_a_category()
        {
            var sut = new BaseRepository<Category>(_context);

            var id = Guid.NewGuid();
            sut.Create(new Category { CategoryId = id, CategoryName = "Chark" });
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            Assert.That(_context.Categories.FirstOrDefault(x => x.CategoryId == id), Is.Not.Null);
            Assert.That(_context.Categories
                .FirstOrDefault(x => x.CategoryId == id).CategoryName, Is.EqualTo("Chark"));

        }
        [Test]
        public void It_should_throw_ArgumentNullException_if_grocery_is_null()
        {
            var sut = new BaseRepository<Category>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Create((Category)null));
        }

        [Test]
        public void It_should_insert_a_gorcery()
        {
            var id = Guid.NewGuid();
            var entity = new Grocery
            { GroceryId = id, GroceryName = "Bananer", Category = new Category() };
            var sut = new BaseRepository<Grocery>(_context);

            sut.Create(entity);
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            Assert.That(_context.Groceries.FirstOrDefault(x => x.GroceryId == id), Is.Not.Null);
            Assert.That(_context.Groceries
                .FirstOrDefault(x => x.GroceryId == id).GroceryName, Is.EqualTo("Bananer"));
        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_category_is_null()
        {
            var sut = new BaseRepository<Category>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Create((Category)null));
        }
        [Test]
        public void It_should_insert_a_shopping_list()
        {
            var id = Guid.NewGuid();
            var sut = new BaseRepository<ShoppingList>(_context);

            sut.Create(new ShoppingList
            {
                ShoppingListId = id
            });
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();

            Assert.That(_context.ShoppingList.FirstOrDefault(x => x.ShoppingListId == id), Is.Not.Null);

        }
        [Test]
        public void It_should_throw_ArgumentNullException_if_null()
        {
            var sut = new BaseRepository<ShoppingList>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Create((ShoppingList)null));

        }
        [Test]
        public void It_should_inserts_groceries()
        {
            var bananerId = Guid.NewGuid();
            var teId = Guid.NewGuid();
            var sut = new BaseRepository<Grocery>(_context);
            sut.Create(new List<Grocery>{
                new Grocery {GroceryId = bananerId, GroceryName = "Bananer", Category = new Category() },
                new Grocery{GroceryId = teId, GroceryName = "Te", Category = new Category() }});
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
    }
}
