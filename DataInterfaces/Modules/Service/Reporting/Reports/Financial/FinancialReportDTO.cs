using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class FinancialReportDTO : ReportBaseDTO
    {
        [DataMember]
        public FinancialReportType GroupType { get; set; }

        [DataMember]
        public int? OperatorId { get; set; }

        [DataMember]
        public string OperatorName { get; set; }

        [DataMember]
        public int? RegisterId { get; set; }
        
        [DataMember]
        public string RegisterName { get; set; }

        [DataMember]
        public ZDTO Z { get; set; }

        /// <summary>
        /// List of deposit operations performed during the report period.
        /// </summary>
        [DataMember]
        public List<AccountTransactionDTO> Deposits { get; set; } = new List<AccountTransactionDTO>();

        /// <summary>
        /// List of withdrawal operations performed during the report period.
        /// </summary>
        [DataMember]
        public List<AccountTransactionDTO> Withdrawals { get; set; } = new List<AccountTransactionDTO>();

        [DataMember]
        public List<FinancialReportUserGroupInvoicesDTO> GroupInvoices { get; set; } = new List<FinancialReportUserGroupInvoicesDTO>();

        [DataMember]
        public List<FinancialReportUserGroupInvoicesDTO> GroupVoidInvoices { get; set; } = new List<FinancialReportUserGroupInvoicesDTO>();

        [DataMember]
        public InvoicesInfoDTO DepositsPaidCash { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO DepositsPaidCreditCard { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO InvoicesPaidCash { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO InvoicesPaidCreditCard { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO InvoicesPaidFromDeposit { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO InvoicesPayLater { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO VoidInvoicesPaidCash { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO VoidInvoicesToDeposit { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO VoidInvoicesNoRefundOrUnpaid { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO PastInvoicesPaidCash { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO PastInvoicesPaidCreditCard { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public InvoicesInfoDTO PastInvoicesPaidFromDeposit { get; set; } = new InvoicesInfoDTO();

        [DataMember]
        public decimal TotalIncome { get; set; }
    }
}