namespace ClubHouseUtil.Model.Utility
{
    using ClubHouseUtil.Model.Dtos;
    using System;

    /// <summary>
    /// Extension Methods for Locking Period
    /// </summary>
    public static class LockingPeriodExtns
    {
        /// <summary>
        /// Check if specified new details Exists
        /// </summary>
        /// <param name="detail">The details.</param>
        /// <param name="newDetails">The new details.</param>
        /// <returns></returns>
        public static bool Exists(this LockingDetails detail, LockingDetails newDetail)
        {
            return DateTime.Compare(detail.LockStartTime, newDetail.LockStartTime) <= 0 &&
               DateTime.Compare(detail.LockEndTime, newDetail.LockEndTime) >= 0;
        }

        /// <summary>
        /// Check if Facility is Locked for the specified start time and EndTime
        /// </summary>
        /// <param name="detail">The detail.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public static bool Exists(this LockingDetails detail, DateTime startTime, DateTime endTime)
        {
            return DateTime.Compare(detail.LockStartTime, startTime) <= 0 && DateTime.Compare(detail.LockEndTime, endTime) >= 0;
        }

        /// <summary>
        /// Check if any Lockings exists now.
        /// </summary>
        /// <param name="detail">The detail.</param>
        /// <param name="now">The now.</param>
        /// <returns></returns>
        public static bool LockingExistsNow(this LockingDetails detail, DateTime now)
        {
            return DateTime.Compare(detail.LockStartTime, now) == 0;
        }
    }
}
