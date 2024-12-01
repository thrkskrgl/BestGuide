using AutoMapper;
using BestGuide.Modules.Application.HotelContacts.Commands;
using BestGuide.Modules.Areas.HotelContact;
using BestGuide.Modules.Areas.HotelContact.Models.Requests;
using BestGuide.Modules.Areas.HotelContact.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BestGuide.Modules.UnitTest.Areas.HotelContact
{
    [TestClass]
    public class HotelContactControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private Mock<IMapper> _mapperMock;
        private HotelContactController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _controller = new HotelContactController(_mediatorMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task CreateHotelContact_ReturnsOk()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var request = new CreateHotelContactRequest { Content = "TestValue", HotelId = guid };
            var createdHotel = new Domain.Models.HotelContact { Id = 1234, Content = "TestValue" };
            var createdResponse = new HotelContactResponse { Id = 1234, Content = "TestValue" };

            _mapperMock.Setup(m => m.Map<CreateHotelContactCommand>(request)).Returns(new CreateHotelContactCommand() { Content = "TestValue"});
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateHotelContactCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(createdHotel);
            _mapperMock.Setup(m => m.Map<HotelContactResponse>(createdHotel)).Returns(createdResponse);

            // Act
            var result = await _controller.CreateHotelContact(request, CancellationToken.None) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            var response = result.Value as HotelContactResponse;
            Assert.IsNotNull(response);
            Assert.AreEqual(createdHotel.Id, response.Id);
            Assert.AreEqual(createdHotel.Content, response.Content);
        }

        [TestMethod]
        public async Task CreateHotel_ReturnsServerError()
        {
            // Arrange
            var request = new CreateHotelContactRequest { Content = "TestValue" };
            _mapperMock.Setup(m => m.Map<CreateHotelContactCommand>(request)).Returns(new CreateHotelContactCommand() { Content = "TestValue"});
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateHotelContactCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(null as Domain.Models.HotelContact);

            // Act
            var result = await _controller.CreateHotelContact(request, CancellationToken.None) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
    }
}
