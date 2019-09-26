using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Backup file info model.
    /// </summary>
    /// <remarks>
    /// Used to describe file entry in backup file.
    /// </remarks>
    [Serializable()]
    [DataContract()]
    public class BackupFileInfo
    {
        #region PROPERTIES

        /// <summary>
        /// File date.
        /// </summary>
        [DataMember()]
        public DateTime Date
        {
            get; set;
        }

        /// <summary>
        /// File name.
        /// </summary>
        [DataMember()]
        public string FileName
        {
            get; set;
        }

        #endregion
    }
}
