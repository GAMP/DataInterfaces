using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    [DataContract()]
    public class BackupInfo
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets backup time.
        /// </summary>
        [DataMember()]
        public DateTime Time
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets
        /// </summary>
        [DataMember()]
        public string DatabaseName
        {
            get; set;
        } 

        #endregion
    }
}
