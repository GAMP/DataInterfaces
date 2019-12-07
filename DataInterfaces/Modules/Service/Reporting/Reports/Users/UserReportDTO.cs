using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Users
{
    /// <summary>
    /// User Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// User information.
        /// </summary>
        [DataMember]
        public UserDTO User { get; set; }  = new UserDTO();

        /// <summary>
        /// Points earned.
        /// </summary>
        [DataMember]
        public int PointsEarned { get; set; }

        /// <summary>
        /// Points used.
        /// </summary>
        [DataMember]
        public int Redeemed { get; set; }

        /// <summary>
        /// Number of logins.
        /// </summary>
        [DataMember]
        public int Logins { get; set; }

        /// <summary>
        /// Total session time as text.
        /// </summary>
        [DataMember]
        public string LoginTime { get; set; }

        /// <summary>
        /// Total amount of deposits.
        /// </summary>
        [DataMember]
        public decimal Deposits { get; set; }

        /// <summary>
        /// Total amount of withdrawals.
        /// </summary>
        [DataMember]
        public decimal Withdrawals { get; set; }

        /// <summary>
        /// Total amount of money spent for products.
        /// </summary>
        [DataMember]
        public decimal Products { get; set; }

        /// <summary>
        /// Total amount of money spent on fixed time.
        /// </summary>
        [DataMember]
        public decimal FixedTime { get; set; }

        /// <summary>
        /// Total amount of money spent on session time.
        /// </summary>
        [DataMember]
        public decimal Sessions { get; set; }

        /// <summary>
        /// Total amount of money spent on time products.
        /// </summary>
        [DataMember]
        public decimal TimeProducts { get; set; }

        /// <summary>
        /// Total amount of money spent.
        /// </summary>
        [DataMember]
        public decimal MoneySpend { get; set; }

        /// <summary>
        /// Number of assets checked out.
        /// </summary>
        [DataMember]
        public int CheckOutItems { get; set; }

        /// <summary>
        /// User's profile picture.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// List of records for the average daily session time chart.
        /// </summary>
        public List<ChartRecordDTO> SessionTimeChartRecords { get; set; } = new List<ChartRecordDTO>();

        /// <summary>
        /// List of records for the average daily spend chart.
        /// </summary>
        public List<ChartRecordDTO> InvoicesChartRecords { get; set; } = new List<ChartRecordDTO>();

    }
}