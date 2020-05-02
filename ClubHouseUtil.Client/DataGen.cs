using ClubHouseUtil.Model.Dtos;
using ClubHouseUtil.Model.Enums;
using System;

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

        public static MaintenanceDetails CreateMaintenance() =>
           new MaintenanceDetails
           {
               MaintenanceId = string.Empty,
               StartTime = new DateTime(2020,05,02,11,10,00),
               EndTime = new DateTime(2020, 05, 02, 12, 10, 00),
               RecurringFrequency = MaintenanceFrequency.Monthly,
               NoOfRecurrence = 3,
               MaintenanceType = MaintenanceType.Predefined,
               MaintenanceRange = MaintenanceRange.Complete,
               MaintenancePercentage = 60
           };

        public static LockingDetails CreateLocking() =>
          new LockingDetails
          {
              LockingId = string.Empty,
              LockStartTime = new DateTime(2020, 05, 02, 11, 10, 00),
              LockEndTime = new DateTime(2020, 05, 03, 12, 10, 00)
          };

        public static AccessDetails CreateAccess() =>
          new AccessDetails
          {
              User = new FacilityUser { UserId = 1234, UserName = "Mr Y", MobileNumber = "9876543298", Address = "Flat720"},
              CheckinTime = new DateTime(2020, 05, 02, 11, 35, 00),
              CheckOutTime = new DateTime(2020, 05, 02, 12, 10, 00)
          };
    }
}
