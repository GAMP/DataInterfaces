﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces.Modules.Service.Dto.Reports.Products
{
    [Serializable]
    [DataContract]
    public class StockTransactionDTO
    {
        [DataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        public decimal OnHand { get; set; }
    }
}
