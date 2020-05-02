namespace ClubHouseUtil.Model.Configurations
{
    /// <summary>
    /// Configuration interface
    /// </summary>
    public interface IFacilityConfiguration
    {
        /// <summary>
        /// Gets the library maximum user limit.
        /// </summary>
        /// <value>
        /// The library maximum user limit.
        /// </value>
        int LibraryMaxUserLimit { get; }

        /// <summary>
        /// Gets the slot length in minutes.
        /// </summary>
        /// <value>
        /// The slot length in minutes.
        /// </value>
        int SlotLengthInMinutes { get; }

        /// <summary>
        /// Gets the percentage allowed.
        /// </summary>
        /// <value>
        /// The percentage allowed.
        /// </value>
        int PercentageAllowed { get; }
    }
}
