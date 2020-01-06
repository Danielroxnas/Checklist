using Checklist.Models;
using Checklist.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class GetByExpressionTests : _InMemoryOptions
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
            var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Save();
            var result = sut.GetByExpression(x =>  x.Name.Contains("Mej"));
            Assert.That(result.First().Id, Is.EqualTo(mejeriId));
            Assert.That(result.First().Name, Is.EqualTo("Mejeri"));

        }
    }
}
