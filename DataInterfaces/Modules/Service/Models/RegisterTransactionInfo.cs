using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Register transaction info model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class RegisterTransactionInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// Amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Type.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public RegisterTransactionType Type
        {
            get; set;
        }

        /// <summary>
        /// Note.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// CreatedTime.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public DateTime CreatedTime
        {
            get; set;
        }

        /// <summary>
        /// Created by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public int? CreatedById
        {
            get; set;
        }

        /// <summary>
        /// Creaded by username.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public string CreatedByUsername
        {
            get; set;
        }

        /// <summary>
        /// Register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public int RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Register name.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public string RegisterName
        {
            get; set;
        }

        /// <summary>
        /// Shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int? ShiftId
        {
            get; set;
        }

        #endregion
    }
}