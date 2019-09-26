using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Basic operator summary report model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class OperatorBasicSummary
    {
        #region PROPERTIES

        /// <summary>
        /// Operator id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int OperatorId
        {
            get; set;
        }

        /// <summary>
        /// Operator user name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string OperatorName
        {
            get; set;
        }

        /// <summary>
        /// Total withdrawals.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Total
        {
            get; set;
        }

        /// <summary>
        /// Total withdrawals count.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int Count
        {
            get; set;
        }

        #endregion
    }
}
