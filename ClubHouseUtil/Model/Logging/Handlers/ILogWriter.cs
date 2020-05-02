namespace ClubHouseUtil.Model.Logging.Handlers
{
    /// <summary>
    /// Interface for writer
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>
        /// Writes the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        void Write(LogMessage logMessage);
    }
}