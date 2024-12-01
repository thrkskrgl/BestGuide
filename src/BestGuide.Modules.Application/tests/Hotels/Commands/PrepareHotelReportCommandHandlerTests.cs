using BestGuide.Modules.Application.Hotels.Commands;
using BestGuide.Modules.Domain.Args.HotelArgs;
using BestGuide.Modules.Domain.Services;
using Moq;

namespace BestGuide.Modules.Application.UnitTest.Hotels.Commands
{
    [TestClass]
    public class PrepareHotelReportCommandHandlerTests
    {
        private PrepareHotelReportCommandHandler _testClass;
        private Mock<IHotelService> _hotelService;

        [TestInitialize]
        public void Setup() 
        { 
            _hotelService = new Mock<IHotelService>();
            _testClass = new PrepareHotelReportCommandHandler(_hotelService.Object);
        }

        [TestMethod]
        public void CanConstruct()
        {
            var instance = new PrepareHotelReportCommandHandler(_hotelService.Object);
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public async Task CanCallHandle()
        {
            var request = new PrepareHotelReportCommand();
            var cancellationToken = CancellationToken.None;
            _hotelService.Setup(s => s.PrepareReportAsync(It.IsAny<PrepareHotelReportArgs>(), It.IsAny<CancellationToken>()));
            await _testClass.Handle(request, cancellationToken);
        }
    }
}
