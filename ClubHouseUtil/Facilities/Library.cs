namespace ClubHouseUtil.Facilities
{
    using ClubHouseUtil.Model.Configurations;
    using ClubHouseUtil.Model.Dtos;
    using ClubHouseUtil.Model.Interfaces;
    using ClubHouseUtil.Model.Logging;
    using System.Collections.Generic;

    /// <summary>
    /// Specific implementation of Library Facility
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Facilities.FacilityBase" />
    public class Library : FacilityBase
    {
        /// <summary>
        /// The Library Facility configuration
        /// </summary>
        private readonly IFacilityConfiguration _config;

        /// <summary>
        /// The logger instance
        /// </summary>
        private readonly IFacilityLogger _logger;

        /// <summary>
        /// Gets the Library Facility identifier.
        /// </summary>
        /// <value>
        /// The Library Facility identifier.
        /// </value>
        public override int FacilityId { get; }

        /// <summary>
        /// Gets the name of the Library Facility.
        /// </summary>
        /// <value>
        /// The name of the Library Facility.
        /// </value>
        public override string FacilityName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Library"/> class.
        /// </summary>
        /// <param name="id">The Library Facility identifier.</param>
        /// <param name="name">The Library Facility name.</param>
        /// <param name="config">The Library Facility configuration.</param>
        /// <param name="logger">The logger instance.</param>
        public Library(int id, string name, IFacilityConfiguration config, IFacilityLogger logger) : base(config, logger)
        {
            FacilityId = id;
            FacilityName = name;
            _config = config;
            _logger = logger;
            _logger.Information("Library Facility instance created");
        }

        /// <summary>
        /// Override default Booking behavior to Library specific behavior.
        /// </summary>
        /// <param name="Booking">The booking.</param>
        /// <returns></returns>
        public override IResposnse CreateBooking(BookingDetails Booking)
        {
            return new Resposnse(false, "Booking not allowed for this Facility");
        }

        /// <summary>
        /// Override default Booking behavior to Library specific behavior.
        /// </summary>
        /// <returns></returns>
        public override List<BookingDetails> ReadAllBooking()
        {
            return null;
        }

        /// <summary>
        /// Override default Booking behavior to Library specific behavior.
        /// </summary>
        /// <param name="BookingId">The booking identifier.</param>
        /// <returns></returns>
        public override BookingDetails ReadBooking(string bookingId)
        {
            return null;
        }

        /// <summary>
        /// Override default Booking behavior to Library specific behavior
        /// </summary>
        /// <param name="Booking">The booking.</param>
        /// <returns></returns>
        public override IResposnse UpdateBooking(BookingDetails Booking)
        {
            return new Resposnse(false, "Booking not allowed for this Facility");
        }

        /// <summary>
        /// Override default Booking behavior to Library specific behavior
        /// </summary>
        /// <param name="Booking">The booking.</param>
        /// <returns></returns>
        public override IResposnse DeleteBooking(BookingDetails Booking)
        {
            return new Resposnse(false, "Booking not allowed for this Facility");
        }

        public override IResposnse CreateAccess(AccessDetails access)
        {
            // We only ensure that total number of users consuming the library is within
            // the max user limit at any given point
            if(usersAccessingFacilityList.Count <= _config.LibraryMaxUserLimit)
                return new Resposnse(false, "Max Users already sing the facility");
            return base.CreateAccess(access);
        }
    }
}
