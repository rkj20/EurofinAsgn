namespace ClubHouseUtil.Model.Configurations
{
    using ClubHouseUtil.Model.Logging;
    using System;
    using System.Configuration;

    /// <summary>
    /// Configuration implementation
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Model.Configurations.IFacilityConfiguration" />
    internal class FacilityConfiguration : IFacilityConfiguration
    {
        /// <summary>
        /// The logger instance
        /// </summary>
        private readonly IFacilityLogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacilityConfiguration"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public FacilityConfiguration(IFacilityLogger logger)
        {
            _logger = logger;
            Configuration config = null;
            string exeConfigPath = this.GetType().Assembly.Location;
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
            }
            catch (Exception ex)
            {
                _logger.Error("No configuration file");
                _logger.Error(ex.Message);
            }

            if (config != null)
            {
                LibraryMaxUserLimit = Convert.ToInt32(GetAppSetting(config, "LibraryMaxUserLimit"));
                SlotLengthInMinutes = Convert.ToInt32(GetAppSetting(config, "SlotLengthInMinutes"));
                PercentageAllowed = Convert.ToInt32(GetAppSetting(config, "PercentageAllowed"));
            }
        }

        /// <summary>
        /// Gets the library maximum user limit.
        /// </summary>
        /// <value>
        /// The library maximum user limit.
        /// </value>
        public int LibraryMaxUserLimit { get; }

        public int SlotLengthInMinutes { get; }

        public int PercentageAllowed { get; }

        /// <summary>
        /// Gets the application setting.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Configuration value is not available</exception>
        private string GetAppSetting(Configuration config, string key)
        {
            KeyValueConfigurationElement element = config.AppSettings.Settings[key];
            if (element == null)
            {
                throw new Exception("Configuration value is not available");
            }
            string value = element.Value;
            if (!string.IsNullOrEmpty(value))
                return value;
            return string.Empty;
        }
    }
}