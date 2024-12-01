using BestGuide.Modules.Areas.HotelContact.Models.Responses;
using FluentAssertions;

namespace BestGuide.Modules.UnitTest.Areas.Hotel.Models.Responses
{
    [TestClass]
    public class HotelContactResponseTests
    {
        [TestMethod]
        public void HotelResponse_SetAndGetCorrectly()
        {
            // Arrange
            var id = 1234;
            var createdOn = DateTime.UtcNow;
    
            // Act
            var hotelResponse = new HotelContactResponse
            {
                Id = id,
                Content = "TestValue",
                Type = default,
            };
    
            // Assert
            hotelResponse.Id.Should().Be(id);
            hotelResponse.Content.Should().Be("TestValue");
            hotelResponse.Type.Should().Be(default);
        }
    }
}
