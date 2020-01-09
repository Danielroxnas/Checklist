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
    public class GetAllCategoriesTests
    {
        [Test]
        public void It_should_get_all_categories()
        {
            var repository = Mock.Of<IBaseRepository<Category>>();
            var unitOfWork = Mock.Of<IUnitOfWork>();
            
            var categories = new List<Category> {
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "cat1" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "cat2" }} ;
            
            Mock.Get(repository).Setup(x => x.Get(null,null)).Returns(categories);

            var sut = new CategoryService(repository, unitOfWork);
            var result = sut.GetAllCategories();
            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}
