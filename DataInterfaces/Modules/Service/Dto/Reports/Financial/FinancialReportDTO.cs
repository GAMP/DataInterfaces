using ServerService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports.Financial
{
    [Serializable]
    [DataContract]
    public class FinancialReportDTO : ReportBaseDTO
    {
        [DataMember]
        public FinancialReportType GroupType { get; set; }

        [DataMember]
        public List<AccountTransactionDTO> Deposits { get; set; } = new List<AccountTransactionDTO>();

        [DataMember]
        public List<AccountTransactionDTO> Withdrawals { get; set; } = new List<AccountTransactionDTO>();

        [DataMember]
        public List<FinancialReportUserGroupInvoicesDTO> GroupInvoices { get; set; } = new List<FinancialReportUserGroupInvoicesDTO>();

        [DataMember]
        public List<FinancialReportUserGroupInvoicesDTO> GroupVoidInvoices { get; set; } = new List<FinancialReportUserGroupInvoicesDTO>();

        [DataMember]
        public InvoicesInfoDTO DepositsPaidCash { get; set; }

        [DataMember]
        public InvoicesInfoDTO DepositsPaidCreditCard { get; set; }
        
        [DataMember]
        public InvoicesInfoDTO InvoicesPaidCash { get; set; }

        [DataMember]
        public InvoicesInfoDTO InvoicesPaidCreditCard { get; set; }

        [DataMember]
        public InvoicesInfoDTO InvoicesPaidFromDeposit { get; set; }

        [DataMember]
        public InvoicesInfoDTO InvoicesPayLater { get; set; }

        [DataMember]
        public InvoicesInfoDTO VoidInvoicesPaidCash { get; set; }

        [DataMember]
        public InvoicesInfoDTO VoidInvoicesToDeposit { get; set; }

        [DataMember]
        public InvoicesInfoDTO VoidInvoicesNoRefundOrUnpaid { get; set; }

        [DataMember]
        public InvoicesInfoDTO PastInvoicesPaidCash { get; set; }

        [DataMember]
        public InvoicesInfoDTO PastInvoicesPaidCreditCard { get; set; }

        [DataMember]
        public InvoicesInfoDTO PastInvoicesPaidFromDeposit { get; set; }

        [DataMember]
        public decimal TotalIncome { get; set; }
    }
}