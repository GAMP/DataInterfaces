using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region OperatorBasicSummary
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class OperatorBasicSummary
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets operator id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int OperatorId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets employee name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string OperatorName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total withdrawals.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Total
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets withdrawals count.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int Count
        {
            get; set;
        }

        #endregion
    }
    #endregion
}
