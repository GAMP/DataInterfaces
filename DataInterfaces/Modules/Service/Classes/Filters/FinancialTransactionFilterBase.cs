using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    public class FinancialTransactionFilterBase : TakeSkipFilterBase
    {
        #region PROPERTIES

        [DataMember()]
        public int? UserId
        {
            get; set;
        }

        [DataMember()]
        public DateTime? Start
        {
            get; set;
        }

        [DataMember()]
        public DateTime? End
        {
            get; set;
        }

        [DataMember()]
        public int? CreatedById
        {
            get; set;
        }

        [DataMember()]
        public int? RegisterId
        {
            get; set;
        }

        #endregion
    }
}
