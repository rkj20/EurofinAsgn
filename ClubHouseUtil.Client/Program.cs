namespace ClubHouseUtil.Client
{
    using ClubHouseUtil.Api;
    using ClubHouseUtil.Model.Enums;
    using ClubHouseUtil.Model.Interfaces;
    using System;

    public static class Program
    {
        public static void Main()
        {
            IFacility libFacility = ClubHouseFacilityApi.GetKidsPlayAreaFacility;
            var res = libFacility.CreateBooking(DataGen.CreateBooking());
            Console.WriteLine($"Is Success - {res.Success}");
            Console.WriteLine(res.ResponseMessage);

            var mt = DataGen.CreateMaintenance();
            var mainRes = libFacility.CreateMaintenance(mt);
            Console.WriteLine($"Is Success - {mainRes.Success}");
            Console.WriteLine(mainRes.ResponseMessage);

            // For on demand Maintenance gives a warning but allowed to add maintenance
            mt.MaintenanceType = MaintenanceType.OnDemand;
            mainRes = libFacility.CreateMaintenance(mt);
            Console.WriteLine($"Is Success - {mainRes.Success}");
            Console.WriteLine(mainRes.ResponseMessage);

            // Lock the facility
            var lockRes = libFacility.CreateLocking(DataGen.CreateLocking());
            Console.WriteLine($"Is Success - {lockRes.Success}");
            Console.WriteLine(lockRes.ResponseMessage);

            // All bookings canceled 
            var accRes = libFacility.CreateAccess(DataGen.CreateAccess());
            Console.WriteLine($"Is Success - {accRes.Success}");
            Console.WriteLine(accRes.ResponseMessage);

            Console.ReadLine();
        }
    }
}
