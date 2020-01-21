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
        private IBaseRepository<Category> _repository;
        private IUnitOfWork _unitOfWork;
        private List<Category> _categories;
        private CategoryService _sut;

        [SetUp]
        public void Setup()
        {
            _repository = Mock.Of<IBaseRepository<Category>>();
            _unitOfWork = Mock.Of<IUnitOfWork>();
            
            _categories = new List<Category> {
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "cat1" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "cat2" }} ;
            
            Mock.Get(_repository).Setup(x => x.Get(null,null)).Returns(() => _categories);

            _sut = new CategoryService(_repository, _unitOfWork);

        }
        [Test]
        public void It_should_get_all_categories()
        {
            var result = _sut.GetAllCategories();
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void It_should_throw_if_no_categories_was_found()
        {
            _categories = null;
            Assert.Throws<ArgumentNullException>(() => _sut.GetAllCategories());
        }
    }
}
