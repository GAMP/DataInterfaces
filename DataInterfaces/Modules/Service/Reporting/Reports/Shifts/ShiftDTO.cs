using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Shifts
{
    /// <summary>
    /// Shift Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ShiftDTO
    {
        /// <summary>
        /// Shift Id.
        /// </summary>
        [DataMember]
        public int ShiftId { get; set; }

        /// <summary>
        /// The shift is active.
        /// </summary>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Cash amount the shift started with.
        /// </summary>
        [DataMember]
        public decimal StartCash { get; set; }

        /// <summary>
        /// The Id of the register on which the shift was started.
        /// </summary>
        [DataMember]
        public int RegisterId { get; set; }

        /// <summary>
        /// The name of the register on which the shift was started.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// The name of the operator to which the shift belongs.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// The name of the operator who ended the shift.
        /// </summary>
        [DataMember]
        public string EndedByOperatorName { get; set; }

        /// <summary>
        /// The time the shift started.
        /// </summary>
        [DataMember]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The time the shift ended or null if is still active.
        /// </summary>
        [DataMember]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Duration of the shift in minutes.
        /// </summary>
        [DataMember]
        public int DurationMinutes { get; set; }

        /// <summary>
        /// Duration of the shift as text.
        /// </summary>
        [DataMember]
        public string Duration { get; set; }

        /// <summary>
        /// Amount expected the shift to end with.
        /// </summary>
        [DataMember]
        public decimal Expected { get; set; }

        /// <summary>
        /// Actual amount the shift ended with.
        /// </summary>
        [DataMember]
        public decimal? Actual { get; set; }

        /// <summary>
        /// Difference between the expected and the actual amount.
        /// </summary>
        [DataMember]
        public decimal? Difference { get; set; }

        /// <summary>
        /// Total amount of sales in this shift.
        /// </summary>
        [DataMember]
        public decimal Sales { get; set; }

        /// <summary>
        /// Total amount of deposits in this shift.
        /// </summary>
        [DataMember]
        public decimal Deposits { get; set; }

        /// <summary>
        /// Total amount of withdrawals in this shift.
        /// </summary>
        [DataMember]
        public decimal Withdrawals { get; set; }

        /// <summary>
        /// Total amount of refunds in this shift.
        /// </summary>
        [DataMember]
        public decimal Refunds { get; set; }

        /// <summary>
        /// List of shift details by payment method.
        /// </summary>
        [DataMember]
        public List<ShiftDetailsDTO> Details { get; set; } = new List<ShiftDetailsDTO>();

    }
}