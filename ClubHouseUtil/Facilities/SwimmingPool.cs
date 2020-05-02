namespace ClubHouseUtil.Facilities
{
    using ClubHouseUtil.Model.Configurations;
    using ClubHouseUtil.Model.Dtos;
    using ClubHouseUtil.Model.Interfaces;
    using ClubHouseUtil.Model.Logging;

    /// <summary>
    /// Specific implementation of Swimming pool Facility
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Facilities.FacilityBase" />
    public class SwimmingPool : FacilityBase
    {
        /// <summary>
        /// The logger instance
        /// </summary>
        private readonly IFacilityLogger _logger;

        /// <summary>
        /// Gets the Swimming pool Facility identifier.
        /// </summary>
        /// <value>
        /// The Swimming pool Facility identifier.
        /// </value>
        public override int FacilityId { get; }

        /// <summary>
        /// Gets the name of the Swimming pool Facility.
        /// </summary>
        /// <value>
        /// The name of the Swimming pool Facility.
        /// </value>
        public override string FacilityName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwimmingPool"/> class.
        /// </summary>
        /// <param name="id">The Swimming pool Facility identifier.</param>
        /// <param name="name">The Swimming pool Facility name.</param>
        /// <param name="config">The Swimming pool Facility configuration.</param>
        /// <param name="logger">The logger instance.</param>
        public SwimmingPool(int id, string name, IFacilityConfiguration config, IFacilityLogger logger) : base(config, logger)
        {
            FacilityId = id;
            FacilityName = name;
            _logger = logger;
            _logger.Information("Swimming Pool Facility instance created");
        }

        public override IResposnse CreateBooking(BookingDetails booking)
        {
            // If maintenance is declared, complete swimming pool is inaccessible.

            return base.CreateBooking(booking);
        }

        public override IResposnse CreateAccess(AccessDetails access)
        {
            // If maintenance is declared, complete swimming pool is inaccessible.

            return base.CreateAccess(access);
        }
    }
}
