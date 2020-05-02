namespace ClubHouseUtil.Model.Dtos
{
    using System;

    /// <summary>
    /// Locking of the facility details
    /// </summary>
    public class LockingDetails
    {
        /// <summary>
        /// Gets or sets the locking identifier.
        /// </summary>
        /// <value>
        /// The locking identifier.
        /// </value>
        public string LockingId { get; set; }

        /// <summary>
        /// Gets or sets the lock start time.
        /// </summary>
        /// <value>
        /// The lock start time.
        /// </value>
        public DateTime LockStartTime { get; set; }

        /// <summary>
        /// Gets or sets the lock end time.
        /// </summary>
        /// <value>
        /// The lock end time.
        /// </value>
        public DateTime LockEndTime { get; set; }
    }
}
