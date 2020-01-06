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
    public class UpdateTests : _InMemoryOptions
    {
        [Test]
        public void It_shall_update_entity()
        {
                var mejeriId = Guid.NewGuid();
                var charkId = Guid.NewGuid();
                var sut = new BaseRepository<Category>(_context);
                var categories = new List<Category>{
                new Category {Id = mejeriId, Name = "Mejeri" },
                new Category{Id = charkId, Name = "Chark" }};
                sut.Inserts(categories);
                var unitOfWork = new UnitOfWork(_context);
                unitOfWork.Save();
                var cat = categories.First();
                cat.Name = "M";
                sut.Update(cat);
                unitOfWork.Save();

                Assert.That(_context.Categories.FirstOrDefault(x => x.Id == mejeriId).Name, Is.EqualTo("M"));
            
        }
    }
}
