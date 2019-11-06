using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Backup result model.
    /// </summary>
    /// <remarks>
    /// Provides backup result information.
    /// </remarks>
    [DataContract()]
    [Serializable()]
    public class BackupResult
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="code">Result code.</param>
        public BackupResult(BackupResultCode code) : this(null, code, null)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="ex">Exception.</param>
        public BackupResult(Exception ex) : this(null, BackupResultCode.Failed, ex)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="fileName">Backup file name.</param>
        /// <param name="code">Result code.</param>
        public BackupResult(string fileName, BackupResultCode code) : this(fileName, code, null)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="fileName">Backup file name.</param>
        /// <param name="code">Result code.</param>
        /// <param name="ex">Exception.</param>
        public BackupResult(string fileName, BackupResultCode code, Exception ex)
        {
            BackupFile = fileName;
            Code = code;
            Error = ex;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets result code.
        /// </summary>
        [DataMember()]
        public BackupResultCode Code
        {
            get;
        }

        /// <summary>
        /// Gets error exception.
        /// </summary>
        [DataMember()]
        public Exception Error
        {
            get;
        }

        /// <summary>
        /// Gets backup file.
        /// </summary>
        [DataMember()]
        public string BackupFile
        {
            get;
        }

        #endregion
    }
}
