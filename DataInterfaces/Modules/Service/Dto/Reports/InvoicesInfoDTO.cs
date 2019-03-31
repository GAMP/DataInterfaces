using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Dto.Reports
{
    [Serializable]
    [DataContract]
    public class InvoicesInfoDTO
    {
        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal Value { get; set; }
    }
}
