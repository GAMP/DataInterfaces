using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Register transaction filter.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class RegisterTransactionInfoFilter : DateRangeFilterBase
    {
        #region PROPERTIES

        [DataMember(EmitDefaultValue = false)]
        public RegisterTransactionType? Type
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        public int? CreatedById
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets desired register id.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public int? RegisterId
        {
            get; set;
        }

        #endregion
    }
}
