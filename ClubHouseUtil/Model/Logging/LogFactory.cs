using ClubHouseUtil.Model.Logging.Handlers;

namespace ClubHouseUtil.Model.Logging
{
    /// <summary>
    /// Factory to get Logger instance
    /// </summary>
    public class LogFactory
    {
        /// <summary>
        /// The logger instance
        /// </summary>
        private static IFacilityLogger _logger;

        /// <summary>
        /// Prevents a default instance of the <see cref="LogFactory"/> class from being created.
        /// </summary>
        private LogFactory() { }

        /// <summary>
        /// Gets the get logger instance.
        /// </summary>
        /// <value>
        /// The get logger instance.
        /// </value>
        public static IFacilityLogger GetInstance => _logger ?? (_logger = new FacilityLogger(new FileLogger()));
    }
}
