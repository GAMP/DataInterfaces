using System;
using System.Globalization;

namespace CoreLib
{
    /// <summary>
    /// DateTime extension class.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the age in years of the current DateTime based on current Date.
        /// </summary>
        /// <param name="birthDate">The date of birth.</param>
        /// <returns>
        /// Integer age value.
        /// </returns>
        public static int Age(this DateTime birthDate)
        {
            if (birthDate == null)
                throw new ArgumentNullException(nameof(birthDate));

            var yearsOld = DateTime.Today.Year - birthDate.Year;
            if (DateTime.Today < birthDate.AddYears(yearsOld)) yearsOld--;
            return yearsOld;
        }

        /// <summary>
        /// Converts provided date daily second to weekly value.
        /// </summary>
        /// <param name="dt">Date time.</param>
        /// <returns>Weekly second value.</returns>
        public static double WeeklySecond(this DateTime dt)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return WeeklySecond(dt.DayOfWeek, dt.TimeOfDay.TotalSeconds);
        }

        /// <summary>
        /// Converts provided day of week second to weekly value.
        /// </summary>
        /// <param name="time">Date time.</param>
        /// <returns>Weekly second value.</returns>
        public static double WeeklySecond(DayOfWeek dayOfWeek, double daySecond)
        {
            if (daySecond > 86400)
                throw new ArgumentException(nameof(daySecond), nameof(daySecond));

            return (((int)(daySecond / 60) * 60)) + ((int)dayOfWeek * 86400);
        }

        /// <summary>
        /// Creates new datetime without milliseconds.
        /// </summary>
        /// <param name="dt">Existing datetime.</param>
        /// <returns>New date time value.</returns>
        public static DateTime WithoutMilliSeconds(this DateTime dt)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Kind);
        }

        /// <summary>
        /// Gets start of the week date time.
        /// </summary>
        /// <param name="dt">DateTime.</param>
        /// <returns>Start of the week DateTime.</returns>
        public static DateTime StartOfWeek(this DateTime dt)
        {
            return StartOfWeek(dt, null, null);
        }

        /// <summary>
        /// Gets start of the week date time.
        /// </summary>
        /// <param name="dt">DateTime.</param>
        /// <param name="firstDayOfWeek">First day of the week.</param>
        /// <returns>Start of the week DateTime.</returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek? firstDayOfWeek)
        {
            return StartOfWeek(dt, firstDayOfWeek, null);
        }

        /// <summary>
        /// Gets start of the week date time.
        /// </summary>
        /// <param name="dt">DateTime.</param>
        /// <param name="firstDayOfWeek">First day of the week.</param>
        /// <param name="dayStartTime">Day start time.</param>
        /// <returns>Start of the week DateTime.</returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek? firstDayOfWeek, TimeSpan? dayStartTime)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            //start time should not contain more than 24 hours
            if (dayStartTime.HasValue && dayStartTime.Value.TotalHours > 24)
                throw new ArgumentOutOfRangeException(nameof(dayStartTime));

            DayOfWeek fdow = firstDayOfWeek ?? CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

            int diff = dt.DayOfWeek - fdow;

            if (diff < 0)
                diff += 7;

            var result = dt.AddDays(-1 * diff).Date;

            if (dayStartTime.HasValue)
                result = result.AddSeconds(dayStartTime.Value.TotalSeconds);

            return result;
        }

        /// <summary>
        /// Gets DateTime representing start of the month for specified DateTime.
        /// </summary>
        /// <param name="dt">DateTime instance.</param>
        /// <returns>Resulted date time.</returns>
        public static DateTime StartOfMonth(this DateTime dt)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return new DateTime(dt.Year, dt.Month, 1);
        }

        /// <summary>
        /// Gets DateTime representing start of the current month.
        /// </summary>
        /// <param name="dt">DateTime instance.</param>
        /// <returns>Resulted date time.</returns>
        public static DateTime StartOfCurrentMonth(this DateTime dt)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return new DateTime(dt.Year, dt.Month, 1);
        }

        /// <summary>
        /// Gets start of previous month.
        /// </summary>
        /// <param name="dt">Date time.</param>
        /// <returns>Previous month start date.</returns>
        public static DateTime StartOfPreviousMonth(this DateTime dt)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            var previousMonthDate = dt.AddMonths(-1);

            return new DateTime(previousMonthDate.Year, previousMonthDate.Month, 1);
        }

        /// <summary>
        /// Gets DateTime representing start of the year.
        /// </summary>
        /// <param name="dt">DateTime instance.</param>
        /// <returns>Resulted date time.</returns>
        public static DateTime StartOfYear(this DateTime dt)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return new DateTime(dt.Year, 1, 1);
        }

        /// <summary>
        /// Gets DateTime representing start of the previous year.
        /// </summary>
        /// <param name="dt">DateTime instance.</param>
        /// <returns>Resulted date time.</returns>
        public static DateTime StartOfPreviousYear(this DateTime dt)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            var previousYearDate = dt.AddYears(-1);

            return new DateTime(previousYearDate.Year, 1, 1);
        }
    }
}
