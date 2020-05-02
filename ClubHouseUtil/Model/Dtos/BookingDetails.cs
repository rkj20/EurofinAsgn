namespace ClubHouseUtil.Model.Dtos
{
    /// <summary>
    /// Booking Details
    /// </summary>
    public class BookingDetails
    {
        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>
        /// The booking identifier.
        /// </value>
        public string BookingId { get; set; }

        /// <summary>
        /// Gets or sets the user details.
        /// </summary>
        /// <value>
        /// The user details.
        /// </value>
        public FacilityUser UserDetails { get; set; }

        /// <summary>
        /// Gets or sets the slot details.
        /// </summary>
        /// <value>
        /// The slot details.
        /// </value>
        public BookingSlot SlotDetails { get; set; }

        public BookingDetails()
        {
            UserDetails = new FacilityUser();
            SlotDetails = new BookingSlot();
        }
    }
}
