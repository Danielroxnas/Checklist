using Checklist.Entity;
using Checklist.Models;
using Checklist.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class GetTests : _InMemoryOptions
    {


        [Test]
        public void It_shall_get_all_groceries()
        {

            var sut = new BaseRepository<Grocery>(_context);
            sut.Inserts(new List<Grocery>{
                new Grocery {Id = Guid.NewGuid(), Name = "Bananer", CategoryId = Guid.NewGuid() },
                new Grocery{Id = Guid.NewGuid(), Name = "Te", CategoryId = Guid.NewGuid() }});
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            var result = sut.Get(null, null).ToList();
            Assert.That(result.Count(), Is.EqualTo(2));

        }
        [Test]
        public void It_shall_get_groceries_based_on_skip()
        {
            var sut = new BaseRepository<Grocery>(_context);
            sut.Inserts(new List<Grocery>{
                new Grocery {Id = Guid.NewGuid(), Name = "Bananer", CategoryId = Guid.NewGuid() },
                new Grocery{Id = Guid.NewGuid(), Name = "Te", CategoryId = Guid.NewGuid() }});
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            var result = sut.Get(1, null).ToList();
            Assert.That(result.Count(), Is.EqualTo(1));

        }

        [Test]
        public void It_shall_get_groceries_based_on_take()
        {
            var sut = new BaseRepository<Grocery>(_context);
            sut.Inserts(new List<Grocery>{
                new Grocery {Id = Guid.NewGuid(), Name = "Bananer", CategoryId = Guid.NewGuid() },
                new Grocery{Id = Guid.NewGuid(), Name = "Te", CategoryId = Guid.NewGuid() }});
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            var result = sut.Get(null, 1).ToList();
            Assert.That(result.Count(), Is.EqualTo(1));
        }


        [Test]
        public void It_shall_get_all_categories()
        {

            var mejeriId = Guid.NewGuid();
            var charkId = Guid.NewGuid();
            var sut = new BaseRepository<Category>(_context);
            sut.Inserts(new List<Category>{
                new Category {Id = mejeriId, Name = "Mejeri" },
                new Category{Id = charkId, Name = "Chark" }});
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            var result = sut.Get(null, null).ToList();
            Assert.That(result.Count(), Is.EqualTo(2));

        }
    }
}
