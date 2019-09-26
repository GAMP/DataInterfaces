using System;

namespace CyClone.Core
{
    [Serializable()]
    public class StructureSyncProgressEventArgs : SyncProgressEventArgs
    {
        #region CONSTRUCTOR
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
