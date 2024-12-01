using BestGuide.Modules.Application.Hotels.Commands;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Services;
using Moq;

namespace BestGuide.Modules.Application.UnitTest.Hotels.Commands
{
    [TestClass]
    public class DeleteHotelCommandHandlerTests
    {
        private DeleteHotelCommandHandler _testClass;
        private Mock<IHotelService> _hotelService;

        [TestInitialize]
        public void Setup() 
        { 
            _hotelService = new Mock<IHotelService>();
            _testClass = new DeleteHotelCommandHandler(_hotelService.Object);
        }

        [TestMethod]
        public void CanConstruct()
        {
            var instance = new DeleteHotelCommandHandler(_hotelService.Object);
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public async Task CanCallHandle()
        {
            var request = new DeleteHotelCommand();
            var cancellationToken = CancellationToken.None;
            _hotelService.Setup(s => s.DeleteAsync(It.IsAny<DeleteHotelArgs>(), It.IsAny<CancellationToken>()));
            await _testClass.Handle(request, cancellationToken);
        }
    }
}
