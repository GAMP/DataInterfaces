using System;
using System.Data.SqlTypes;

namespace GizmoDALV2
{
    /// <summary>
    /// Date extenstions.
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// Gets SQL db date time.
        /// </summary>
        /// <param name="time">Time.</param>
        /// <returns>SQL DateTime.</returns>
        public static DateTime GetDbDateTime(this DateTime time)
        {
            return time <= SqlDateTime.MinValue.Value ? SqlDateTime.MinValue.Value : time;
        }

        /// <summary>
        /// Gets or sets if specified time is minimum SQL date time.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool IsSQLMinDate(this DateTime time)
        {
            return time <= SqlDateTime.MinValue.Value;
        }

        /// <summary>
        /// Gets if specified time is maximum SQL date time.
        /// </summary>
        /// <param name="time">DateTime.</param>
        /// <returns>True or false.</returns>
        public static bool IsSQLMaxDate(this DateTime time)
        {
            return time >= SqlDateTime.MaxValue.Value;
        }

        /// <summary>
        /// Gets if specified time is minimum or maximum SQL date time.
        /// </summary>
        /// <param name="time">DateTime.</param>
        /// <returns>True or false.</returns>
        public static bool IsSQLMinOrMax(this DateTime time)
        {
            return time.IsSQLMinDate() || time.IsSQLMaxDate();
        }
    }
}
