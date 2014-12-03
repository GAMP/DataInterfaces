using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace CyClone.Core
{
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

        public FileSyncException() : base() { }

        public FileSyncException(string message, System.Exception inner) : base(message, inner) { }

        protected FileSyncException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
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

        #region OVERRIDES

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(String.Format("Operation:{0}", this.Operation));
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
