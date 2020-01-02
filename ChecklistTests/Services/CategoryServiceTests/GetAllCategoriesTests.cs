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
            var categories = new List<Category> {
                new Category { Id = Guid.NewGuid(), Name = "cat1" },
                new Category { Id = Guid.NewGuid(), Name = "cat2" }} ;
            Mock.Get(repository).Setup(x => x.GetAll()).Returns(categories);

            var sut = new CategoryService(repository);
            var result = sut.GetAllCategories();
            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}
