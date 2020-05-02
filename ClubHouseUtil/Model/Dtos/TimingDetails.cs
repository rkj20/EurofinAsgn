namespace ClubHouseUtil.Model.Dtos
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Facility open/close timings
    /// </summary>
    public class TimingDetails
    {

        /// <summary>
        /// Gets or sets the open time.
        /// </summary>
        /// <value>
        /// The open time.
        /// </value>
        public DateTime OpenTime { get; set; }

        /// <summary>
        /// Gets or sets the close time.
        /// </summary>
        /// <value>
        /// The close time.
        /// </value>
        public DateTime CloseTime { get; set; }

        /// <summary>
        /// Gets or sets the breaks.
        /// </summary>
        /// <value>
        /// The breaks.
        /// </value>
        public List<BreakTimeDetails> Breaks { get; set; }

        /// <summary>
        /// Gets or sets the slots.
        /// </summary>
        /// <value>
        /// The slots.
        /// </value>
        public List<BookingSlot> Slots { get; set; }

        public TimingDetails()
        {
            Breaks = new List<BreakTimeDetails>();
            Slots = new List<BookingSlot>();
        }
    }
}
