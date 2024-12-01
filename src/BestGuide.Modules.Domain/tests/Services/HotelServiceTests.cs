using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Events;
using BestGuide.Modules.Domain.Models;
using BestGuide.Modules.Domain.Persistence;
using BestGuide.Modules.Domain.Services;
using FluentAssertions;
using MediatR;
using Moq;

namespace BestGuide.Modules.Domain.UnitTest.Services
{
    [TestClass]
    public class HotelServiceTests
    {
        private Mock<IHotelRepository> _hotelRepositoryMock;
        private Mock<IRepositoryFactory> _repositoryFactoryMock;
        private Mock<IMediator> _mediatorMock;
        private HotelService _hotelService;

        [TestInitialize]
        public void Setup()
        {
            _hotelRepositoryMock = new Mock<IHotelRepository>();
            _repositoryFactoryMock = new Mock<IRepositoryFactory>();
            _repositoryFactoryMock.Setup(f => f.GetHotelRepository()).Returns(_hotelRepositoryMock.Object);
            _mediatorMock = new Mock<IMediator>();

            _hotelService = new HotelService(_repositoryFactoryMock.Object, _mediatorMock.Object);
        }

        [TestMethod]
        public async Task CreateAsync_ShouldCallRepositoryAddAndReturnEntity()
        {
            // Arrange
            var args = new CreateHotelArgs { };
            var hotel = new Hotel { };

            _hotelRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Hotel>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(hotel);

            // Act
            var result = await _hotelService.CreateAsync(args);

            // Assert
            result.Should().Be(hotel);
            _hotelRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Hotel>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteIfExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var args = new DeleteHotelArgs { Id = id };
            var hotel = new Hotel { Id = id };

            _hotelRepositoryMock.Setup(r => r.GetAsync(It.IsAny<GetHotelByIdArgs>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(hotel);

            // Act
            await _hotelService.DeleteAsync(args);

            // Assert
            _hotelRepositoryMock.Verify(r => r.GetAsync(It.IsAny<GetHotelByIdArgs>(), It.IsAny<CancellationToken>()), Times.Once);
            _hotelRepositoryMock.Verify(r => r.DeleteAsync(hotel, It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task DeleteAsync_ShouldNotCallDeleteIfEntityNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var args = new DeleteHotelArgs { Id = id };

            _hotelRepositoryMock.Setup(r => r.GetAsync(It.IsAny<GetHotelByIdArgs>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Hotel)null);

            // Act
            await _hotelService.DeleteAsync(args);

            // Assert
            _hotelRepositoryMock.Verify(r => r.GetAsync(It.IsAny<GetHotelByIdArgs>(), It.IsAny<CancellationToken>()), Times.Once);
            _hotelRepositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Hotel>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [TestMethod]
        public async Task PrepareReportAsync_ShouldPublishHotelReportUpdatedMessage()
        {
            // Arrange
            var args = new PrepareHotelReportArgs
            {
                ReportId = Guid.NewGuid(),
                ContactType = Enums.HotelContactType.Telephone,
                ContactContent = "123456"
            };

            var hotels = new List<Hotel>
            {
                new() {
                    Contacts =
                    [
                        new HotelContact { Type = Enums.HotelContactType.Telephone },
                        new HotelContact { Type = Enums.HotelContactType.Email }
                    ]
                },
                new() {
                    Contacts =
                    [
                        new HotelContact { Type = Enums.HotelContactType.Telephone }
                    ]
                }
            };

            _hotelRepositoryMock.Setup(r => r.ListAsync(It.IsAny<SearchHotelArgs>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(hotels);

            // Act
            await _hotelService.PrepareReportAsync(args);

            // Assert
            _mediatorMock.Verify(m => m.Publish(It.Is<HotelReportUpdated>(message =>
                message.Id == args.ReportId.Value), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task PrepareReportAsync_ShouldNotPublishMessageIfNoHotelsFound()
        {
            // Arrange
            var args = new PrepareHotelReportArgs { ReportId = Guid.NewGuid() };
            _hotelRepositoryMock.Setup(r => r.ListAsync(It.IsAny<SearchHotelArgs>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync([]);

            // Act
            await _hotelService.PrepareReportAsync(args);

            // Assert
            _mediatorMock.Verify(m => m.Publish(It.IsAny<HotelReportUpdated>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
