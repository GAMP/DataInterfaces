using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [Serializable()]
    public class BackupResult
    {
        #region CONSTRUCTOR

        public BackupResult(BackupResultCode code) : this(null, code, null)
        { }

        public BackupResult(Exception ex) : this(null, BackupResultCode.Failed, ex)
        { }

        public BackupResult(string fileName, BackupResultCode code) : this(fileName, code, null)
        { }

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
