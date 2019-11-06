using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// Top User Info.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TopUserInfoDTO
    {
        /// <summary>
        /// User Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The score the user achieved.
        /// </summary>
        [DataMember]
        public decimal Score { get; set; }

        /// <summary>
        /// The score the user achieved as text.
        /// </summary>
        [DataMember]
        public string ScoreText { get; set; }
    }
}