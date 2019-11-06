using System;

namespace CyClone.Core
{
    /// <summary>
    /// Structure sync progress event args.
    /// </summary>
    [Serializable()]
    public class StructureSyncProgressEventArgs : SyncProgressEventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public StructureSyncProgressEventArgs()
        { }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Total amount of entries left to be processed.
        /// </summary>
        public int EntriesLeft
        {
            get;
            set;
        }
        #endregion
    }
}
