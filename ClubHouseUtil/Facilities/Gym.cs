namespace ClubHouseUtil.Facilities
{
    using ClubHouseUtil.Model.Configurations;
    using ClubHouseUtil.Model.Dtos;
    using ClubHouseUtil.Model.Interfaces;
    using ClubHouseUtil.Model.Logging;

    /// <summary>
    /// Specific implementation of Gym Facility
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Facilities.FacilityBase" />
    public class Gym : FacilityBase
    {
        /// <summary>
        /// The logger instance
        /// </summary>
        private readonly IFacilityLogger _logger;

        /// <summary>
        /// Gets the Gym facility identifier.
        /// </summary>
        /// <value>
        /// The Gym facility identifier.
        /// </value>
        public override int FacilityId { get; }

        /// <summary>
        /// Gets the name of the Gym facility.
        /// </summary>
        /// <value>
        /// The name of the Gym facility.
        /// </value>
        public override string FacilityName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gym"/>  Facility.
        /// </summary>
        /// <param name="id">The Gym facility identifier.</param>
        /// <param name="name">The Facility name.</param>
        /// <param name="config">The Gym specific configuration.</param>
        /// <param name="logger">The logger instance.</param>
        public Gym(int id, string name, IFacilityConfiguration config, IFacilityLogger logger) : base(config, logger)
        {
            FacilityId = id;
            FacilityName = name;
            _logger = logger;
            _logger.Information("Gym Facility instance created");
        }

        public override IResposnse CreateBooking(BookingDetails booking)
        {
            // If maintenance is on particular equipment, users are still allowed to access.
            // If complete gym is under maintenance, users are not allowed.

            return base.CreateBooking(booking);
        }

        public override IResposnse CreateAccess(AccessDetails access)
        {
            // If maintenance is on particular equipment, users are still allowed to access.
            // If complete gym is under maintenance, users are not allowed.

            return base.CreateAccess(access);
        }
    }
}