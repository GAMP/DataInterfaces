using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Shifts
{
    [Serializable]
    [DataContract]
    public class ShiftDTO
    {
        [DataMember]
        public int ShiftId { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public decimal StartCash { get; set; }

        [DataMember]
        public string Register { get; set; }

        [DataMember]
        public int RegisterId { get; set; }

        [DataMember]
        public string Operator { get; set; }

        [DataMember]
        public string EndedBy { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime? EndTime { get; set; }

        [DataMember]
        public string Duration { get; set; }

        [DataMember]
        public decimal Expected { get; set; }

        [DataMember]
        public decimal? Actual { get; set; }

        [DataMember]
        public decimal? Difference { get; set; }

        [DataMember]
        public decimal Sales { get; set; }

        [DataMember]
        public decimal Deposits { get; set; }

        [DataMember]
        public decimal Withdrawals { get; set; }

        [DataMember]
        public decimal Refunds { get; set; }

        [DataMember]
        public List<ShiftDetailsDTO> Details { get; set; } = new List<ShiftDetailsDTO>();

    }
}