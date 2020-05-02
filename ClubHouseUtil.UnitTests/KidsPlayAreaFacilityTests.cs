namespace ClubHouseUtil.UnitTests
{
    using ClubHouseUtil.Facilities;
    using ClubHouseUtil.Model.Configurations;
    using ClubHouseUtil.Model.Constants;
    using ClubHouseUtil.Model.Logging;
    using NSubstitute;
    using Xunit;

    public class KidsPlayAreaFacilityTests
    {
        [Fact]
        public void CreateNewBookingNotAllowedForKidsPlayArea()
        {
            // Arrange
            var logger = Substitute.For<IFacilityLogger>();
            var config = Substitute.For<IFacilityConfiguration>();
            var kidsPlayAreaFacility = new KidsPlayArea(FacilityID.KIDSPLAYAREA, FacilityName.KIDSPLAYAREA, config, logger);

            // Act
            var result = kidsPlayAreaFacility.CreateBooking(DataGen.CreateBooking());

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Booking not allowed for this Facility", result.ResponseMessage);
        }

        [Fact]
        public void ReadAllBookingNotAllowedForKidsPlayArea()
        {
            // Arrange
            var logger = Substitute.For<IFacilityLogger>();
            var config = Substitute.For<IFacilityConfiguration>();
            var kidsPlayAreaFacility = new KidsPlayArea(FacilityID.KIDSPLAYAREA, FacilityName.KIDSPLAYAREA, config, logger);

            // Act
            var result = kidsPlayAreaFacility.ReadAllBooking();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ReadBookingNotAllowedForKidsPlayArea()
        {
            // Arrange
            var logger = Substitute.For<IFacilityLogger>();
            var config = Substitute.For<IFacilityConfiguration>();
            var kidsPlayAreaFacility = new KidsPlayArea(FacilityID.KIDSPLAYAREA, FacilityName.KIDSPLAYAREA, config, logger);

            // Act
            var result = kidsPlayAreaFacility.ReadBooking("Test1");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void UpdateBookingNotAllowedForKidsPlayArea()
        {
            // Arrange
            var logger = Substitute.For<IFacilityLogger>();
            var config = Substitute.For<IFacilityConfiguration>();
            var kidsPlayAreaFacility = new KidsPlayArea(FacilityID.KIDSPLAYAREA, FacilityName.KIDSPLAYAREA, config, logger);

            // Act
            var result = kidsPlayAreaFacility.UpdateBooking(DataGen.CreateBooking());

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Booking not allowed for this Facility", result.ResponseMessage);
        }
    }
}
