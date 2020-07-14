using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Financial Report Base.
    /// </summary>
    [Serializable]
    [DataContract]
    public class FinancialReportBaseDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filtered Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filtered Operator Name.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// Filtered Register Id.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// Filtered Register Name.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// Filtered Financial Report Type.
        /// </summary>
        [DataMember]
        public FinancialReportTypes FinancialReportType { get; set; }

        /// <summary>
        /// List of deposit operations performed during the reporting period.
        /// </summary>
        [DataMember]
        public List<AccountTransactionDTO> Deposits { get; set; } = new List<AccountTransactionDTO>();

        /// <summary>
        /// List of withdrawal operations performed during the reporting period.
        /// </summary>
        [DataMember]
        public List<AccountTransactionDTO> Withdrawals { get; set; } = new List<AccountTransactionDTO>();

        /// <summary>
        /// List of invoices grouped based on financial report type.
        /// </summary>
        [DataMember]
        public List<FinancialReportUserGroupInvoicesDTO> GroupInvoices { get; set; } = new List<FinancialReportUserGroupInvoicesDTO>();

        /// <summary>
        /// List of voided invoices grouped based on financial report type.
        /// </summary>
        [DataMember]
        public List<FinancialReportUserGroupInvoicesDTO> GroupVoidInvoices { get; set; } = new List<FinancialReportUserGroupInvoicesDTO>();

        /// <summary>
        /// Summary of deposits grouped by payment method.
        /// </summary>
        [DataMember]
        public List<FinancialSummaryRecordDTO> DepositsSummary { get; set; } = new List<FinancialSummaryRecordDTO>();

        /// <summary>
        /// Summary of sales grouped by payment method.
        /// </summary>
        [DataMember]
        public List<FinancialSummaryRecordDTO> SalesSummary { get; set; } = new List<FinancialSummaryRecordDTO>();

        /// <summary>
        /// Summary of voids grouped by refund method.
        /// </summary>
        [DataMember]
        public List<FinancialSummaryRecordDTO> VoidInvoicesPaidCash { get; set; } = new List<FinancialSummaryRecordDTO>();

        /// <summary>
        /// Summary of voids with no refund or unpaid.
        /// </summary>
        [DataMember]
        public FinancialSummaryRecordDTO VoidInvoicesNoRefundOrUnpaid { get; set; } = new FinancialSummaryRecordDTO();

        /// <summary>
        /// Summary of past sales paid within the reporting period grouped by payment method.
        /// </summary>
        [DataMember]
        public List<FinancialSummaryRecordDTO> PastSalesPaymentsSummary { get; set; } = new List<FinancialSummaryRecordDTO>();
               
        /// <summary>
        /// List of available payment methods.
        /// </summary>
        public List<ListItemDTO> PaymentMethods { get; set; } = new List<ListItemDTO>();

        /// <summary>
        /// List of register transactions performed during the reporting period.
        /// </summary>
        [DataMember]
        public List<RegisterTransactionDTO> RegisterTransactions { get; set; } = new List<RegisterTransactionDTO>();

    }
}