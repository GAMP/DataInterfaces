using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Sale report product entry model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class SaleReportProductEntry
    {
        #region PROPERTIES

        /// <summary>
        /// Product name.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public string ProductName
        {
            get; set;
        }

        /// <summary>
        /// Quantity.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal Quantity
        {
            get; set;
        }

        /// <summary>
        /// Total sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Total
        {
            get; set;
        }

        /// <summary>
        /// Product type type.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public ReportEntryType Type
        {
            get; set;
        }

        #endregion
    }
}
