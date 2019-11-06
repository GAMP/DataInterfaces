using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Financial transaction filter base.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class FinancialTransactionFilterBase : DateRangeFilterBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        public int? UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets created time.
        /// </summary>
        [DataMember()]
        public int? CreatedById
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        public int? RegisterId
        {
            get; set;
        }

        #endregion
    }
}
