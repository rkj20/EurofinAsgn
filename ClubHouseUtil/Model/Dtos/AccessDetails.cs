namespace ClubHouseUtil.Model.Dtos
{
    using System;

    /// <summary>
    /// Accessing the facility
    /// </summary>
    public class AccessDetails
    {
        /// <summary>
        /// Gets or sets the facility user.
        /// </summary>
        /// <value>
        /// The facility user.
        /// </value>
        public FacilityUser User { get; set; }

        /// <summary>
        /// Gets or sets the check in time.
        /// </summary>
        /// <value>
        /// The check in time.
        /// </value>
        public DateTime CheckinTime { get; set; }

        /// <summary>
        /// Gets or sets the check out time.
        /// </summary>
        /// <value>
        /// The check out time.
        /// </value>
        public DateTime CheckOutTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked in.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is checked in; otherwise, <c>false</c>.
        /// </value>
        public bool IsCheckedIn { get; set; }

        public AccessDetails()
        {
            User = new FacilityUser();
        }
    }
}
