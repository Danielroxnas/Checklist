using Checklist.Entity;
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
            var cat = new Category { Id = Guid.NewGuid(), Name = "Delete" };
            sut.Inserts(new List<Category> { new Category { Id = Guid.NewGuid(), Name = "1" }, new Category { Id = Guid.NewGuid(), Name = "2" } });
            sut.Insert(cat);
            unitOfWork.Save();

            sut.Delete(cat);
            unitOfWork.Save();

            Assert.That(_context.Categories.FirstOrDefault(x => x.Name == "Delete"), Is.Null);
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
