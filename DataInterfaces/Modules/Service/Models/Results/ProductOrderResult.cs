using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Product order result model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ProductOrderResult
    {
        #region CONSTRUCTOR

        public ProductOrderResult()
        { }

        public ProductOrderResult(OrderResult result)
        {
            Result = result;
        }

        public ProductOrderResult(OrderFailReason failReason)
        {
            FailReason = failReason;
            Result = OrderResult.Failed;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Order result.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public OrderResult Result
        {
            get; set;
        }

        /// <summary>
        /// Fail reason.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public OrderFailReason FailReason
        {
            get; set;
        }

        #endregion
    }
}
