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
        private NotifyCollectionChangedAction action;
        private List<IMappingsConfiguration> addedItems, removedItems;

        #endregion

        #region Properties
        public NotifyCollectionChangedAction Action
        {
            get { return this.action; }
            private set { this.action = value; }
        }
        /// <summary>
        /// Gets the list of added items.
        /// </summary>
        public List<IMappingsConfiguration> AddedItems
        {
            get
            {
                if (this.addedItems == null)
                {
                    this.addedItems = new List<IMappingsConfiguration>();
                }
                return this.addedItems;
            }
            private set
            {
                this.addedItems = value;
            }
        }
        /// <summary>
        /// Gets the list of removed items.
        /// </summary>
        public List<IMappingsConfiguration> RemovedItems
        {
            get
            {
                if (this.removedItems == null)
                {
                    this.removedItems = new List<IMappingsConfiguration>();
                }
                return this.removedItems;
            }
            private set { this.removedItems = value; }
        } 
        #endregion

        #region Ovverides
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

        #region Fields
        private IcyFileSystemInfo entry;
        private long currentOffset = 0;
        private uint progress,
            totalProgress,
            entriesLeft;
        #endregion

        #region Properties

        /// <summary>
        /// Current entry being processed.
        /// </summary>
        public IcyFileSystemInfo Current
        {
            get { return this.entry; }
            protected set { this.entry = value; }
        }

        /// <summary>
        /// Gets the current offset in current entry.
        /// </summary>
        public long CurrentOffset
        {
            get { return this.currentOffset; }
            protected set { this.currentOffset=value; }
        }

        /// <summary>
        /// Progress of synchronization for current entry.
        /// </summary>
        public uint Progress
        {
            get { return this.progress; }
            protected set { this.progress = value; }
        }

        /// <summary>
        /// Total progress of synchronization.
        /// </summary>
        public uint TotalProgress
        {
            get { return this.totalProgress; }
            protected set { this.totalProgress = value; }
        }

        /// <summary>
        /// Total ammount of entries left to be processed.
        /// </summary>
        public uint EntriesLeft
        {
            get { return this.entriesLeft; }
            protected set { this.entriesLeft = value; }
        }

        #endregion
    }
    #endregion

    #region FileSyncException
    [Serializable()]
    public class FileSyncException : Exception, ISerializable
    {
        #region Constructor
        public FileSyncException(string message,
            FileSyncOperation error,
            IcyFileSystemInfo sourceFile, 
            IcyFileSystemInfo destinationFile,
            Exception inner)
            : base(message, inner)
        {
            this.Operation = error;
            this.SourceFile = sourceFile;
            this.DestinationFile = destinationFile;
        }

        public FileSyncException(string message)
            : base(message)
        { }

        public FileSyncException():base() { }
        
        public FileSyncException(string message, System.Exception inner):base(message, inner) { }
        
        protected FileSyncException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) :base(info ,context)
        {
            if (info != null)
            {               
                this.Operation = (FileSyncOperation)info.GetValue("Operation", typeof(FileSyncOperation));
                this.SourceFile = (IcyFileSystemInfo)info.GetValue("SourceFile", typeof(IcyFileSystemInfo));
                this.DestinationFile = (IcyFileSystemInfo)info.GetValue("DestinationFile", typeof(IcyFileSystemInfo));
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the operation error.
        /// </summary>
        public FileSyncOperation Operation
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the source file info.
        /// </summary>
        public IcyFileSystemInfo SourceFile
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the destination file info.
        /// </summary>
        public IcyFileSystemInfo DestinationFile
        {
            get;
            protected set;
        }

        #endregion

        #region ISerializable
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("Operation", this.Operation);
                info.AddValue("SourceFile", this.SourceFile);
                info.AddValue("DestinationFile", this.DestinationFile);
            }
        } 
        #endregion

        #region Ovverides
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(String.Format("Operation:{0}",this.Operation));
            builder.AppendLine(String.Format("Source FileName:{0}", this.SourceFile));
            builder.AppendLine(String.Format("Destination FileName:{0}", this.DestinationFile));
            builder.AppendLine(String.Format("Message:{0}", this.Message));
            builder.AppendLine();
            builder.AppendLine(base.ToString());
            return builder.ToString();
        }
        #endregion
    } 
    #endregion
}
