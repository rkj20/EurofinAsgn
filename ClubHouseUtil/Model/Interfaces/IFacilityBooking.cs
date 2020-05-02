namespace ClubHouseUtil.Model.Interfaces
{
    using ClubHouseUtil.Model.Dtos;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for Facility Booking
    /// </summary>
    public interface IFacilityBooking
    {
        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="Booking">The booking.</param>
        /// <returns></returns>
        IResposnse CreateBooking(BookingDetails Booking);

        /// <summary>
        /// Reads all booking.
        /// </summary>
        /// <returns></returns>
        List<BookingDetails> ReadAllBooking();

        /// <summary>
        /// Reads the booking.
        /// </summary>
        /// <param name="BookingId">The booking identifier.</param>
        /// <returns></returns>
        BookingDetails ReadBooking(string bookingId);

        /// <summary>
        /// Updates the booking.
        /// </summary>
        /// <param name="Booking">The booking.</param>
        /// <returns></returns>
        IResposnse UpdateBooking(BookingDetails Booking);

        /// <summary>
        /// Deletes the booking.
        /// </summary>
        /// <param name="Booking">The booking.</param>
        /// <returns></returns>
        IResposnse DeleteBooking(BookingDetails Booking);
    }
}