using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CyClone.Core
{
    #region MappingsEventArgs
    /// <summary>
    /// Class representing mapping changes event arguments.
    /// </summary>
    [Serializable()]
    public class MappingsEventArgs : EventArgs
    {
        #region Constructor
        public MappingsEventArgs(NotifyCollectionChangedAction action,
           List<IMappingsConfiguration> added,
           List<IMappingsConfiguration> removed)
        {
            this.Action = action;
            this.AddedItems = added;
            this.RemovedItems = removed;
        }
        #endregion

        #region Fields
        private List<IMappingsConfiguration> 
            addedItems, 
            removedItems;
        #endregion

        #region Properties

        /// <summary>
        /// Gets change action.
        /// </summary>
        public NotifyCollectionChangedAction Action
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the added items.
        /// </summary>
        public List<IMappingsConfiguration> AddedItems
        {
            get
            {
                if (this.addedItems == null)
                    this.addedItems = new List<IMappingsConfiguration>();
                return this.addedItems;
            }
            protected set
            {
                this.addedItems = value;
            }
        }

        /// <summary>
        /// Gets removed items.
        /// </summary>
        public List<IMappingsConfiguration> RemovedItems
        {
            get
            {
                if (this.removedItems == null)
                    this.removedItems = new List<IMappingsConfiguration>();
                return this.removedItems;
            }
            protected set { this.removedItems = value; }
        }

        #endregion

        #region OVERRIDES
        public override string ToString()
        {
            return String.Format("Change Action {0} Added Items {1} Removed Items {2}", this.Action, this.AddedItems.Count, this.RemovedItems.Count);
        }
        #endregion
    }
    #endregion

    #region SyncProgressEventArgs
    [Serializable()]
    public class SyncProgressEventArgs : EventArgs
    {
        #region Constructor
        public SyncProgressEventArgs()
        { }
        #endregion

        #region Properties

        /// <summary>
        /// Current entry being processed.
        /// </summary>
        public IcyFileSystemInfo Current
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the current offset in current entry.
        /// </summary>
        public long CurrentOffset
        {
            get;
            protected set;
        }

        /// <summary>
        /// Progress of synchronization for current entry.
        /// </summary>
        public uint Progress
        {
            get;
            protected set;
        }

        /// <summary>
        /// Total progress of synchronization.
        /// </summary>
        public uint TotalProgress
        {
            get;
            protected set;
        }

        /// <summary>
        /// Total ammount of entries left to be processed.
        /// </summary>
        public uint EntriesLeft
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion   
}
