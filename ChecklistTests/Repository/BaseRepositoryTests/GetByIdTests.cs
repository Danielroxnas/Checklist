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
            sut.Inserts(new List<Category>{
                new Category {Id = mejeriId, Name = "Mejeri" },
                new Category{Id = charkId, Name = "Chark" }});
            sut.Commit();
            var result = sut.GetById(mejeriId);
            Assert.That(result.Id, Is.EqualTo(mejeriId));
            Assert.That(result.Name, Is.EqualTo("Mejeri"));

        }
    }
}
