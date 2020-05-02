namespace ClubHouseUtil.Model.Utility
{
    using ClubHouseUtil.Model.Dtos;
    using ClubHouseUtil.Model.Enums;
    using System;

    /// <summary>
    /// Extension methods for Maintenance details
    /// </summary>
    internal static class MaintenanceExtns
    {
        /// <summary>
        /// Matches the specified new maintenance detail.
        /// </summary>
        /// <param name="detail">The current maintenance detail.</param>
        /// <param name="newDetail">The new maintenance detail.</param>
        /// <returns></returns>
        public static bool Exists(this MaintenanceDetails detail, MaintenanceDetails newDetail)
        {
            return DateTime.Compare(detail.StartTime, newDetail.StartTime) >= 0 &&
               DateTime.Compare(detail.EndTime, newDetail.StartTime) <= 0 && detail.MaintenanceType != MaintenanceType.OnDemand ;
        }

        /// <summary>
        /// Check if Maintenance Exists for the specified start time and EndTime
        /// </summary>
        /// <param name="detail">The detail.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public static bool Exists(this MaintenanceDetails detail, DateTime startTime, DateTime endTime)
        {
            return DateTime.Compare(detail.StartTime, startTime) >= 0 && DateTime.Compare(detail.EndTime, endTime) <= 0 ;
        }

        public static bool MaintenanceExistsNow(this MaintenanceDetails detail, DateTime now)
        {
            return DateTime.Compare(detail.StartTime, now) == 0;
        }
    }
}
