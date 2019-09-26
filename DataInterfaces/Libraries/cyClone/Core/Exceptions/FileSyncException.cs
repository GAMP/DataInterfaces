using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace CyClone.Core
{
    [Serializable()]
    public class FileSyncException : Exception, ISerializable
    {
        #region CONSTRUCTOR

        public FileSyncException(string message,
            FileSyncOperation error,
            IcyFileSystemInfo sourceFile,
            IcyFileSystemInfo destinationFile,
            Exception inner)
            : base(message, inner)
        {
            Operation = error;
            SourceFile = sourceFile;
            DestinationFile = destinationFile;
        }

        public FileSyncException(string message)
            : base(message)
        { }

        public FileSyncException() : base() { }

        public FileSyncException(string message, System.Exception inner) : base(message, inner) { }

        protected FileSyncException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                Operation = (FileSyncOperation)info.GetValue("Operation", typeof(FileSyncOperation));
                SourceFile = (IcyFileSystemInfo)info.GetValue("SourceFile", typeof(IcyFileSystemInfo));
                DestinationFile = (IcyFileSystemInfo)info.GetValue("DestinationFile", typeof(IcyFileSystemInfo));
            }
        }

        #endregion

        #region PROPERTIES

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

        #region OVERRIDES

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Operation:{0}", Operation));
            builder.AppendLine(string.Format("Source FileName:{0}", SourceFile));
            builder.AppendLine(string.Format("Destination FileName:{0}", DestinationFile));
            builder.AppendLine(string.Format("Message:{0}", Message));
            builder.AppendLine();
            builder.AppendLine(base.ToString());
            return builder.ToString();
        }

        #endregion

        #region ISerializable

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("Operation", Operation);
                info.AddValue("SourceFile", SourceFile);
                info.AddValue("DestinationFile", DestinationFile);
            }
        }

        #endregion
    }
}
