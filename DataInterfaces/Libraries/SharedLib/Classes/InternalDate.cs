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
        private static int CreationTickCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets current date time.
        /// </summary>
        public static DateTime Now
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// Gets culture invariant date time.
        /// </summary>
        public static string CultureInvariantNow
        {
            get { return InternalDate.Now.ToString(CultureInfo.InvariantCulture); }
        }

        /// <summary>
        /// Gets UTC date time.
        /// </summary>
        public static DateTime UtcNow
        {
            get { return InternalDate.Now.ToUniversalTime(); }
        }

        #endregion
    }
}
