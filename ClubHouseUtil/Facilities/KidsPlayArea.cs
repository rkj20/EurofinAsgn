namespace ClubHouseUtil.Facilities
{
    using ClubHouseUtil.Model.Configurations;
    using ClubHouseUtil.Model.Dtos;
    using ClubHouseUtil.Model.Interfaces;
    using ClubHouseUtil.Model.Logging;
    using System.Collections.Generic;

    /// <summary>
    /// Specific implementation of Kids Play Area Facility
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Facilities.FacilityBase" />
    public class KidsPlayArea : FacilityBase
    {
        /// <summary>
        /// The logger instance
        /// </summary>
        private readonly IFacilityLogger _logger;

        /// <summary>
        /// Gets the Kids Play Area facility identifier.
        /// </summary>
        /// <value>
        /// The Kids Play Area facility identifier.
        /// </value>
        public override int FacilityId { get; }

        /// <summary>
        /// Gets the name of the Kids Play Area facility.
        /// </summary>
        /// <value>
        /// The name of the Kids Play Area facility.
        /// </value>
        public override string FacilityName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KidsPlayArea"/> class.
        /// </summary>
        /// <param name="id">The Kids Play Area Facility identifier.</param>
        /// <param name="name">The Kids Play Area Facility name.</param>
        /// <param name="config">The Kids Play Area configuration.</param>
        /// <param name="logger">The logger instance.</param>
        public KidsPlayArea(int id, string name, IFacilityConfiguration config, IFacilityLogger logger) : base(config, logger)
        {
            FacilityId = id;
            FacilityName = name;
            _logger = logger;
            _logger.Information("Kids PlayArea Facility instance created");
        }

        /// <summary>
        /// Override default Booking behavior to Kids Play Area specific behavior.
        /// </summary>
        /// <param name="Booking">The booking.</param>
        /// <returns></returns>
        public override IResposnse CreateBooking(BookingDetails Booking)
        {
            return new Resposnse(false, "Booking not allowed for this Facility");
        }

        /// <summary>
        /// Override default Booking behavior to Kids Play Area specific behavior.
        /// </summary>
        /// <returns></returns>
        public override List<BookingDetails> ReadAllBooking()
        {
            return null;
        }

        /// <summary>
        /// Override default Booking behavior to Kids Play Area specific behavior.
        /// </summary>
        /// <param name="BookingId">The booking identifier.</param>
        /// <returns></returns>
        public override BookingDetails ReadBooking(string bookingId)
        {
            return null;
        }

        /// <summary>
        /// Override default Booking behavior to Kids Play Area specific behavior
        /// </summary>
        /// <param name="Booking">The booking.</param>
        /// <returns></returns>
        public override IResposnse UpdateBooking(BookingDetails Booking)
        {
            return new Resposnse(false, "Booking not allowed for this Facility");
        }

        /// <summary>
        /// Override default Booking behavior to Kids Play Area specific behavior
        /// </summary>
        /// <param name="Booking">The booking.</param>
        /// <returns></returns>
        public override IResposnse DeleteBooking(BookingDetails Booking)
        {
            return new Resposnse(false, "Booking not allowed for this Facility");
        }        

        public override IResposnse CreateAccess(AccessDetails access)
        {
            return base.CreateAccess(access);
        }
    }
}