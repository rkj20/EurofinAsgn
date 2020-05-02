namespace ClubHouseUtil.Model.Logging.Formatters
{
    /// <summary>
    /// Default formatter for log messages
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Model.Logging.Formatters.IFormatter" />
    internal class DefaultFormatter : IFormatter
    {
        /// <summary>
        /// Formats the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <returns>Formatted message</returns>
        public string Format(LogMessage logMessage)
        {
            return string.Format("{0:dd.MM.yyyy HH:mm:ss}: {1} : {2}",
                            logMessage.DateTime,
                            logMessage.logType,
                            logMessage.Text);
        }
    }
}