namespace ClubHouseUtil.Api
{
    using ClubHouseUtil.Model.Constants;
    using ClubHouseUtil.Model.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public static class ClubHouseFacilityApi
    {
        /// <summary>
        /// Gets all available Facilities.
        /// </summary>
        /// <returns>List of available Facilities</returns>
        public static List<IFacility> GetAllFacilities => ClubHouseFacility.GetInstance().Facilities;

        /// <summary>
        /// Gets the get gym facility.
        /// </summary>
        /// <value>
        /// The get gym facility.
        /// </value>
        public static IFacility GetGymFacility => ClubHouseFacility.GetInstance().Facilities.First(x => x.FacilityId == FacilityID.GYM && x.FacilityName == FacilityName.GYM);

        /// <summary>
        /// Gets the get kids play area facility.
        /// </summary>
        /// <value>
        /// The get kids play area facility.
        /// </value>
        public static IFacility GetKidsPlayAreaFacility => ClubHouseFacility.GetInstance().Facilities.First(x => x.FacilityId == FacilityID.KIDSPLAYAREA && x.FacilityName == FacilityName.KIDSPLAYAREA);

        /// <summary>
        /// Gets the get library facility.
        /// </summary>
        /// <value>
        /// The get library facility.
        /// </value>
        public static IFacility GetLibraryFacility => ClubHouseFacility.GetInstance().Facilities.First(x => x.FacilityId == FacilityID.LIBRARY && x.FacilityName == FacilityName.LIBRARY);

        /// <summary>
        /// Gets the get swimming pool facility.
        /// </summary>
        /// <value>
        /// The get swimming pool facility.
        /// </value>
        public static IFacility GetSwimmingPoolFacility => ClubHouseFacility.GetInstance().Facilities.First(x => x.FacilityId == FacilityID.SWIMMINGPOOL && x.FacilityName == FacilityName.SWIMMINGPOOL);
    }
}