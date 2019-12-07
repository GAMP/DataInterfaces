using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Hosts
{
    /// <summary>
    /// Group Sessions Estimation.
    /// </summary>
    [Serializable]
    [DataContract]
    public class GroupSessionsEstimationDTO
    {
        /// <summary>
        /// Group name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The time the session was running as text.
        /// </summary>
        [DataMember]
        public string Duration { get; set; }

        /// <summary>
        /// Duration of the user session in minutes.
        /// </summary>
        [DataMember]
        public decimal TotalMinutes { get; set; }

        /// <summary>
        /// Hours used percentage in comparison with other groups within the same period.
        /// </summary>
        [DataMember]
        public decimal HoursPercentage { get; set; }

        /// <summary>
        /// Packet minutes.
        /// </summary>
        [DataMember]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Packet cost.
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }

        /// <summary>
        /// Estimated revenue percentage in comparison with other groups within the same period.
        /// </summary>
        [DataMember]
        public decimal EstimatedRevenuePercentage { get; set; }

        [DataMember]
        public List<GroupSessionsEstimationDTO> SubGroupSessionsEstimations { get; set; }
    }
}