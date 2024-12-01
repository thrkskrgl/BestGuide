using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Models;
using BestGuide.Modules.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BestGuide.Modules.Infrastructure.UnitTest.Persistence
{
    [TestClass]
    public class HotelRepositoryTests
    {
        private ModulesDbContext _dbContext;
        private HotelRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            // In-memory database context oluştur
            var options = new DbContextOptionsBuilder<ModulesDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            _dbContext = new ModulesDbContext(options);
            _repository = new HotelRepository(_dbContext);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _dbContext.Dispose();
        }

        [TestMethod]
        public void CanConstruct()
        {
            Assert.IsInstanceOfType(_repository, typeof(HotelRepository));
        }

        [TestMethod]
        public async Task GetAsync_ReturnsHotel()
        {
            // Arrange
            var hotel = new Hotel { Id = Guid.NewGuid(), Title = "Test Hotel" };
            await _dbContext.Hotels.AddAsync(hotel);
            await _dbContext.SaveChangesAsync();

            var args = new GetHotelByIdArgs { Id = hotel.Id };

            // Act
            var result = await _repository.GetAsync(args);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Hotel", result.Title);
        }

        [TestMethod]
        public async Task ListAsync_ReturnsHotels()
        {
            // Arrange
            var hotels = new List<Hotel>
            {
                new() { Id = Guid.NewGuid(), Title = "Hotel 1" },
                new() { Id = Guid.NewGuid(), Title = "Hotel 2" }
            };

            await _dbContext.Hotels.AddRangeAsync(hotels);
            await _dbContext.SaveChangesAsync();

            var args = new SearchHotelArgs();

            // Act
            var result = await _repository.ListAsync(args);

            // Assert
            Assert.IsTrue(result.Any(h => h.Title == "Hotel 1"));
            Assert.IsTrue(result.Any(h => h.Title == "Hotel 2"));
        }
    }
}
