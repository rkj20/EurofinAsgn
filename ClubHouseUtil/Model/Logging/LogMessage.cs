namespace ClubHouseUtil.Model.Logging
{
    using System;

    /// <summary>
    /// Log message format
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogMessage"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="text">The text.</param>
        /// <param name="dateTime">The date time.</param>
        public LogMessage(LogType type, string text, DateTime dateTime)
        {
            logType = type;
            Text = text;
            DateTime = dateTime;
        }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the type of the log.
        /// </summary>
        /// <value>
        /// The type of the log.
        /// </value>
        public LogType logType { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }
    }
}