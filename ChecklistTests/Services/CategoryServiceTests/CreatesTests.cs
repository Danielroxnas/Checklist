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
    public class CreatesTests
    {
        private IBaseRepository<Category> _repository;
        private IUnitOfWork _uow;
        private List<Category> _categories;
        private CategoryService _sut;

        [SetUp]
        public void Setup()
        {
            _repository = Mock.Of<IBaseRepository<Category>>();
            _uow = Mock.Of<IUnitOfWork>();
            _categories = new List<Category> { new Category { CategoryId = Guid.NewGuid(), CategoryName = "Bröd" } };
            Mock.Get(_repository).Setup(x => x.Get(null, null)).Returns(() => _categories );

            _sut = new CategoryService(_repository, _uow);
        }

        [Test]
        public void It_should_call_insert()
        {
            var categories = new List<Category>{ new Category { CategoryId = Guid.NewGuid(), CategoryName = "Test" } };
            _sut.Create(categories);

            Mock.Get(_repository).Verify(x => x.Create(categories), Times.Once);
            Mock.Get(_uow).Verify(x => x.Save(), Times.Once);
        }

        [Test]
        public void It_should_not_throw_error_if_no_categories_found()
        {
            _categories = null;
            var categories = new List<Category> { new Category { CategoryId = Guid.NewGuid(), CategoryName = "Test" } };
            _sut.Create(categories);

            Mock.Get(_repository).Verify(x => x.Create(categories), Times.Once);
            Mock.Get(_uow).Verify(x => x.Save(), Times.Once);
        }
        [Test]
        public void It_should_add_guid_to_new_categories()
        {
            var categories = new List<Category> { new Category { CategoryName = "Test" } };
            var result = _sut.Create(categories);

            Assert.That(result.First().CategoryId, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void It_should_return_null_if_no_categories()
        {
            var categories = new List<Category> { null };
            var result = _sut.Create(categories);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void It_should_return_null_if_categories_is_null()
        {
            List<Category> categories = null;
            var result = _sut.Create(categories);

            Assert.That(result, Is.Null);
        }
    }
}
