using Checklist.Models;
using Checklist.Repository;
using Checklist.Services;
using Moq;
using NUnit.Framework;

namespace ChecklistTests.Services.GroceryServiceTests
{
    public class CreateTests
    {
        private IBaseRepository<Grocery> _baseRepository;
        private IUnitOfWork _unitOfWork;
        private GroceryService _sut;

        [SetUp]
        public void Setup()
        {
            _baseRepository = Mock.Of<IBaseRepository<Grocery>>();
            _unitOfWork = Mock.Of<IUnitOfWork>();
            _sut = new GroceryService(_baseRepository, _unitOfWork);
        }
        [Test]
        public void It_should_call_baseRepository_create_once()
        {

            var grocery = new Grocery { };
            _sut.Create(grocery);
            Mock.Get(_baseRepository).Verify(x => x.Create(grocery), Times.Once);
        }

        [Test]
        public void It_should_call_unitOfWork_save_once()
        {
            var grocery = new Grocery { };
            _sut.Create(grocery);
            Mock.Get(_unitOfWork).Verify(x => x.Save(), Times.Once);
        }
    }
}
