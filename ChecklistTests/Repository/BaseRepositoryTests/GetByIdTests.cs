using Checklist.Context;
using Checklist.Models;
using Checklist.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class GetByIdTests : _InMemoryOptions
    {
        [Test]
        public void It_shall_get_category_by_id()
        {
            var mejeriId = Guid.NewGuid();
            var charkId = Guid.NewGuid();
            var sut = new BaseRepository<Category>(_context);
            sut.Create(new List<Category>{
                new Category {CategoryId = mejeriId, CategoryName = "Mejeri" },
                new Category{CategoryId = charkId, CategoryName = "Chark" }});
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            var result = sut.GetById(mejeriId);
            Assert.That(result.CategoryId, Is.EqualTo(mejeriId));
            Assert.That(result.CategoryName, Is.EqualTo("Mejeri"));

        }

    }
}
