namespace ClubHouseUtil.Model.Logging.Formatters
{
    /// <summary>
    /// Interface for Formatter
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Formats the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <returns></returns>
        string Format(LogMessage logMessage);
    }
}