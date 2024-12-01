using BestGuide.Modules.Domain.Models;
using BestGuide.Modules.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BestGuide.Modules.Infrastructure.UnitTest.Persistence
{
    [TestClass]
    public class RepositoryFactoryTests
    {
        private Mock<ModulesDbContext> _dbContextMock;
        private Mock<DbSet<Hotel>> _hotelDbSetMock;
        private Mock<DbSet<HotelContact>> _hotelContactDbSetMock;
        private RepositoryFactory _repositoryFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            _hotelDbSetMock = new Mock<DbSet<Hotel>>();
            _hotelContactDbSetMock = new Mock<DbSet<HotelContact>>();

            _dbContextMock = new Mock<ModulesDbContext>(MockBehavior.Loose, new DbContextOptions<ModulesDbContext>());

            _dbContextMock.Setup(c => c.Set<Hotel>()).Returns(_hotelDbSetMock.Object);
            _dbContextMock.Setup(c => c.Set<HotelContact>()).Returns(_hotelContactDbSetMock.Object);

            _repositoryFactory = new RepositoryFactory(Mock.Of<IServiceProvider>(), _dbContextMock.Object);
        }

        [TestMethod]
        public void GetHotelRepository_ReturnsInstance()
        {
            // Act
            var hotelRepository = _repositoryFactory.GetHotelRepository();

            // Assert
            Assert.IsNotNull(hotelRepository);
            Assert.IsInstanceOfType(hotelRepository, typeof(HotelRepository));
        }

        [TestMethod]
        public void GetHotelContactRepository_ReturnsInstance()
        {
            // Act
            var hotelContactRepository = _repositoryFactory.GetHotelContactRepository();

            // Assert
            Assert.IsNotNull(hotelContactRepository);
            Assert.IsInstanceOfType(hotelContactRepository, typeof(HotelContactRepository));
        }
    }
}
