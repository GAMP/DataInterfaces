using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Point transaction model.
    /// </summary>
    [DataContract()]
    public class PointTransactionInfo : ResourceCreatedByInfo
    {
        #region PROPERTIES
        
        /// <summary>
        /// Transaction id.
        /// </summary>
        [DataMember()]
        public int TransactionId
        {
            get; set;
        }

        /// <summary>
        /// Transaction amount.
        /// </summary>
        [DataMember()]
        public double Amount
        {
            get; set;
        } 

        /// <summary>
        /// Balance at time of transaction.
        /// </summary>
        [DataMember()]
        public double Balance
        {
            get;set;
        }

        /// <summary>
        /// Transaction type.
        /// </summary>
        [DataMember()]
        public SharedLib.LoyalityPointsTransactionType Type
        {
            get;set;
        }

        /// <summary>
        /// User id.
        /// </summary>
        [DataMember()]
        public int UserId
        {
            get;set;
        }

        #endregion
    }
}
