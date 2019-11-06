using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Overview
{
    /// <summary>
    /// Overview Report Operator Statistics.
    /// </summary>
    [Serializable]
    [DataContract]
    public class OverviewReportOperatorStatisticsDTO
    {
        /// <summary>
        /// Operator Id.
        /// </summary>
        [DataMember]
        public int OperatorId { get; set; }

        /// <summary>
        /// Operator name.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// Total minutes the operator worked.
        /// </summary>
        [DataMember]
        public int MinutesWorked { get; set; }

        /// <summary>
        /// Total hours the operator worked as text.
        /// </summary>
        [DataMember]
        public string HoursWorked { get; set; }

        /// <summary>
        /// Total minutes the operator sold.
        /// </summary>
        [DataMember]
        public decimal MinutesSold { get; set; }

        /// <summary>
        /// Total hours the operator sold as text.
        /// </summary>
        [DataMember]
        public string HoursSold { get; set; }

        /// <summary>
        /// Number of products the operator sold.
        /// </summary>
        [DataMember]
        public int ProductsSold { get; set; }

        /// <summary>
        /// Number of time offers the operator sold.
        /// </summary>
        [DataMember]
        public int TimeOffersSold { get; set; }

        /// <summary>
        /// Number of bundles the operator sold.
        /// </summary>
        [DataMember]
        public int BundlesSold { get; set; }

        /// <summary>
        /// Number of voids the operator performed.
        /// </summary>
        [DataMember]
        public int Voids { get; set; }

        /// <summary>
        /// Operator revenue.
        /// </summary>
        [DataMember]
        public decimal Revenue { get; set; }
    }
}