using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// User spending DTO.
    /// </summary>
    [NotMapped()]
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class UserSpending
    {
        #region PROPERTIES

        /// <summary>
        /// User id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// User name.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Username
        {
            get;set;
        }

        /// <summary>
        /// Total cash spent.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Cash
        {
            get;set;
        }

        /// <summary>
        /// Total deposits spent.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal Deposits
        {
            get;set;
        }

        /// <summary>
        /// Total points spent.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int Points
        {
            get;set;
        }

        /// <summary>
        /// Total spent.
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
