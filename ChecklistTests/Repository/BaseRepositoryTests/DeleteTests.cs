using Checklist.Context;
using Checklist.Models;
using Checklist.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChecklistTests.Repository.BaseRepositoryTests
{
    public class DeleteTests : _InMemoryOptions
    {
        [Test]
        public void It_should_delete_category_entity()
        {
            var sut = new BaseRepository<Category>(_context);
            var unitOfWork = new UnitOfWork(_context);
            var cat = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Delete" };
            sut.Create(new List<Category> { new Category { CategoryId = Guid.NewGuid(), CategoryName = "1" }, new Category { CategoryId = Guid.NewGuid(), CategoryName = "2" } });
            sut.Create(cat);
            unitOfWork.Save();

            sut.Delete(cat);
            unitOfWork.Save();

            Assert.That(_context.Categories.FirstOrDefault(x => x.CategoryName == "Delete"), Is.Null);
            Assert.That(_context.Categories.Count(), Is.EqualTo(2));
        }


        [Test]
        public void It_should_throw_error_if_entity_is_null()
        {
            var sut = new BaseRepository<Category>(_context);

            Assert.Throws<ArgumentNullException>(() => sut.Delete(null));

        }
    }
}
