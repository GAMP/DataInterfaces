using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// User Export Record.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserExportRecordDTO : UserDTO
    {
        /// <summary>
        /// Last login time.
        /// </summary>
        [DataMember]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Current balance.
        /// </summary>
        [DataMember]
        public decimal Balance { get; set; }

        /// <summary>
        /// Current time balance.
        /// </summary>
        [DataMember]
        public int TimeBalance { get; set; }

        /// <summary>
        /// Total deposits.
        /// </summary>
        [DataMember]
        public decimal Deposits { get; set; }

        /// <summary>
        /// User age.
        /// </summary>
        [DataMember]
        public int Age { get; set; }

        /// <summary>
        /// Total points.
        /// </summary>
        [DataMember]
        public int Points { get; set; }
        
    }
}