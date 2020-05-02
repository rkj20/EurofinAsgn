namespace ClubHouseUtil.Model.Dtos
{
    using ClubHouseUtil.Model.Enums;
    using System;

    /// <summary>
    /// Facility maintenance details
    /// </summary>
    public class MaintenanceDetails
    {
        /// <summary>
        /// Gets or sets the maintenance identifier.
        /// </summary>
        /// <value>
        /// The maintenance identifier.
        /// </value>
        public string MaintenanceId { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the recurring frequency.
        /// </summary>
        /// <value>
        /// The recurring frequency.
        /// </value>
        public MaintenanceFrequency RecurringFrequency { get; set; }

        /// <summary>
        /// Gets or sets the no of recurrence.
        /// </summary>
        /// <value>
        /// The no of recurrence.
        /// </value>
        public int NoOfRecurrence { get; set; }

        /// <summary>
        /// Gets or sets the type of the maintenance.
        /// </summary>
        /// <value>
        /// The type of the maintenance.
        /// </value>
        public MaintenanceType MaintenanceType { get; set; }

        /// <summary>
        /// Gets or sets the maintenance range.
        /// </summary>
        /// <value>
        /// The maintenance range.
        /// </value>
        public MaintenanceRange MaintenanceRange { get; set; }

        /// <summary>
        /// Gets or sets the maintenance percentage.
        /// </summary>
        /// <value>
        /// The maintenance percentage.
        /// </value>
        public int MaintenancePercentage { get; set; }
    }
}