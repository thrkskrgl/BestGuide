using BestGuide.Modules.Areas.Hotel.Models.Responses;
using BestGuide.Modules.Areas.HotelContact.Models.Responses;
using FluentAssertions;

namespace BestGuide.Modules.UnitTest.Areas.Hotel.Models.Responses
{
    [TestClass]
    public class HotelResponseTests
    {
        [TestMethod]
        public void HotelResponse_SetAndGetCorrectly()
        {
            // Arrange
            var id = Guid.NewGuid();
            var createdOn = DateTime.UtcNow;
            var contacts = new HashSet<HotelContactResponse>
            {
                new() { Type = Domain.Enums.HotelContactType.Telephone, Content = "123456789" }
            };
    
            // Act
            var hotelResponse = new HotelResponse
            {
                Id = id,
                AuthorizedName = "TestValue",
                AuthorizedSurname = "TestValue",
                Title = "TestValue",
                CreatedBy = "TestValue",
                CreatedOn = createdOn,
                Contacts = contacts
            };
    
            // Assert
            hotelResponse.Id.Should().Be(id);
            hotelResponse.AuthorizedName.Should().Be("TestValue");
            hotelResponse.AuthorizedSurname.Should().Be("TestValue");
            hotelResponse.Title.Should().Be("TestValue");
            hotelResponse.CreatedBy.Should().Be("TestValue");
            hotelResponse.CreatedOn.Should().Be(createdOn);
            hotelResponse.Contacts.Should().BeEquivalentTo(contacts);
        }
    
        [TestMethod]
        public void HotelResponseContacts_ReturnsEmpty()
        {
            // Act
            var hotelResponse = new HotelResponse() { Title = "TestValue" };
    
            // Assert
            hotelResponse.Contacts.Should().BeEmpty();
        }
    }
}
