using Checklist.Models;
using Checklist.Repository;
using Checklist.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChecklistTests.Services.CategoryServiceTests
{
    public class GetGetegoryByIdTests
    {
        [Test]
        public void It_should_get_category_by_id()
        {
            var repository = Mock.Of<IBaseRepository<Category>>();
            var unitOfWork = Mock.Of<IUnitOfWork>();

            Guid id = Guid.NewGuid();
            var category = new Category { Id = id, Name = "cat1" };
            
            Mock.Get(repository).Setup(x => x.GetById(category.Id)).Returns(category);

            var sut = new CategoryService(repository, unitOfWork);
            var result = sut.GetCategoryById(category.Id);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo("cat1"));
        }
    }
}
