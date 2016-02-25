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
    #endregion

    #region StructureSyncProgressEventArgs
    [Serializable()]
    public class StructureSyncProgressEventArgs : SyncProgressEventArgs
    {
        #region CONSTRUCTOR
        public StructureSyncProgressEventArgs()
        { }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Total ammount of entries left to be processed.
        /// </summary>
        public int EntriesLeft
        {
            get;
            set;
        }
        #endregion
    } 
    #endregion

    #region FileChangedEventArgs
    [Serializable()]
    public class FileChangedEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance of FileChangedEventArgs.
        /// </summary>
        /// <param name="currentFile">Current file.</param>
        /// <param name="previousFile">Previous file.</param>
        public FileChangedEventArgs(IcyFileSystemInfo currentFile, IcyFileSystemInfo previousFile)
        {
            this.CurrentFile = currentFile;
            this.PreviousFile = previousFile;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets current file.
        /// </summary>
        public IcyFileSystemInfo CurrentFile
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets previous file.
        /// </summary>
        public IcyFileSystemInfo PreviousFile
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
