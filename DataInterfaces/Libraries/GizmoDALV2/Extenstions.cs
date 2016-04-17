using IntegrationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace GizmoDALV2
{
    #region DatExtensions
    public static class DateExtensions
    {
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
    #endregion
}
