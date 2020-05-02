using ClubHouseUtil.Model.Dtos;

namespace ClubHouseUtil.Client
{
    public static class DataGen
    {
        public static BookingDetails CreateBooking() =>
            new BookingDetails
            {
                BookingId = string.Empty,
                UserDetails = new FacilityUser { UserId = 1234, UserName ="Mr X", MobileNumber = "9869668966", Address = "Flat23"  }
            };
    }
}
