using ClubHouseUtil.Model.Dtos;
using System.Collections.Generic;

namespace ClubHouseUtil.Model.Interfaces
{
    /// <summary>
    /// Interface for Facility Timing
    /// </summary>
    public interface IFacilityTiming
    {
        /// <summary>
        /// Creates the timing.
        /// </summary>
        /// <param name="timing">The timing.</param>
        /// <returns></returns>
        IResposnse CreateTiming(TimingDetails timing);

        /// <summary>
        /// Reads all timings.
        /// </summary>
        /// <returns></returns>
        List<TimingDetails> ReadAllTimings();

        /// <summary>
        /// Updates the timing.
        /// </summary>
        /// <param name="timing">The timing.</param>
        /// <returns></returns>
        IResposnse UpdateTiming(TimingDetails timing);

        /// <summary>
        /// Deletes the timing.
        /// </summary>
        /// <param name="timing">The timing.</param>
        /// <returns></returns>
        IResposnse DeleteTiming(TimingDetails timing);
    }
}