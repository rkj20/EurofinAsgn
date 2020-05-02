namespace ClubHouseUtil.Model.Interfaces
{
    using System;

    /// <summary>
    /// Common interface for Facility
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Model.Interfaces.IFacilityMaintenance" />
    /// <seealso cref="ClubHouseUtil.Model.Interfaces.IFacilityBooking" />
    /// <seealso cref="ClubHouseUtil.Model.Interfaces.IFacilityTiming" />
    /// <seealso cref="ClubHouseUtil.Model.Interfaces.IFacilityLocking" />
    /// <seealso cref="ClubHouseUtil.Model.Interfaces.IFacilityAccess" />
    /// <seealso cref="System.IDisposable" />
    public interface IFacility : IFacilityMaintenance, IFacilityBooking, IFacilityTiming, IFacilityLocking, IFacilityAccess, IDisposable
    {
        /// <summary>
        /// Gets the facility identifier.
        /// </summary>
        /// <value>
        /// The facility identifier.
        /// </value>
        int FacilityId { get; }

        /// <summary>
        /// Gets the name of the facility.
        /// </summary>
        /// <value>
        /// The name of the facility.
        /// </value>
        string FacilityName { get; }
    }
}
