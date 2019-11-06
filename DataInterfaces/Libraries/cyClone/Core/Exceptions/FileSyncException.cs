using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace CyClone.Core
{
    /// <summary>
    /// File sync exception.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class FileSyncException : Exception, ISerializable
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="error">Error code.</param>
        /// <param name="sourceFile">Source file.</param>
        /// <param name="destinationFile">Destination file.</param>
        /// <param name="inner">Inner exception.</param>
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

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public FileSyncException(string message)
            : base(message)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public FileSyncException() : base() { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public FileSyncException(string message, System.Exception inner) : base(message, inner) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
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
        [DataMember()]
        public FileSyncOperation Operation
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the source file info.
        /// </summary>
        [DataMember()]
        public IcyFileSystemInfo SourceFile
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the destination file info.
        /// </summary>
        [DataMember()]
        public IcyFileSystemInfo DestinationFile
        {
            get;
            protected set;
        }

        #endregion        

        #region OVERRIDES

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
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
