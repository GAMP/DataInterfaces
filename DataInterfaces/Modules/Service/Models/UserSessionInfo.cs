using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User session info model.    
    /// </summary>
    [NotMapped()]
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class UserSessionInfo
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
        /// Gets or sets session start time.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public DateTime StartTime
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets session end time.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public DateTime? EndTime
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets session span.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public double Span
        {
            get; set;
        }

        /// <summary>
        /// Gets session billed span.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public double BilledSpan
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets rate charge.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public decimal Charge
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets prepaid time.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public double PrepaidFixed
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets prepaid product time.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public double PrepaidProdutTime
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets endpoint name.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public string EndpointName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets usage session id.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int? UseageSessionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if active usage session is first.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public bool IsFirstUsageSession
        {
            get; set;
        }

        #region COMPUTED
        
        /// <summary>
        /// Gets total amount of prepaid time.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public double Prepaid
        {
            get { return this.PrepaidFixed + this.PrepaidProdutTime; }
        } 

        #endregion

        #endregion
    }
}
