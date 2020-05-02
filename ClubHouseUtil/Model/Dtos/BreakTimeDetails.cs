using System;

namespace ClubHouseUtil.Model.Dtos
{
    /// <summary>
    /// BreakTime details for the facility
    /// </summary>
    public class BreakTimeDetails
    {
        /// <summary>
        /// Gets or sets the break identifier.
        /// </summary>
        /// <value>
        /// The break identifier.
        /// </value>
        public int BreakId { get; set; }

        /// <summary>
        /// Gets or sets the name of the break.
        /// </summary>
        /// <value>
        /// The name of the break.
        /// </value>
        public string BreakName { get; set; }

        /// <summary>
        /// Gets or sets the break start time.
        /// </summary>
        /// <value>
        /// The break start time.
        /// </value>
        public DateTime BreakStartTime { get; set; }

        /// <summary>
        /// Gets or sets the break duration in minutes.
        /// </summary>
        /// <value>
        /// The break duration in minutes.
        /// </value>
        public int BreakDurationInMinutes { get; set; }
    }
}
