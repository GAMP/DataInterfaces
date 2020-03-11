using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// User session entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserSession : CreatedByBase
    {
        #region UserSession

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets host Id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int HostId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets session state.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public SessionState State
        {
            get;
            set;
        }

        /// <summary>
        /// Gets total span.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public double Span
        {
            get;
            set;
        }

        /// <summary>
        /// Gets amount of seconds billed in session active span.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public double BilledSpan
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets session last pend time.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public DateTime? PendTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets pend span.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public double PendSpan
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets session end time.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public DateTime? EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets session slot.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int Slot
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total pend span.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public double PendSpanTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets pause span.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public double PauseSpan
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total pause span.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public double PauseSpanTotal
        {
            get; set;
        }

        #endregion

    }
}
