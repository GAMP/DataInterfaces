using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Deposit transaction filter model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class DepositTransactionInfoFilter : FinancialTransactionFilterBase
    {
        #region PROPERTIES

        /// <summary>
        /// Deposit transaction type.
        /// </summary>
        [DataMember()]
        public Gizmo.Web.Api.Models.DepositTransactionType? Type
        {
            get; set;
        }

        #endregion
    }
}
