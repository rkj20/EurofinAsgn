namespace ClubHouseUtil.Model.Configurations
{
    using ClubHouseUtil.Model.Logging;

    /// <summary>
    /// Configuration Factory
    /// </summary>
    public sealed class ConfigurationFactory
    {
        /// <summary>
        /// The configuration instance
        /// </summary>
        private static IFacilityConfiguration _config;

        /// <summary>
        /// Prevents a default instance of the <see cref="ConfigurationFactory"/> class from being created.
        /// </summary>
        private ConfigurationFactory() { }

        /// <summary>
        /// Gets the Configuration instance.
        /// </summary>
        /// <value>
        /// The Configuration instance.
        /// </value>
        public static IFacilityConfiguration GetInstance => _config ?? (_config = new FacilityConfiguration(LogFactory.GetInstance));
    }
}
