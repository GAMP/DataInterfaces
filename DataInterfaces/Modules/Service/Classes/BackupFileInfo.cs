using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    public class BackupFileInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets file date.
        /// </summary>
        [DataMember()]
        public DateTime Date
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets file name.
        /// </summary>
        [DataMember()]
        public string FileName
        {
            get; set;
        }

        #endregion
    }
}
