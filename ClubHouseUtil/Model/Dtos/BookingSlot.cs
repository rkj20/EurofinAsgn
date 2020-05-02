namespace ClubHouseUtil.Model.Dtos
{
    using System;

    /// <summary>
    /// Booking Slot details
    /// </summary>
    public class BookingSlot
    {
        /// <summary>
        /// Gets or sets the booking slot identifier.
        /// </summary>
        /// <value>
        /// The booking slot identifier.
        /// </value>
        public int BookingSlotId { get; set; }

        /// <summary>
        /// Gets or sets the slot length in minutes.
        /// </summary>
        /// <value>
        /// The slot length in minutes.
        /// </value>
        public int SlotLengthInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the slot start time.
        /// </summary>
        /// <value>
        /// The slot start time.
        /// </value>
        public DateTime SlotStartTime { get; set; }

        /// <summary>
        /// Gets or sets the maximum users per slot.
        /// </summary>
        /// <value>
        /// The maximum users per slot.
        /// </value>
        public int MaxUsersPerSlot { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [booking allowed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [booking allowed]; otherwise, <c>false</c>.
        /// </value>
        public bool BookingAllowed { get; set; }
    }
}
