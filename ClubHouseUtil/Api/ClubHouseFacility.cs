namespace ClubHouseUtil.Api
{
    using ClubHouseUtil.Facilities;
    using ClubHouseUtil.Model.Configurations;
    using ClubHouseUtil.Model.Constants;
    using ClubHouseUtil.Model.Interfaces;
    using ClubHouseUtil.Model.Logging;
    using System;
    using System.Collections.Generic;

    internal sealed class ClubHouseFacility : IDisposable
    {
        /// <summary>
        /// The lazy initialization of <see cref="ClubHouseFacility" /> instance.
        /// </summary>
        private static readonly Lazy<ClubHouseFacility> lazy = new Lazy<ClubHouseFacility>(() => new ClubHouseFacility());

        /// <summary>
        /// Prevents a default instance of the <see cref="ClubHouseFacility" /> class from being created.
        /// Builds available Facility list
        /// </summary>
        private ClubHouseFacility()
        {
            var logger = LogFactory.GetInstance;
            var config = ConfigurationFactory.GetInstance;

            Facilities = new List<IFacility>
            {
                new KidsPlayArea(FacilityID.KIDSPLAYAREA, FacilityName.KIDSPLAYAREA, config, logger),
                new SwimmingPool(FacilityID.SWIMMINGPOOL, FacilityName.SWIMMINGPOOL, config, logger),
                new Gym(FacilityID.GYM, FacilityName.GYM, config, logger),
                new Library(FacilityID.LIBRARY, FacilityName.LIBRARY, config, logger)
            };
        }

        /// <summary>
        /// Gets the instance of <see cref="ClubHouseFacility" />
        /// </summary>
        /// <returns>List of available Facilities</returns>
        public static ClubHouseFacility GetInstance() => lazy.Value;

        /// <summary>
        /// Gets the facilities.
        /// </summary>
        /// <value>List of available Facilities</value>
        public List<IFacility> Facilities { get; }

        /// <summary>
        /// Cleanups this instance and unmanaged resources
        /// </summary>
        public void Dispose()
        {
            Facilities.ForEach(x => x.Dispose());
        }
    }
}