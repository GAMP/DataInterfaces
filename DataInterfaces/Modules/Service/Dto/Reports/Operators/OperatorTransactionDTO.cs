using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces.Modules.Service.Dto.Reports.Operators
{
    [Serializable]
    [DataContract]
    public class OperatorTransactionDTO
    {
        [DataMember]
        public string Operator { get; set; }

        [DataMember]
        public DateTime TransactionDate { get; set; }

        [DataMember]
        public DateTime? InvoiceDate { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Customer { get; set; }

        [DataMember]
        public int? InvoiceId { get; set; }

        [DataMember]
        public decimal? Value { get; set; }

        [DataMember]
        public decimal? Total { get; set; }

        [DataMember]
        public string PaymentMethod { get; set; }
    }
}