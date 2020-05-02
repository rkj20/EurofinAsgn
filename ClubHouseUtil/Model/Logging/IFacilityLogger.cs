namespace ClubHouseUtil.Model.Logging
{
    /// <summary>
    /// Interface for logger
    /// </summary>
    public interface IFacilityLogger
    {
        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Information(string message);

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warning(string message);

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);
    }
}
