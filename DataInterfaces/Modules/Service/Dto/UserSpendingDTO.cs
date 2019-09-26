using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User spending DTO.
    /// </summary>
    [NotMapped()]
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class UserSpendingDTO
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Username
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets total cash spent.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Cash
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets total deposits spent.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal Deposits
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets total points spent.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int Points
        {
            get;set;
        }

        /// <summary>
        /// Gets total spent.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public decimal Total
        {
            get { return Cash + Deposits; }
        }

        #endregion
    }
}
