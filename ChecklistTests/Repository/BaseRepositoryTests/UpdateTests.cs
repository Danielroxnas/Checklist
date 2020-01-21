using Checklist.Context;
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
                new Category {CategoryId = mejeriId, CategoryName = "Mejeri" },
                new Category{CategoryId = charkId, CategoryName = "Chark" }};
                sut.Create(categories);
                var unitOfWork = new UnitOfWork(_context);
                unitOfWork.Save();
                var cat = categories.First();
                cat.CategoryName = "M";
                sut.Update(cat);
                unitOfWork.Save();

                Assert.That(_context.Categories.FirstOrDefault(x => x.CategoryId == mejeriId).CategoryName, Is.EqualTo("M"));
            
        }
    }
}
