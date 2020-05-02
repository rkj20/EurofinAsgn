namespace ClubHouseUtil.Model.Utility
{
    using ClubHouseUtil.Model.Dtos;
    using System;

    /// <summary>
    /// Booking Extension methods
    /// </summary>
    public static class BookingExtns
    {
        /// <summary>
        /// Exists the specified start time.
        /// </summary>
        /// <param name="detail">The detail.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public static bool Exists(this BookingDetails detail, DateTime startTime, DateTime endTime)
        {
            return DateTime.Compare(detail.SlotDetails.SlotStartTime, startTime) >= 0 &&
               DateTime.Compare(detail.SlotDetails.SlotStartTime.AddMinutes(detail.SlotDetails.SlotLengthInMinutes), endTime) <= 0;
        }

        /// <summary>
        /// Determines whether [is continuous booking] [the specified new detail].
        /// </summary>
        /// <param name="detail">The detail.</param>
        /// <param name="newDetail">The new detail.</param>
        /// <returns>
        ///   <c>true</c> if [is continuous booking] [the specified new detail]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsContinuousBooking(this BookingDetails detail, BookingDetails newDetail)
        {
            // Check if the booking is prior slot and booked by specific user
            return DateTime.Compare(detail.SlotDetails.SlotStartTime.AddMinutes(detail.SlotDetails.SlotLengthInMinutes), newDetail.SlotDetails.SlotStartTime) == 0 &&
                DateTime.Compare(detail.SlotDetails.SlotStartTime, newDetail.SlotDetails.SlotStartTime.AddMinutes(newDetail.SlotDetails.SlotLengthInMinutes)) == 0 &&
                detail.UserDetails.UserId == newDetail.UserDetails.UserId;
        }        
    }
}