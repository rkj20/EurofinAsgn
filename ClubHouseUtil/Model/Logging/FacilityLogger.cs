namespace ClubHouseUtil.Model.Logging
{
    using ClubHouseUtil.Model.Logging.Handlers;
    using System;

    /// <summary>
    /// Logger implementation
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Model.Logging.IFacilityLogger" />
    internal class FacilityLogger : IFacilityLogger
    {
        /// <summary>
        /// The log writer instance
        /// </summary>
        private readonly ILogWriter _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacilityLogger"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public FacilityLogger(ILogWriter logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Information(string message)
        {
            Log(LogType.Info, message);
        }

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(string message)
        {
            Log(LogType.Warning, message);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            Log(LogType.Error, message);
        }

        /// <summary>
        /// Logs the specified log type and log message
        /// </summary>
        /// <param name="logType">Type of the log.</param>
        /// <param name="message">The message.</param>
        private void Log(LogType logType, string message)
        {
            var currentDateTime = DateTime.Now;
            var logMessage = new LogMessage(logType, message, currentDateTime);
            _logger.Write(logMessage);
        }
    }
}