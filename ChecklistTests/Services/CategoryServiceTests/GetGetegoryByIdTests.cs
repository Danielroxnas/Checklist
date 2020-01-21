using Checklist.Models;
using Checklist.Repository;
using Checklist.Services;
using Moq;
using NUnit.Framework;
using System;

namespace ChecklistTests.Services.CategoryServiceTests
{
    public class GetGetegoryByIdTests
    {
        private IBaseRepository<Category> _repository;
        private IUnitOfWork _unitOfWork;
        private Guid _categoryId;
        private CategoryService _sut;
        private Category _category;

        [SetUp]
        public void Setup()
        {
            _repository = Mock.Of<IBaseRepository<Category>>();
            _unitOfWork = Mock.Of<IUnitOfWork>();

            _categoryId = Guid.NewGuid();
            _category = new Category { CategoryId = _categoryId, CategoryName = "cat1" };

            Mock.Get(_repository).Setup(x => x.GetById(_category.CategoryId)).Returns(() => _category);

            _sut = new CategoryService(_repository, _unitOfWork);
        }

        [Test]
        public void It_should_get_category_by_id()
        {
            var result = _sut.GetCategoryById(_categoryId);
            Assert.That(result.CategoryId, Is.EqualTo(_categoryId));
            Assert.That(result.CategoryName, Is.EqualTo("cat1"));
        }
        [Test]
        public void It_should_throw_if_no_categories_was_found()
        {
            _category = null;
            Assert.Throws<ArgumentNullException>(() => _sut.GetCategoryById(_categoryId));
        }
    }
}
