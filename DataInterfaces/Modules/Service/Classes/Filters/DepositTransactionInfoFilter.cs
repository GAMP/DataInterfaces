using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    public class DepositTransactionInfoFilter : FinancialTransactionFilterBase
    {
        #region PROPERTIES

        [DataMember()]
        public DepositTransactionType? Type
        {
            get; set;
        } 

        #endregion
    }
}
