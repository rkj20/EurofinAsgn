namespace ClubHouseUtil.Facilities
{
    using ClubHouseUtil.Model.Configurations;
    using ClubHouseUtil.Model.Constants;
    using ClubHouseUtil.Model.Dtos;
    using ClubHouseUtil.Model.Enums;
    using ClubHouseUtil.Model.Interfaces;
    using ClubHouseUtil.Model.Logging;
    using ClubHouseUtil.Model.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;
    using System.Xml.Schema;

    /// <summary>
    /// Base class for default facility implementations
    /// </summary>
    /// <seealso cref="ClubHouseUtil.Model.Interfaces.IFacility" />
    public abstract class FacilityBase : IFacility
    {
        /// <summary>
        /// The Gym specific configuration
        /// </summary>
        private readonly IFacilityConfiguration _config;

        /// <summary>
        /// The logger instance
        /// </summary>
        private readonly IFacilityLogger _logger;

        /// <summary>
        /// The timer for background tasks at specified interval
        /// </summary>
        private readonly Timer _timer;

        /// <summary>
        /// The booking slots, Ideally should be moved to database
        /// </summary>
        protected List<BookingSlot> slots = new List<BookingSlot>();

        /// <summary>
        /// The bookings details, Ideally should be moved to database
        /// </summary>
        protected Dictionary<string, BookingDetails> bookingsList = new Dictionary<string, BookingDetails>();

        /// <summary>
        /// The facility timings, Ideally should be moved to database
        /// </summary>
        protected Dictionary<DateTime, TimingDetails> timingsList = new Dictionary<DateTime, TimingDetails>();

        /// <summary>
        /// The locking period details, Ideally should be moved to database
        /// </summary>
        protected Dictionary<string, LockingDetails> lockingPeriodList = new Dictionary<string, LockingDetails>();

        /// <summary>
        /// The users accessing facility, Ideally should be moved to database
        /// </summary>
        protected List<AccessDetails> usersAccessingFacilityList = new List<AccessDetails>();

        /// <summary>
        /// The maintenance details, Ideally should be moved to database
        /// </summary>
        protected Dictionary<string, MaintenanceDetails> maintenanceList = new Dictionary<string, MaintenanceDetails>();

        /// <summary>
        /// Gets the facility identifier.
        /// </summary>
        /// <value>
        /// The facility identifier.
        /// </value>
        public abstract int FacilityId { get; }

        /// <summary>
        /// Gets the name of the facility.
        /// </summary>
        /// <value>
        /// The name of the facility.
        /// </value>
        public abstract string FacilityName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacilityBase"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        protected FacilityBase(IFacilityConfiguration config, IFacilityLogger logger)
        {
            _logger = logger;
            _config = config;
            _logger.Information("Starting timer for background tasks");
            _timer = new Timer(TimeSpan.FromSeconds(10).TotalMilliseconds);
            _timer.Elapsed += VerifyAccess;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            _logger.Information("Disposing timer and further cleanup");
            _timer.Stop();
            _timer.Enabled = false;
            _timer.Elapsed -= VerifyAccess;
            _timer.Dispose();
        }

        #region Maintenance

        /// <summary>
        /// Creates the maintenance.
        /// </summary>
        /// <param name="maintenance">The maintenance.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual IResposnse CreateMaintenance(MaintenanceDetails maintenance)
        {
            // Validate maintenance timing belongs to same date
            if (!maintenance.StartTime.Date.Equals(maintenance.EndTime.Date))
                return new Resposnse(false, "Start Time and End Time belongs to different dates.");

            // Validate maintenance end time is in future
            if (DateTime.Compare(maintenance.EndTime, DateTime.Now) >=0)
                return new Resposnse(false, "Maintenance End Time is not in future.");

            // Validate If maintenance already exists
            if (!string.IsNullOrEmpty(maintenance.MaintenanceId) && maintenanceList.ContainsKey(maintenance.MaintenanceId))
                return new Resposnse(false, "Can not add Maintenance as Maintenance already exists.");

            // Validate if the proposed maintenance timing overlaps with any existing maintenance
            if (maintenanceList.Values.Any(x => x.Exists(maintenance)))
                return new Resposnse(false, "Can not add Maintenance as Maintenance timing overlaps with existing Maintenance timing.");

            // Validate only allowed percentage is under maintenance
            if(maintenance.MaintenancePercentage > _config.PercentageAllowed && maintenance.MaintenanceType == MaintenanceType.Predefined)
                return new Resposnse(false, "Maintenance percentage is above allowed limit.");

            // If the maintenance is recurring the add future maintenance
            if (maintenance.MaintenanceType == MaintenanceType.Predefined)
            {
                switch (maintenance.RecurringFrequency)
                {
                    case MaintenanceFrequency.None:
                        maintenance.MaintenanceId = Guid.NewGuid().ToString();
                        maintenanceList.Add(maintenance.MaintenanceId, maintenance);
                        break;
                    case MaintenanceFrequency.Weekly:
                        AddFutureMaintenance(maintenance, 7);
                        break;
                    case MaintenanceFrequency.Monthly:
                        AddFutureMaintenance(maintenance, 30);
                        break;
                    case MaintenanceFrequency.Yearly:
                        AddFutureMaintenance(maintenance, 365);
                        break;
                }
            }

            // Verify if any bookings are there cancel them
            VerifyBookingsAfterChange(maintenance.StartTime, maintenance.EndTime);

            // For on-demand maintenance, this validation only warns but allows scheduling
            var msg = maintenance.MaintenanceType == MaintenanceType.OnDemand && maintenance.MaintenancePercentage > _config.PercentageAllowed ?
                "Warning - Maintenance percentage is above allowed limit." :
                "Maintenance created to facility.";
            return new Resposnse(true, msg);
        }

        /// <summary>
        /// Read all schedule maintenance
        /// </summary>
        /// <returns>List of all maintenance details</returns>
        public virtual List<MaintenanceDetails> ReadAllMaintenance()
        {
            return maintenanceList.Values.ToList();
        }

        /// <summary>
        /// Read specific maintenance details by maintenance id
        /// </summary>
        /// <param name="maintenanceId"></param>
        /// <returns>Returns specific maintenance details</returns>
        public virtual MaintenanceDetails ReadMaintenance(string maintenanceId)
        {
            if (maintenanceList.ContainsKey(maintenanceId))
                return maintenanceList[maintenanceId];
            return null;
        }

        public virtual IResposnse UpdateMaintenance(MaintenanceDetails maintenance)
        {
            if (!maintenanceList.ContainsKey(maintenance.MaintenanceId))
                return new Resposnse(false, "Maintenance does not exist.");

            maintenanceList[maintenance.MaintenanceId] = maintenance;

            // Verify if any bookings are there cancel them
            VerifyBookingsAfterChange(maintenance.StartTime, maintenance.EndTime);

            return new Resposnse(true, "Updated maintenance details to the Facility.");
        }

        public virtual IResposnse DeleteMaintenance(MaintenanceDetails maintenance)
        {
            if (!maintenanceList.ContainsKey(maintenance.MaintenanceId))
                return new Resposnse(false, "Maintenance does not exist.");

            maintenanceList.Remove(maintenance.MaintenanceId);
            return new Resposnse(true, "Deleted maintenance details to the Facility.");
        }

        #endregion Maintenance

        #region Timing

        public virtual IResposnse CreateTiming(TimingDetails timing)
        {
            // Validate timing belongs to same date
            if (!timing.OpenTime.Date.Equals(timing.CloseTime.Date))
                return new Resposnse(false, "Start Time and End Time belongs to different dates.");

            // check If timing already exists for the specified date
            if (timingsList.ContainsKey(timing.OpenTime.Date))
                return new Resposnse(false, "Timing already exists.");

            CreateSlots(timing);
            timingsList.Add(timing.OpenTime.Date, timing);

            return new Resposnse(true, "Timing added to facility");
        }

        public virtual List<TimingDetails> ReadAllTimings()
        {
            return timingsList.Values.ToList();
        }

        public virtual IResposnse UpdateTiming(TimingDetails timing)
        {
            // Validate timing belongs to same date
            if (!timing.OpenTime.Date.Equals(timing.CloseTime.Date))
                return new Resposnse(false, "Start Time and End Time belongs to different dates.");

            // check If timing exists for the specified date
            if (timingsList.ContainsKey(timing.OpenTime.Date))
            {
                timingsList[timing.OpenTime.Date] = timing;
                return new Resposnse(true, "Timing updated successfully.");
            }
            return new Resposnse(false, "Unable to update Timing.");
        }

        public virtual IResposnse DeleteTiming(TimingDetails timing)
        {
            // check If timing exists for the specified date
            if (timingsList.ContainsKey(timing.OpenTime.Date))
            {
                timingsList.Remove(timing.OpenTime.Date);
                return new Resposnse(true, "Timing deleted successfully.");
            }
            return new Resposnse(false, "Unable to delete Timing.");
        }

        #endregion Timing

        #region Booking

        public virtual IResposnse CreateBooking(BookingDetails booking)
        {
            var (bookingAllowed, responseMessage) = CheckIfBookingAllowed(booking);
            if (bookingAllowed)
            {
                booking.BookingId = Guid.NewGuid().ToString();
                bookingsList.Add(booking.BookingId, booking);
                return new Resposnse(true, $"Booking Created success fully with Booking Id - {booking.BookingId}");
            }
            return new Resposnse(false, responseMessage);
        }

        public virtual List<BookingDetails> ReadAllBooking()
        {
            return bookingsList.Values.ToList();
        }

        public virtual BookingDetails ReadBooking(string bookingId)
        {
            if (!string.IsNullOrEmpty(bookingId) && bookingsList.ContainsKey(bookingId))
                return bookingsList[bookingId];
            return null;
        }

        public virtual IResposnse UpdateBooking(BookingDetails booking)
        {
            // check If locking id already exists
            if (!string.IsNullOrEmpty(booking.BookingId) && lockingPeriodList.ContainsKey(booking.BookingId))
            {
                var (bookingAllowed, responseMessage) = CheckIfBookingAllowed(booking);
                if (bookingAllowed)
                {
                    bookingsList[booking.BookingId] = booking;
                    return new Resposnse(true, "booking details updated successfully.");
                }
                return new Resposnse(false, responseMessage);
            }
            return new Resposnse(false, "Unable to find booking details to update.");
        }

        public virtual IResposnse DeleteBooking(BookingDetails booking)
        {
            if (!bookingsList.ContainsKey(booking.BookingId))
                return new Resposnse(false, "Booking does not exist.");

            bookingsList.Remove(booking.BookingId);
            return new Resposnse(true, "Deleted booking details to the Facility.");
        }

        #endregion Booking

        #region Locking

        public virtual IResposnse CreateLocking(LockingDetails locking)
        {
            // check If locking id already exists
            if (!string.IsNullOrEmpty(locking.LockingId) && lockingPeriodList.ContainsKey(locking.LockingId))
                return new Resposnse(false, "Locking already exists.");

            // check If locking timing already exists
            if (lockingPeriodList.Values.Any(x => x.Exists(locking)))
                return new Resposnse(false, "Locking already exists.");

            locking.LockingId = Guid.NewGuid().ToString();
            lockingPeriodList.Add(locking.LockingId, locking);

            // Verify bookings after locking created
            VerifyBookingsAfterChange(locking.LockStartTime, locking.LockEndTime);
            return new Resposnse(true, "Locking details added to facility.");
        }

        public virtual List<LockingDetails> ReadAllLocking()
        {
            return lockingPeriodList.Values.ToList();
        }

        public virtual LockingDetails ReadLocking(string lockingId)
        {
            // check If locking id already exists
            if (!string.IsNullOrEmpty(lockingId) && lockingPeriodList.ContainsKey(lockingId))
                return lockingPeriodList[lockingId];

            return null;
        }

        public virtual IResposnse UpdateLocking(LockingDetails locking)
        {
            // check If locking id already exists
            if (!string.IsNullOrEmpty(locking.LockingId) && lockingPeriodList.ContainsKey(locking.LockingId))
            {
                lockingPeriodList[locking.LockingId] = locking;
                VerifyBookingsAfterChange(locking.LockStartTime, locking.LockEndTime);
                return new Resposnse(true, "Locking details updated successfully");
            }
            return new Resposnse(false, "Unable to find locking details to update");
        }

        public virtual IResposnse DeleteLocking(LockingDetails locking)
        {
            // check If locking id already exists
            if (!string.IsNullOrEmpty(locking.LockingId) && lockingPeriodList.ContainsKey(locking.LockingId))
            {
                lockingPeriodList.Remove(locking.LockingId);
                return new Resposnse(true, "Locking details removed successfully");
            }
            return new Resposnse(false, "Unable to find locking details to delete");
        }

        #endregion Locking

        #region Access

        public virtual IResposnse CreateAccess(AccessDetails access)
        {
            if(bookingsList.Values.Any(x=> x.UserDetails.UserId == access.User.UserId && DateTime.Compare(access.CheckinTime, x.SlotDetails.SlotStartTime) >=0 && DateTime.Compare(access.CheckinTime, x.SlotDetails.SlotStartTime.AddMinutes(x.SlotDetails.SlotLengthInMinutes)) <= 0 && x.SlotDetails.BookingAllowed))
            {
                if (usersAccessingFacilityList.Any(x => x.User.UserId == access.User.UserId))
                    return new Resposnse(false, "User already Accessing Facility");
                usersAccessingFacilityList.Add(access);
                return new Resposnse(true, "User Accessing Facility");
            }
            return new Resposnse(false, "No prior booking for the user");
        }

        public virtual List<AccessDetails> ReadAllAccess()
        {
            return usersAccessingFacilityList;
        }

        public virtual AccessDetails ReadAccess(int userId)
        {
            return usersAccessingFacilityList.First(x => x.User.UserId == userId);
        }

        public virtual IResposnse UpdateAccess(AccessDetails access)
        {
            if (!usersAccessingFacilityList.Any(x => x.User.UserId == access.User.UserId))
                return new Resposnse(false, "User not Accessing Facility");

            var item = usersAccessingFacilityList.First(x => x.User.UserId == access.User.UserId);
            var index = usersAccessingFacilityList.IndexOf(item);

            if (index != -1)
            {
                usersAccessingFacilityList[index] = access;
                return new Resposnse(true, "Updated User access to Facility");
            }
            return new Resposnse(false, "Unable to update User access to Facility");
        }

        public virtual IResposnse DeleteAccess(AccessDetails access)
        {
            if (!usersAccessingFacilityList.Any(x => x.User.UserId == access.User.UserId))
                return new Resposnse(false, "User not Accessing Facility");
            var item = usersAccessingFacilityList.First(x => x.User.UserId == access.User.UserId);
            var index = usersAccessingFacilityList.IndexOf(item);

            if (index != -1)
            {
                usersAccessingFacilityList.RemoveAt(index);
                return new Resposnse(true, "Deleted User access to Facility");
            }
            return new Resposnse(false, "Unable to delete User access to Facility");
        }

        #endregion Access

        /// <summary>
        /// Creates the slots.
        /// </summary>
        /// <param name="timing">The timing.</param>
        protected void CreateSlots(TimingDetails timing)
        {
            int slotCounter = 1;
            var startTime = timing.OpenTime;
            do
            {
                timing.Slots.Add(new BookingSlot
                {
                    BookingSlotId = slotCounter++,
                    SlotLengthInMinutes = _config.SlotLengthInMinutes,
                    SlotStartTime = startTime
                });

                startTime = timing.NextAvailableSlotStartTime(startTime, _config.SlotLengthInMinutes);
            } while (DateTime.Compare(startTime, timing.CloseTime) >= 0);
        }

        /// <summary>
        /// Verify and checkout all users -
        /// When the facility is not under Maintenance
        /// When the Facility is locked - cancel all User's booking
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        protected void VerifyAccess(object sender, ElapsedEventArgs e)
        {
            // Check if Facility is under maintenance then checkout all users
            if (maintenanceList.Values.Any(x => x.MaintenanceExistsNow(DateTime.Now)))
                usersAccessingFacilityList.ForEach(x => x.IsCheckedIn = false);

            // Check if facility is locked then checkout all users
            if (lockingPeriodList.Values.Any(x => x.LockingExistsNow(DateTime.Now)))
                usersAccessingFacilityList.ForEach(x => x.IsCheckedIn = false);
        }

        /// <summary>
        /// Check if specified booking is allowed
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>true if booking is allowed or false</returns>
        protected (bool, string) CheckIfBookingAllowed(BookingDetails booking )
        {
            // Check if Facility is under maintenance
            if(maintenanceList.Values.Any(x=> x.Exists(booking.SlotDetails.SlotStartTime, booking.SlotDetails.SlotStartTime.AddMinutes(booking.SlotDetails.SlotLengthInMinutes))))
                return (false, "Booking not Allowed for specific slot as Maintenance is scheduled");

            // Check if facility is locked
            if (lockingPeriodList.Values.Any(x => x.Exists(booking.SlotDetails.SlotStartTime, booking.SlotDetails.SlotStartTime.AddMinutes(booking.SlotDetails.SlotLengthInMinutes))))
                return (false, "Booking not Allowed for specific slot as Facility is locked");

            // Check if any other booking is alloted in that slot
            if (bookingsList.Values.Any(x => x.Exists(booking.SlotDetails.SlotStartTime, booking.SlotDetails.SlotStartTime.AddMinutes(booking.SlotDetails.SlotLengthInMinutes))))
                return (false, "Booking not Allowed for specific slot as another booking exists");

            // Check if the slot comes under any break time
            if (timingsList.Values.Any(x => x.Exists(booking.SlotDetails.SlotStartTime, booking.SlotDetails.SlotStartTime.AddMinutes(booking.SlotDetails.SlotLengthInMinutes))))
                return (false, "Booking not Allowed for specific slot as it falls under break time");

            // Check if the User has booked prior or next slot so we don't allow continuous booking
            if (bookingsList.Values.Any(x => x.IsContinuousBooking(booking)))
                return (false, "Booking not Allowed for specific slot as it will be a continuous booking");

            return (true, "Booking allowed for the slot");
        }

        /// <summary>
        /// Verify bookings on Maintenance Update and cancel them
        /// </summary>
        protected void VerifyBookingsAfterChange(DateTime startTime, DateTime endTime)
        {
            // Checkout all checked in Users
            // We can think of someway to notify that the user should be removed
            usersAccessingFacilityList.ForEach(x => x.IsCheckedIn = false);

            // Cancel all Bookings during the period
            var bookings = bookingsList.Values.ToList().FindAll(x => x.Exists(startTime, endTime));
            bookings.ForEach(x => bookingsList.Remove(x.BookingId));
        }

        /// <summary>
        /// Adds any future maintenance
        /// </summary>
        /// <param name="maintenance"></param>
        /// <param name="repeat"></param>
        protected void AddFutureMaintenance(MaintenanceDetails maintenance, int repeat)
        {
            for (int i = 0; i < maintenance.NoOfRecurrence; i++)
            {
                maintenance.MaintenanceId = Guid.NewGuid().ToString();
                maintenance.StartTime = maintenance.StartTime.AddDays(repeat);
                maintenance.EndTime = maintenance.EndTime.AddDays(repeat);
                if (!maintenanceList.Values.Any(x => x.Exists(maintenance)))
                {
                    // give user warning that some of the future maintenance is not scheduled  and also log warning
                    _logger.Warning("Skipping adding of future maintenance as it already exists");
                    maintenanceList.Add(maintenance.MaintenanceId, maintenance);
                }
            }
        }
    }
}