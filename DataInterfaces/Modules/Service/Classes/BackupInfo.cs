using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Backup information model.
    /// </summary>
    /// <remarks>
    /// Used to describe an backup.
    /// </remarks>
    [DataContract()]
    public class BackupInfo
    {
        #region PROPERTIES
        
        /// <summary>
        /// Backup time.
        /// </summary>
        [DataMember()]
        public DateTime Time
        {
            get; set;
        }

        /// <summary>
        /// Database name.
        /// </summary>
        [DataMember()]
        public string DatabaseName
        {
            get; set;
        } 

        #endregion
    }
}
