using System;

namespace Client
{
    /// <summary>
    /// Client grace period change args.
    /// </summary>
    public class GracePeriodChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public GracePeriodChangeEventArgs()
        { }

        #endregion

        public bool IsInGracePeriod { get; set; }

        public int GracePeriodTime { get; set; }
    }
}
