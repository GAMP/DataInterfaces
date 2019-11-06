using System;

namespace CoreLib
{
    /// <summary>
    /// System status implementation interface.
    /// </summary>
    public interface ISystemStatus
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets CPU level.
        /// </summary>
        int CPULevel { get; set; }

        /// <summary>
        /// Gets process uptime.
        /// </summary>
        TimeSpan ProcessUpTime { get; }

        /// <summary>
        /// Gets system up time.
        /// </summary>
        TimeSpan SystemUpTime { get; }

        /// <summary>
        /// Gets total process threads.
        /// </summary>
        int TotalThreads { get; } 

        #endregion
    }
}
