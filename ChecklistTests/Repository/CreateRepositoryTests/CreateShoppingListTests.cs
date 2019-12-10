using Checklist.Entity;
using Checklist.Models;
using Checklist.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChecklistTests.Repository.CreateRepositoryTests
{
    public class CreateShoppingListTests
    {
        private ChecklistContext _context;
        private CreateRepository _sut;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChecklistContext>();
            optionsBuilder.UseInMemoryDatabase(DateTime.Now +"_Database" );
            _context = new ChecklistContext( optionsBuilder.Options);
            _sut = new CreateRepository(_context);
        }

        [Test]
        public void It_should_create_a_shoping_list()
        {
            var id = Guid.NewGuid();
            _sut.CreateShoppingList(new ShoppingList { 
                Id = id, 
                Groceries = new List<Grocery> { 
                    new Grocery { Id = Guid.NewGuid(), CategoryId = Guid.NewGuid(), Name = "Bananer" } 
                } });
            Assert.That(_context.ShoppingList.FirstOrDefault(x => x.Id == id), Is.Not.Null);
            Assert.That(_context.ShoppingList.FirstOrDefault(x => x.Id == id).Groceries.Select(x => x.Name).First(), Is.EqualTo("Bananer"));
        }

        [Test]
        public void It_should_throw_ArgumentNullException_if_list_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.CreateShoppingList(null));
        }
    }
}