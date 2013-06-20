using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedLib
{
    /// <summary>
    /// Allows to keep internal date time independently of system time change.
    /// </summary>
    public static class InternalDate
    {
        #region CONSTRUCTOR
        static InternalDate()
        {
            CreationTime = DateTime.Now;
            CreationTickCount = Environment.TickCount;
        } 
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets class creation time.
        /// <remarks>This time is equals to process creation time.</remarks>
        /// </summary>
        public static DateTime CreationTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets system ticks set during class creation.
        /// <remarks>This is equals to system ticks set during process creation.</remarks>
        /// </summary>
        public static int CreationTickCount
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets current date time based on system ticks.
        /// </summary>
        public static DateTime Now
        {
            get { return CreationTime.Add(TimeSpan.FromMilliseconds(Environment.TickCount - CreationTickCount)); }
        }

        /// <summary>
        /// Gets culture invariant date time.
        /// </summary>
        public static string CultureInvariantNow
        {
            get { return InternalDate.Now.ToString(CultureInfo.InvariantCulture); }
        }
        #endregion
    }
}
