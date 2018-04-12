using System;
namespace SharedLib.Applications
{
    /// <summary>
    /// Application rating interface.
    /// </summary>
    public interface IRating
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets application id.
        /// </summary>
        int ApplicationId { get; }

        /// <summary>
        /// Gets last rate time.
        /// </summary>
        DateTime LastRated { get; }

        /// <summary>
        /// Gets total rates count.
        /// </summary>
        int RatesCount { get; }

        /// <summary>
        /// Gets total rates value.
        /// </summary>
        double Value { get; } 

        #endregion
    }
}
