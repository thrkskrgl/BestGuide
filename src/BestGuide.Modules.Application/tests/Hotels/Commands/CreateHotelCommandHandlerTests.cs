using BestGuide.Modules.Application.Hotels.Commands;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Services;
using Moq;

namespace BestGuide.Modules.Application.UnitTest.Hotels.Commands
{
    [TestClass]
    public class CreateHotelCommandHandlerTests
    {
        private CreateHotelCommandHandler _testClass;
        private Mock<IHotelService> _hotelService;

        [TestInitialize]
        public void Setup() 
        { 
            _hotelService = new Mock<IHotelService>();
            _testClass = new CreateHotelCommandHandler(_hotelService.Object);
        }

        [TestMethod]
        public void CanConstruct()
        {
            var instance = new CreateHotelCommandHandler(_hotelService.Object);
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public async Task CanCallHandle()
        {
            var request = new CreateHotelCommand();
            var cancellationToken = CancellationToken.None;
            _hotelService.Setup(s => s.CreateAsync(It.IsAny<CreateHotelArgs>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Hotel());
            var result = await _testClass.Handle(request, cancellationToken);
            Assert.IsNotNull(result);
        }
    }
}
