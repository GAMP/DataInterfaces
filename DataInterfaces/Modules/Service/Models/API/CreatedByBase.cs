using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class CreatedByBase : EntityBase
    {
        /// <summary>
        /// Gets or sets created by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int? CreatedById
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets created time.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public DateTime CreatedTime
        {
            get; set;
        }
    }
}
