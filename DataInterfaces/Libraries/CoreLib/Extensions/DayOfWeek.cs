using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CoreLib
{
    /// <summary>
    /// DayOfWeek extension.
    /// </summary>
    public static class DayOfWeekExtensions
    {
        #region STATIC FIELDS
        private static readonly IList<DayOfWeek> daysOfWeek = Enum.GetValues(typeof(DayOfWeek))
              .Cast<DayOfWeek>()
              .ToList();
        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets next day of week.
        /// </summary>
        /// <param name="day">From day.</param>
        /// <returns>Next day of week.</returns>
        public static DayOfWeek Next(this DayOfWeek day)
        {
            var currentIndex = daysOfWeek.IndexOf(day);

            int nextIndex = currentIndex + 1;
            if (currentIndex >= 6)
                nextIndex = 0;

            return daysOfWeek[nextIndex];
        }

        /// <summary>
        /// Gets first day of week based on current culture.
        /// </summary>
        /// <returns>First day of week.</returns>
        public static DayOfWeek CultureFirst(this DayOfWeek dayOfWeek) => CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

        /// <summary>
        /// Gets previous day of week.
        /// </summary>
        /// <param name="day">From day.</param>
        /// <returns>Previous day of week.</returns>
        public static DayOfWeek Previous(this DayOfWeek day)
        {
            var currentIndex = daysOfWeek.IndexOf(day);

            int nextIndex = currentIndex - 1;
            if (currentIndex <= 0)
                nextIndex = 6;

            return daysOfWeek[nextIndex];
        }

        /// <summary>
        /// Gets numeric index of specified day of week.
        /// </summary>
        /// <param name="day">Day of week.</param>
        /// <returns>Integer index.</returns>
        public static int DayIndex(this DayOfWeek day)
        {
            return daysOfWeek.IndexOf(day);
        }

        /// <summary>
        /// Gets list of days of week ordered by specified day of week.
        /// </summary>
        /// <param name="dayOfWeek">DayOfWeek instance.</param>
        /// <returns>Ordered days of week.</returns>
        public static IEnumerable<DayOfWeek> OrdererdBy(this DayOfWeek dayOfWeek)
        {
            return daysOfWeek
                .OrderBy(day => (day - dayOfWeek + 7) % 7);
        }

        /// <summary>
        /// Gets default localization key.
        /// </summary>
        /// <param name="dayOfWeek">Day of week instance.</param>
        /// <returns>Localized key string.</returns>
        public static string LocaliziationKey(this DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "DAY_OF_WEEK_SUNDAY";
                case DayOfWeek.Monday:
                    return "DAY_OF_WEEK_MONDAY";
                case DayOfWeek.Tuesday:
                    return "DAY_OF_WEEK_TUESDAY";
                case DayOfWeek.Wednesday:
                    return "DAY_OF_WEEK_WEDNESDAY";
                case DayOfWeek.Thursday:
                    return "DAY_OF_WEEK_THURSDAY";
                case DayOfWeek.Friday:
                    return "DAY_OF_WEEK_FRIDAY";
                case DayOfWeek.Saturday:
                    return "DAY_OF_WEEK_SATURDAY";
                default:
                    throw new ArgumentException();
            }
        }

        #endregion
    }
}
