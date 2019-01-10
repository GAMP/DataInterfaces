using SharedLib.Dispatcher;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace CyClone.Core
{
    #region MappingsEventArgs
    /// <summary>
    /// Class representing mapping changes event arguments.
    /// </summary>
    [Serializable()]
    public class MappingsEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public MappingsEventArgs(NotifyCollectionChangedAction action,
           List<IMappingsConfiguration> added,
           List<IMappingsConfiguration> removed)
        {
            Action = action;
            AddedItems = added;
            RemovedItems = removed;
        }
        #endregion

        #region FIELDS
        private List<IMappingsConfiguration>
            addedItems,
            removedItems;
        #endregion

        #region PROPERTIES

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
                if (addedItems == null)
                    addedItems = new List<IMappingsConfiguration>();
                return addedItems;
            }
            protected set
            {
                addedItems = value;
            }
        }

        /// <summary>
        /// Gets removed items.
        /// </summary>
        public List<IMappingsConfiguration> RemovedItems
        {
            get
            {
                if (removedItems == null)
                    removedItems = new List<IMappingsConfiguration>();
                return removedItems;
            }
            protected set { removedItems = value; }
        }

        #endregion

        #region OVERRIDES
        public override string ToString()
        {
            return String.Format("Change Action {0} Added Items {1} Removed Items {2}", Action, AddedItems.Count, RemovedItems.Count);
        }
        #endregion
    }
    #endregion

    #region SyncProgressEventArgs
    [Serializable()]
    public class SyncProgressEventArgs : EventArgs
    {
        #region CONSTRUCTOR
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
        /// Total amount of entries left to be processed.
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
            CurrentFile = currentFile;
            PreviousFile = previousFile;
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

namespace CyClone.Security
{
    #region VerifyAccessEventArgs
    public class VerifyAccessEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public VerifyAccessEventArgs(string path,
            IMessageDispatcher dispatcher,
            FileAccess access,
            FileMode mode,
            bool sucess = true)
        {
            TimeStamp = DateTime.Now;
            Access = access;
            Mode = mode;
            Path = path;
            Dispatcher = dispatcher;
            Sucess = sucess;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets verification access flags.
        /// </summary>
        public FileAccess Access
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the calling dispatcher.
        /// </summary>
        public IMessageDispatcher Dispatcher
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the path verified.
        /// </summary>
        public string Path
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets if verification was sucessfull.
        /// </summary>
        public bool Sucess
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets verification file mode flag.
        /// </summary>
        public FileMode Mode
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets event time stamp.
        /// </summary>
        public DateTime TimeStamp
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
