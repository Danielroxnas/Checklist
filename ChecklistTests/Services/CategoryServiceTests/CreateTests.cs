using Checklist.Models;
using Checklist.Repository;
using Checklist.Services;
using Moq;
using NUnit.Framework;
using System;

namespace ChecklistTests.Services.CategoryServiceTests
{
    public class CreateTests
    {
        [Test]
        public void It_should_call_insert()
        {
            var repository = Mock.Of<IBaseRepository<Category>>();
            var uow = Mock.Of<IUnitOfWork>();

            var sut = new CategoryService(repository,uow);
            var category = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Test" };
            sut.Create(category);

            Mock.Get(repository).Verify(x => x.Create(category), Times.Once);
            Mock.Get(uow).Verify(x => x.Save(), Times.Once);
        }
    }
}
