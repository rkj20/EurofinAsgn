namespace ClubHouseUtil.Client
{
    using ClubHouseUtil.Api;
    using ClubHouseUtil.Model.Interfaces;
    using System;

    public static class Program
    {
        public static void Main()
        {
            IFacility libFacility = ClubHouseFacilityApi.GetKidsPlayAreaFacility;
            var res = libFacility.CreateBooking(DataGen.CreateBooking());
            Console.WriteLine(res.Success);
            Console.WriteLine(res.ResponseMessage);

            Console.ReadLine();
        }
    }
}
