using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Shift info model.
    /// </summary>
    [ProtoContract()]
    [Serializable()]
    [DataContract()]
    public class ShiftInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift operator id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int OperatorId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets operator username.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public string Operator
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register number.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int RegisterNumber
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register name.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public string RegisterName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift start time.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public DateTime ShiftStart
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift start cash.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public decimal StartCash
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift is currently ending.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public bool IsEnding
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets ended by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int? EndedById
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets ended by operator name.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public string EndedBy
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets if shift is active.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public bool IsActive
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets created by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public int? CreatedById
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets created by.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public string CreatedBy
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets if at least one operator is connected to register.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public bool IsConnected
        {
            get;set;
        }

        #endregion
    }
}
