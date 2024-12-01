using AutoMapper;
using BestGuide.Modules.Application.Hotels.Commands;
using BestGuide.Modules.Application.Hotels.Queries;
using BestGuide.Modules.Areas.Hotel;
using BestGuide.Modules.Areas.Hotel.Models.Requests;
using BestGuide.Modules.Areas.Hotel.Models.Responses;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BestGuide.Modules.UnitTest.Areas.Hotel
{
    [TestClass]
    public class HotelControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private Mock<IMapper> _mapperMock;
        private HotelController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _controller = new HotelController(_mediatorMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task GetHotel_ReturnsNotFound()
        {
            // Arrange
            var hotelId = Guid.NewGuid();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetHotelsByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(null as Domain.Models.Hotel);

            // Act
            var result = await _controller.GetHotel(hotelId, CancellationToken.None) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [TestMethod]
        public async Task GetHotel_ReturnsOk()
        {
            // Arrange
            var hotelId = Guid.NewGuid();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetHotelsByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new Domain.Models.Hotel());

            // Act
            var result = await _controller.GetHotel(hotelId, CancellationToken.None) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }

        [TestMethod]
        public async Task CreateHotel_ReturnsOk()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var request = new CreateHotelRequest { Title = "New Hotel" };
            var createdHotel = new Domain.Models.Hotel { Id = guid, Title = "New Hotel" };
            var createdResponse = new HotelResponse { Id = guid, Title = "New Hotel" };

            _mapperMock.Setup(m => m.Map<CreateHotelCommand>(request)).Returns(new CreateHotelCommand());
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateHotelCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(createdHotel);
            _mapperMock.Setup(m => m.Map<HotelResponse>(createdHotel)).Returns(createdResponse);

            // Act
            var result = await _controller.CreateHotel(request, CancellationToken.None) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            var response = result.Value as HotelResponse;
            Assert.IsNotNull(response);
            Assert.AreEqual(createdHotel.Id, response.Id);
            Assert.AreEqual(createdHotel.Title, response.Title);
        }

        [TestMethod]
        public async Task CreateHotel_ReturnsServerError()
        {
            // Arrange
            var request = new CreateHotelRequest { Title = "New Hotel" };
            _mapperMock.Setup(m => m.Map<CreateHotelCommand>(request)).Returns(new CreateHotelCommand());
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateHotelCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(null as Domain.Models.Hotel);

            // Act
            var result = await _controller.CreateHotel(request, CancellationToken.None) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        [TestMethod]
        public async Task GetHotels_ReturnsOk()
        {
            // Arrange
            var request = new SearchHotelsRequest { Title = "Test" };
            var hotels = new List<Domain.Models.Hotel>
            {
                new() { Id = Guid.NewGuid(), Title = "Hotel 1" },
                new() { Id = Guid.NewGuid(), Title = "Hotel 2" }
            };
            var hotelsResponse = new List<HotelResponse>
            {
                new() { Id = Guid.NewGuid(), Title = "Hotel 1" },
                new() { Id = Guid.NewGuid(), Title = "Hotel 2" }
            };

            _mapperMock.Setup(m => m.Map<SearchHotelsQuery>(request)).Returns(new SearchHotelsQuery());
            _mediatorMock.Setup(m => m.Send(It.IsAny<SearchHotelsQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(hotels);
            _mapperMock.Setup(m => m.Map<HotelResponse[]>(hotels)).Returns([.. hotelsResponse]);

            // Act
            var result = await _controller.GetHotels(request, CancellationToken.None) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            var response = result.Value as HotelResponse[];
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Length);
        }
    }
}
