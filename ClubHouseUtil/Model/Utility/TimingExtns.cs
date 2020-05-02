namespace ClubHouseUtil.Model.Utility
{
    using ClubHouseUtil.Model.Dtos;
    using System;
    using System.Linq;

    /// <summary>
    /// Extension methods for timing
    /// </summary>
    public static class TimingExtns
    {
        /// <summary>
        /// Check if specified time falls in between any break time
        /// </summary>
        /// <param name="detail">The timing detail.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public static bool Exists(this TimingDetails detail, DateTime startTime, DateTime endTime)
        {
            return detail.Breaks.Any(x => x.Exists(startTime, endTime));
        }

        /// <summary>
        /// Check if specified time falls in between any break time
        /// </summary>
        /// <param name="detail">The timing detail.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public static bool Exists(this BreakTimeDetails detail, DateTime startTime, DateTime endTime)
        {
            return DateTime.Compare(detail.BreakStartTime, startTime) <= 0 &&
               DateTime.Compare(detail.BreakStartTime.AddMinutes(detail.BreakDurationInMinutes), endTime) >= 0;
        }

        /// <summary>
        /// Next the available slot start time.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="">The .</param>
        /// <returns></returns>
        public static DateTime NextAvailableSlotStartTime(this TimingDetails details, DateTime startTime, int slotDuration)
        {
            Start:
            startTime = startTime.AddMinutes(slotDuration);

            // Check if this slot time contradicts with any break timing
            if(details.Breaks.Any(x=> DateTime.Compare(x.BreakStartTime, startTime) <=0 && DateTime.Compare(x.BreakStartTime.AddMinutes(x.BreakDurationInMinutes), startTime) >=0))
            {
                goto Start;
            }
            return startTime;
        }
    }
}
