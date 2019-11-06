using System;

namespace CyClone.Core
{
    /// <summary>
    /// File sync progress event args.
    /// </summary>
    [Serializable()]
    public class SyncProgressEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public SyncProgressEventArgs()
        { }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Current entry being processed.
        /// </summary>
        public IcyFileSystemInfo Current
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the current offset in current entry.
        /// </summary>
        public long CurrentOffset
        {
            get;
            set;
        }

        /// <summary>
        /// Progress of synchronization for current entry.
        /// </summary>
        public double Progress
        {
            get;
            set;
        }

        /// <summary>
        /// Total progress of synchronization.
        /// </summary>
        public double TotalProgress
        {
            get;
            set;
        }

        #endregion
    }
}
