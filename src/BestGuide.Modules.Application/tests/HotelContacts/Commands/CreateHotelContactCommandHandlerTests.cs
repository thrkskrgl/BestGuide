using BestGuide.Modules.Application.HotelContacts.Commands;
using BestGuide.Modules.Domain.Args.HotelContactArgs;
using BestGuide.Modules.Domain.Services;
using Moq;

namespace BestGuide.Modules.Application.UnitTest.Hotels.Commands
{
    [TestClass]
    public class CreateHotelContactCommandHandlerTests
    {
        private CreateHotelContactCommandHandler _testClass;
        private Mock<IHotelContactService> _hotelContactService;

        [TestInitialize]
        public void Setup() 
        {
            _hotelContactService = new Mock<IHotelContactService>();
            _testClass = new CreateHotelContactCommandHandler(_hotelContactService.Object);
        }

        [TestMethod]
        public void CanConstruct()
        {
            var instance = new CreateHotelContactCommandHandler(_hotelContactService.Object);
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new CreateHotelContactCommand() { Content = "TestValue" };
            var cancellationToken = CancellationToken.None;

            _hotelContactService.Setup(s => s.CreateAsync(It.IsAny<CreateHotelContactArgs>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.HotelContact());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
